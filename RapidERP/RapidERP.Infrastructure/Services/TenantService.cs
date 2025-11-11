using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.TenantDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;
using System.Linq.Expressions;

namespace RapidERP.Infrastructure.Services;

public class TenantService(RapidERPDbContext context) : ITenant
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<TenantPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(TenantPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Tenants.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Tenant masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.Contact = masterPOST.Contact;
                masterData.Phone = masterPOST.Phone;
                masterData.Mobile = masterPOST.Mobile;
                masterData.Address = masterPOST.Address;
                masterData.Email = masterPOST.Email;
                masterData.Website = masterPOST.Website;
                masterData.CountryId = masterPOST.CountryId;
                masterData.StateId = masterPOST.StateId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.CreatedBy = masterPOST.CreatedBy;
                masterData.CreatedAt = DateTime.Now;

                await context.Tenants.AddAsync(masterData);
                await context.SaveChangesAsync();

                TenantAudit audit = new();
                audit.Name = masterPOST.Name;
                audit.Contact = masterPOST.Contact;
                audit.Phone = masterPOST.Phone;
                audit.Mobile = masterPOST.Mobile;
                audit.Address = masterPOST.Address;
                audit.Email = masterPOST.Email;
                audit.Website = masterPOST.Website;
                audit.CountryId = masterPOST.CountryId;
                audit.StateId = masterPOST.StateId;
                audit.TenantId = masterData.Id;
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

                await context.TenantAudits.AddAsync(audit);
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
            var isAuditExists = await context.TenantAudits.AsNoTracking().AnyAsync(x => x.TenantId == id);

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
                await context.TenantAudits.Where(x => x.TenantId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Tenants.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.Tenants.Where(x => x.Id == id).ExecuteDeleteAsync();
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

            var data = (from t in context.Tenants
                        join st in context.StatusTypes on t.StatusTypeId equals st.Id
                        select new
                        {
                            t.Id,
                            t.Name,
                            t.Contact,
                            t.Phone,
                            t.Mobile,
                            t.Address,
                            t.Email,
                            t.Website,
                            t.CountryId,
                            t.StateId,
                            Status = st.Name,
                            t.CreatedBy,
                            t.CreatedAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await GetAllCounts();
                result.Data = await data.ToListAsync();

                //var result = await data.ToListAsync();

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
                var results = await data.Skip(skip).Take(take).ToListAsync();

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
            var data = (from ta in context.TenantAudits
                        //join et in context.ExportTypes on ta.ExportTypeId equals et.Id
                        join at in context.ActionTypes on ta.ActionTypeId equals at.Id
                        join st in context.StatusTypes on ta.StatusTypeId equals st.Id
                        select new
                        {
                            ta.Id,
                            ta.Name,
                            //ExportType = et.Name,
                            ActionType = at.Name,
                            StatusType = st.Name,
                            ta.ExportTo,
                            ta.SourceURL,
                            ta.IsDefault,
                            ta.Contact,
                            ta.Phone,
                            ta.Mobile,
                            ta.Address,
                            ta.Email,
                            ta.Website,
                            ta.Browser,
                            ta.DeviceName,
                            ta.Location,
                            ta.DeviceIP,
                            ta.GoogleMapUrl,
                            ta.Latitude,
                            ta.Longitude,
                            ta.ActionBy,
                            ta.ActionAt
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
            var data = await context.Tenants.Where(x => x.Id == id).AsNoTracking().ToListAsync();

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

    public async Task<RequestResponse> Update(TenantPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Tenants.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Tenants.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Contact, masterPUT.Contact)
                .SetProperty(x => x.Phone, masterPUT.Phone)
                .SetProperty(x => x.Mobile, masterPUT.Mobile)
                .SetProperty(x => x.Address, masterPUT.Address)
                .SetProperty(x => x.Email, masterPUT.Email)
                .SetProperty(x => x.Website, masterPUT.Website)
                .SetProperty(x => x.CountryId, masterPUT.CountryId)
                .SetProperty(x => x.StateId, masterPUT.StateId)
                .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                .SetProperty(x => x.UpdatedBy, masterPUT.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, DateTime.Now));

                TenantAudit audit = new();
                audit.Name = masterPUT.Name;
                audit.Contact = masterPUT.Contact;
                audit.Phone = masterPUT.Phone;
                audit.Mobile = masterPUT.Mobile;
                audit.Address = masterPUT.Address;
                audit.Email = masterPUT.Email;
                audit.Website = masterPUT.Website;
                audit.CountryId = masterPUT.CountryId;
                audit.StateId = masterPUT.StateId;
                audit.TenantId = masterPUT.Id;
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

                await context.TenantAudits.AddAsync(audit);
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
            float totalCount = await context.Tenants.CountAsync();
            int activeCount = await context.Tenants.Where(x => x.StatusTypeId == 3).CountAsync();
            int inActiveCount = await context.Tenants.Where(x => x.StatusTypeId == 10).CountAsync();
            int draftCount = await context.Tenants.Where(x => x.StatusTypeId == 5).CountAsync();
            int updatedCount = await context.Tenants.Where(x => x.UpdatedAt != null).CountAsync();
            int deletedCount = await context.Tenants.Where(x => x.StatusTypeId == 7).CountAsync();
            int softDeletedCount = await context.Tenants.Where(x => x.StatusTypeId == 6).CountAsync();

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
