using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.TenantDTOs.TenantDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Interfaces.Tenant;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services.TenantServices;

public class TenantService(RapidERPDbContext context, ISharedService shared) : ITenantService
{
    RequestResponse requestResponse { get; set; }
    
    public async Task<RequestResponse> CreateBulk(List<TenantPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(TenantPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Tenants.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Tenant masterData = new();
                masterData.MenuModuleId = masterPOST.MenuModuleId;
                masterData.CountryId = masterPOST.CountryId;
                masterData.StateId = masterPOST.StateId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.Name = masterPOST.Name;
                masterData.Contact = masterPOST.Contact;
                masterData.Phone = masterPOST.Phone;
                masterData.Mobile = masterPOST.Mobile;
                masterData.Address = masterPOST.Address;
                masterData.Email = masterPOST.Email;
                masterData.Website = masterPOST.Website;

                await context.Tenants.AddAsync(masterData);
                await context.SaveChangesAsync();

                TenantHistory history = new();
                history.TenantId = masterData.Id;
                history.MenuModuleId = masterPOST.MenuModuleId;
                history.CountryId = masterPOST.CountryId;
                history.StateId = masterPOST.StateId;
                history.LanguageId = masterPOST.LanguageId;
                history.CalendarId = masterPOST.CalendarId;
                history.ActionTypeId = masterPOST.ActionTypeId;
                history.ExportTypeId = masterPOST.ExportTypeId;
                history.ExportTo = masterPOST.ExportTo;
                history.SourceURL = masterPOST.SourceURL;
                history.Name = masterPOST.Name;
                history.Contact = masterPOST.Contact;
                history.Phone = masterPOST.Phone;
                history.Mobile = masterPOST.Mobile;
                history.Address = masterPOST.Address;
                history.Email = masterPOST.Email;
                history.Website = masterPOST.Website;
                history.Browser = masterPOST.Browser;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                history.LocationURL = masterPOST.LocationURL;
                history.DeviceName = masterPOST.DeviceName;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                history.ActionBy = masterPOST.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.TenantHistory.AddAsync(history);
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
            var ishistoryExists = await context.TenantHistory.AsNoTracking().AnyAsync(x => x.TenantId == id);

            if (ishistoryExists == false)
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
                await context.TenantHistory.Where(x => x.TenantId == id).ExecuteDeleteAsync();
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

    public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from t in context.Tenants
                        join mm in context.MenuModules on t.MenuModuleId equals mm.Id
                        join c in context.Countries on t.CountryId equals c.Id
                        join s in context.States on t.StateId equals s.Id
                        join l in context.Languages on t.LanguageId equals l.Id
                        join st in context.StatusTypes on t.StatusTypeId equals st.Id
                        select new
                        {
                            t.Id,
                            MenuModule = mm.Name,
                            Country = c.Name,
                            State = s.Name,
                            Status = st.Name,
                            Language = l.Name,
                            t.Name,
                            t.Contact,
                            t.Phone,
                            t.Mobile,
                            t.Address,
                            t.Email,
                            t.Website
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Tenant>(pageSize);
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
                result.Count = await shared.GetCounts<Tenant>(pageSize);
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

    public async Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    {
        try
        {
            var data = (from th in context.TenantHistory
                        join t in context.Tenants on th.TenantId equals t.Id
                        join mm in context.MenuModules on th.MenuModuleId equals mm.Id
                        join c in context.Countries on th.CountryId equals c.Id
                        join s in context.States on th.StateId equals s.Id
                        join l in context.Languages on th.LanguageId equals l.Id
                        join at in context.ActionTypes on th.ActionTypeId equals at.Id
                        join et in context.ExportTypes on th.ExportTypeId equals et.Id
                        select new
                        {
                            th.Id,
                            Tenant = t.Name,
                            MenuModule = mm.Name,
                            Country = c.Name,
                            State = s.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportMedia = et.Name,
                            th.ExportTo,
                            th.SourceURL,
                            th.Name,
                            th.Contact,
                            th.Phone,
                            th.Mobile,
                            th.Address,
                            th.Email,
                            th.Website,
                            th.Browser,
                            th.Location,
                            th.DeviceIP,
                            th.LocationURL,
                            th.DeviceName,
                            th.Latitude,
                            th.Longitude,
                            th.ActionBy,
                            th.ActionAt
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
        var result = await shared.GetSingle<Tenant>(id);
        return result;
    }

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = await shared.SoftDelete<Tenant>(id);
        return result;
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
                .SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                .SetProperty(x => x.CountryId, masterPUT.CountryId)
                .SetProperty(x => x.StateId, masterPUT.StateId)
                .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Contact, masterPUT.Contact)
                .SetProperty(x => x.Phone, masterPUT.Phone)
                .SetProperty(x => x.Mobile, masterPUT.Mobile)
                .SetProperty(x => x.Address, masterPUT.Address)
                .SetProperty(x => x.Email, masterPUT.Email)
                .SetProperty(x => x.Website, masterPUT.Website));

                TenantHistory history = new();
                history.TenantId = masterPUT.Id;
                history.MenuModuleId = masterPUT.MenuModuleId;
                history.CountryId = masterPUT.CountryId;
                history.StateId = masterPUT.StateId;
                history.LanguageId = masterPUT.LanguageId;
                history.CalendarId = masterPUT.CalendarId;
                history.ActionTypeId = masterPUT.ActionTypeId;
                history.ExportTypeId = masterPUT.ExportTypeId;
                history.ExportTo = masterPUT.ExportTo;
                history.SourceURL = masterPUT.SourceURL;
                history.Name = masterPUT.Name;
                history.Contact = masterPUT.Contact;
                history.Phone = masterPUT.Phone;
                history.Mobile = masterPUT.Mobile;
                history.Address = masterPUT.Address;
                history.Email = masterPUT.Email;
                history.Website = masterPUT.Website;
                history.Browser = masterPUT.Browser;
                history.Location = masterPUT.Location;
                history.DeviceIP = masterPUT.DeviceIP;
                history.LocationURL = masterPUT.LocationURL;
                history.DeviceName = masterPUT.DeviceName;
                history.Latitude = masterPUT.Latitude;
                history.Longitude = masterPUT.Longitude;
                history.ActionBy = masterPUT.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.TenantHistory.AddAsync(history);
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
