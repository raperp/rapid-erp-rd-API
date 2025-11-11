using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class CountryService(RapidERPDbContext context) : ICountry
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<CountryPOST> masterPOSTs)
    {
        try
        {
            foreach (var masterPOST in masterPOSTs)
            {
                await CreateSingle(masterPOST);
            }

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                IsSuccess = true,
                Message = ResponseMessage.CreateSuccess,
                Data = masterPOSTs
            };

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
                masterData.Name = masterPOST.Name;
                masterData.TenantId = masterPOST.TenantId;
                masterData.MenuId = masterPOST.MenuId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.ISONumeric = masterPOST.ISONumeric;
                masterData.DialCode = masterPOST.DialCode;
                masterData.ISO2Code = masterPOST.ISO2Code;
                masterData.ISO3Code = masterPOST.ISO3Code;
                masterData.FlagURL = masterPOST.FlagURL;
                masterData.IsDefault = masterPOST.IsDefault;
                masterData.CreatedBy = masterPOST.CreatedBy;
                masterData.CreatedAt = DateTime.Now;

                await context.Countries.AddAsync(masterData);
                await context.SaveChangesAsync();

                CountryAudit audit = new();
                audit.Name = masterPOST.Name;
                audit.TenantId = masterPOST.TenantId;
                audit.MenuId = masterPOST.MenuId;
                audit.StatusTypeId = masterPOST.StatusTypeId;
                audit.LanguageId = masterPOST.LanguageId;
                audit.ISONumeric = masterPOST.ISONumeric;
                audit.DialCode = masterPOST.DialCode;
                audit.ISO2Code = masterPOST.ISO2Code;
                audit.ISO3Code = masterPOST.ISO3Code;
                audit.FlagURL = masterPOST.FlagURL;
                audit.CountryId = masterData.Id;
                audit.StatusTypeId = masterPOST.StatusTypeId;
                audit.ActionTypeId = masterPOST.ActionTypeId;
                audit.ExportTypeId = masterPOST.ExportTypeId;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.IsDefault = masterPOST.IsDefault;
                audit.Browser = masterPOST.Browser;
                audit.DeviceName = masterPOST.DeviceName;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                audit.GoogleMapUrl = masterPOST.GoogleMapUrl;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                audit.ActionBy = masterPOST.CreatedBy;
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
                        select new
                        {
                            c.Id,
                            c.Name,
                            Tanent = t.Name,
                            Language = l.Name,
                            c.ISONumeric,
                            c.DialCode,
                            c.ISO2Code,
                            c.ISO3Code,
                            c.FlagURL,
                            c.IsDefault,
                            Status = st.Name,
                            c.CreatedBy,
                            c.CreatedAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await GetAllCounts();
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
                result.Count = await GetAllCounts();
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
                        //join et in context.ExportTypes on ca.ExportTypeId equals et.Id
                        join at in context.ActionTypes on ca.ActionTypeId equals at.Id
                        join st in context.StatusTypes on ca.StatusTypeId equals st.Id
                        select new
                        {
                            ca.Id,
                            Country = c.Name,
                            ca.Name,
                            //ExportType = et.Name,
                            ActionType = at.Name,
                            StatusType = st.Name,
                            ca.ExportTo,
                            ca.SourceURL,
                            ca.IsDefault,
                            ca.ISONumeric,
                            ca.DialCode,
                            ca.ISO2Code,
                            ca.ISO3Code,
                            ca.FlagURL,
                            ca.Browser,
                            ca.DeviceName,
                            ca.Location,
                            ca.DeviceIP,
                            ca.GoogleMapUrl,
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

    public async Task<RequestResponse> GetSingle(int id)
    {
        try
        {
            var data = await context.Countries.Where(x => x.Id == id).AsNoTracking().ToListAsync();

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = data
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
                await context.Countries.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.TenantId, masterPUT.TenantId)
                .SetProperty(x => x.MenuId, masterPUT.MenuId)
                .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.ISONumeric, masterPUT.ISONumeric)
                .SetProperty(x => x.DialCode, masterPUT.DialCode)
                .SetProperty(x => x.ISO2Code, masterPUT.ISO2Code)
                .SetProperty(x => x.ISO3Code, masterPUT.ISO3Code)
                .SetProperty(x => x.FlagURL, masterPUT.FlagURL)
                .SetProperty(x => x.IsDefault, masterPUT.IsDefault)
                .SetProperty(x => x.UpdatedBy, masterPUT.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, DateTime.Now));

                CountryAudit audit = new();
                audit.Name = masterPUT.Name;
                audit.TenantId = masterPUT.TenantId;
                audit.MenuId = masterPUT.MenuId;
                audit.StatusTypeId = masterPUT.StatusTypeId;
                audit.LanguageId = masterPUT.LanguageId;
                audit.ISONumeric = masterPUT.ISONumeric;
                audit.DialCode = masterPUT.DialCode;
                audit.ISO2Code = masterPUT.ISO2Code;
                audit.ISO3Code = masterPUT.ISO3Code;
                audit.FlagURL = masterPUT.FlagURL;
                audit.CountryId = masterPUT.Id;
                audit.StatusTypeId = masterPUT.StatusTypeId;
                audit.ActionTypeId = masterPUT.ActionTypeId;
                audit.ExportTypeId = masterPUT.ExportTypeId;
                audit.ExportTo = masterPUT.ExportTo;
                audit.SourceURL = masterPUT.SourceURL;
                audit.IsDefault = masterPUT.IsDefault;
                audit.Browser = masterPUT.Browser;
                audit.DeviceName = masterPUT.DeviceName;
                audit.Location = masterPUT.Location;
                audit.DeviceIP = masterPUT.DeviceIP;
                audit.GoogleMapUrl = masterPUT.GoogleMapUrl;
                audit.Latitude = masterPUT.Latitude;
                audit.Longitude = masterPUT.Longitude;
                audit.ActionBy = masterPUT.UpdatedBy;
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
    public async Task<dynamic> GetAllCounts()
    {
        try
        {
            float totalCount = await context.Countries.CountAsync();
            int activeCount = await context.Countries.Where(x => x.StatusTypeId == 3).CountAsync();
            int inActiveCount = await context.Countries.Where(x => x.StatusTypeId == 10).CountAsync();
            int draftCount = await context.Countries.Where(x => x.StatusTypeId == 5).CountAsync();
            int updatedCount = await context.Countries.Where(x => x.UpdatedAt != null).CountAsync();
            int deletedCount = await context.Countries.Where(x => x.StatusTypeId == 7).CountAsync();
            int softDeletedCount = await context.Countries.Where(x => x.StatusTypeId == 6).CountAsync();

            float totalPercentage = totalCount / totalCount * 100;
            float activePercentage = activeCount / totalCount * 100;
            float inActivePercentage = inActiveCount / totalCount * 100;
            float draftPercentage = draftCount / totalCount * 100;
            float updatedPercentage = updatedCount / totalCount * 100;
            float deletedPercentage = deletedCount / totalCount * 100;
            float softDeletedPercentage = softDeletedCount / totalCount * 100;

            var result = new
            {
                totalCount,
                activeCount,
                inActiveCount,
                draftCount,
                updatedCount,
                deletedCount,
                softDeletedCount,

                totalPercentage = $"{totalPercentage.ToString()}%",
                activePercentage = $"{activePercentage.ToString()}%",
                inActivePercentage = $"{inActivePercentage.ToString()}%",
                draftPercentage = $"{draftPercentage.ToString()}%",
                updatedPercentage = $"{updatedPercentage.ToString()}%",
                deletedPercentage = $"{deletedPercentage.ToString()}%",
                softDeletedPercentage = $"{softDeletedPercentage.ToString()}%"
            };

            return result;
        }

        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
