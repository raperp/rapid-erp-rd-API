using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class CountryService(RapidERPDbContext context, IShared shared) : ICountry
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<CountryPOST> masterPOSTs)
    {
        try
        {
            requestResponse = new();

            foreach (var masterPOST in masterPOSTs)
            {
                var task = CreateSingle(masterPOST);
                var result = await Task.WhenAll(task);
                requestResponse.Message = result.FirstOrDefault().Message;
                requestResponse.IsSuccess = result.FirstOrDefault().IsSuccess;
                requestResponse.StatusCode = result.FirstOrDefault().StatusCode;
                requestResponse.Data = result.FirstOrDefault().Data;
            }

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> CreateSingle(CountryPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Country masterData = new();
                masterData.TenantId = masterPOST.TenantId;
                masterData.MenuId = masterPOST.MenuId;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.ISONumeric = masterPOST.ISONumeric;
                masterData.Name = masterPOST.Name;
                masterData.DialCode = masterPOST.DialCode;
                masterData.ISO2Code = masterPOST.ISO2Code;
                masterData.ISO3Code = masterPOST.ISO3Code;
                masterData.FlagURL = masterPOST.FlagURL;
                masterData.IsDefault = masterPOST.IsDefault;
                masterData.CreatedBy = (masterPOST.IsDraft == false) ? masterPOST.ActionBy : null;
                masterData.CreatedAt = (masterPOST.IsDraft == false) ? DateTime.Now : null;
                masterData.DraftedBy = (masterPOST.IsDraft == true) ? masterPOST.ActionBy : null;
                masterData.DraftedAt = (masterPOST.IsDraft == true) ? DateTime.Now : null;
                masterData.SoftDeletedBy = null;
                masterData.SoftDeletedAt = null;
                masterData.RestoredAt = null;
                masterData.RestoredBy = null;

                await context.Countries.AddAsync(masterData);
                await context.SaveChangesAsync();

                CountryAudit audit = new();
                audit.CountryId = masterData.Id;
                audit.TenantId = masterPOST.TenantId;
                audit.LanguageId = masterPOST.LanguageId;
                audit.ActionTypeId = masterPOST.ActionTypeId;
                audit.ExportTypeId = masterPOST.ExportTypeId;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.ISONumeric = masterPOST.ISONumeric;
                audit.Name = masterPOST.Name;
                audit.DialCode = masterPOST.DialCode;
                audit.ISO2Code = masterPOST.ISO2Code;
                audit.ISO3Code = masterPOST.ISO3Code;
                audit.FlagURL = masterPOST.FlagURL;
                audit.IsDefault = masterPOST.IsDefault;
                audit.Browser = masterPOST.Browser;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                audit.GoogleMapURL = masterPOST.GoogleMapURL;
                audit.DeviceName = masterPOST.DeviceName;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                audit.ActionBy = masterPOST.ActionBy;
                audit.ActionAt = DateTime.Now;

                await context.CountryAudits.AddAsync(audit);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = masterPOST
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = $"{ResponseMessage.RecordExists} {masterPOST.Name}"
                };
            }

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> Delete(int id)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isAuditExists = await context.CountryAudits.AsNoTracking().AnyAsync(x => x.CountryId == id);

            if (isAuditExists == false)
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }

            else
            {
                await context.CountryAudits.Where(x => x.CountryId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Id == id);

            if (isExists == false)
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }

            else
            {
                await context.Countries.Where(x => x.Id == id).ExecuteDeleteAsync();
                await transaction.CommitAsync();
            }

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.DeleteSuccess
            };

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> GetAll(int skip, int take)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from c in context.Countries
                        join st in context.StatusTypes on c.StatusTypeId equals st.Id
                        join t in context.Tenants on c.TenantId equals t.Id
                        join l in context.Languages on c.LanguageId equals l.Id
                        join m in context.Menus on c.MenuId equals m.Id
                        select new
                        {
                            c.Id,
                            Tanent = t.Name,
                            Menu = m.Name,
                            Language = l.Name,
                            Status = st.Name,
                            c.ISONumeric,
                            c.Name,
                            c.DialCode,
                            c.ISO2Code,
                            c.ISO3Code,
                            c.FlagURL,
                            c.IsDefault,
                            c.CreatedBy,
                            c.CreatedAt,
                            c.UpdatedBy,
                            c.UpdatedAt,
                            c.DraftedBy,
                            c.DraftedAt,
                            c.SoftDeletedBy,
                            c.SoftDeletedAt,
                            c.RestoredBy,
                            c.RestoredAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Country>();
                result.Data = await data.ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
                };
            }

            else
            {
                result.Count = await shared.GetCounts<Country>();
                result.Data = await data.Skip(skip).Take(take).ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> GetAllAudits(int skip, int take)
    {
        try
        {
            var data = (from ca in context.CountryAudits
                        join c in context.Countries on ca.CountryId equals c.Id
                        join et in context.ExportTypes on ca.ExportTypeId equals et.Id
                        join at in context.ActionTypes on ca.ActionTypeId equals at.Id
                        join t in context.Tenants on ca.TenantId equals t.Id
                        join l in context.Languages on ca.LanguageId equals l.Id
                        select new
                        {
                            ca.Id,
                            Country = c.Name,
                            Tanent = t.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            ca.ExportTo,
                            ca.SourceURL,
                            c.ISONumeric,
                            ca.Name,
                            ca.DialCode,
                            ca.ISO2Code,
                            ca.ISO3Code,
                            ca.FlagURL,
                            ca.IsDefault,
                            ca.Browser,
                            ca.Location,
                            ca.DeviceIP,
                            ca.GoogleMapURL,
                            ca.DeviceName,
                            ca.Latitude,
                            ca.Longitude,
                            ca.ActionBy,
                            ca.ActionAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                var result = await data.ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
                };
            }

            else
            {
                var result = await data.Skip(skip).Take(take).ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<dynamic> GetSingle(int id)
    {
        var result = await shared.GetSingle<Country>(id);
        return result;
    }

    public async Task<RequestResponse> SoftDeleteRestore(SoftDeleteRestore softDeleteRestore)
    {
        try
        {
            var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Id == softDeleteRestore.Id);

            if (isExists == false)
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }

            else
            {
                int? softDeletedBy = (softDeleteRestore.IsSoftDelete == true) ? softDeleteRestore.ActionBy : null;
                DateTime? softDeletedAt = (softDeleteRestore.IsSoftDelete == true) ? DateTime.Now : null;
                int? restoredBy = (softDeleteRestore.IsSoftDelete == false) ? softDeleteRestore.ActionBy : null;
                DateTime? restoredAt = (softDeleteRestore.IsSoftDelete == false) ? DateTime.Now : null;

                await context.Countries.Where(x => x.Id == softDeleteRestore.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.SoftDeletedBy, softDeletedBy)
                .SetProperty(x => x.SoftDeletedAt, softDeletedAt)
                .SetProperty(x => x.RestoredBy, restoredBy)
                .SetProperty(x => x.RestoredAt, restoredAt));
            }

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.DeleteSuccess
            };

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> Update(CountryPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                int? updatedBy = (masterPUT.IsDraft == false) ? masterPUT.ActionBy : null;
                DateTime? updatedAt = (masterPUT.IsDraft == false) ? DateTime.Now : null;
                int? draftedBy = (masterPUT.IsDraft == true) ? masterPUT.ActionBy : null;
                DateTime? draftedAt = (masterPUT.IsDraft == true) ? DateTime.Now : null;
                
                await context.Countries.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.TenantId, masterPUT.TenantId)
                .SetProperty(x => x.MenuId, masterPUT.MenuId)
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                .SetProperty(x => x.ISONumeric, masterPUT.ISONumeric)
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.DialCode, masterPUT.DialCode)
                .SetProperty(x => x.ISO2Code, masterPUT.ISO2Code)
                .SetProperty(x => x.ISO3Code, masterPUT.ISO3Code)
                .SetProperty(x => x.FlagURL, masterPUT.FlagURL)
                .SetProperty(x => x.IsDefault, masterPUT.IsDefault)
                .SetProperty(x => x.UpdatedAt, updatedAt)
                .SetProperty(x => x.UpdatedBy, updatedBy)
                .SetProperty(x => x.DraftedAt, draftedAt)
                .SetProperty(x => x.DraftedBy, draftedBy));

                CountryAudit audit = new();
                audit.CountryId = masterPUT.Id;
                audit.TenantId = masterPUT.TenantId;
                audit.LanguageId = masterPUT.LanguageId;
                audit.ActionTypeId = masterPUT.ActionTypeId;
                audit.ExportTypeId = masterPUT.ExportTypeId;
                audit.ExportTo = masterPUT.ExportTo;
                audit.SourceURL = masterPUT.SourceURL;
                audit.ISONumeric = masterPUT.ISONumeric;
                audit.Name = masterPUT.Name;
                audit.DialCode = masterPUT.DialCode;
                audit.ISO2Code = masterPUT.ISO2Code;
                audit.ISO3Code = masterPUT.ISO3Code;
                audit.FlagURL = masterPUT.FlagURL;
                audit.IsDefault = masterPUT.IsDefault;
                audit.Browser = masterPUT.Browser;
                audit.Location = masterPUT.Location;
                audit.DeviceIP = masterPUT.DeviceIP;
                audit.GoogleMapURL = masterPUT.GoogleMapURL;
                audit.DeviceName = masterPUT.DeviceName;
                audit.Latitude = masterPUT.Latitude;
                audit.Longitude = masterPUT.Longitude;
                audit.ActionBy = masterPUT.ActionBy;
                audit.ActionAt = DateTime.Now;

                await context.CountryAudits.AddAsync(audit);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.UpdateSuccess,
                    Data = masterPUT
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = ResponseMessage.RecordExists
                };
            }

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }
}
