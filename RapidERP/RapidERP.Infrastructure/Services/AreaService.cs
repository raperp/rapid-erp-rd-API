using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.AreaDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class AreaService(RapidERPDbContext context, ISharedService shared) : IAreaService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<AreaPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(AreaPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Areas.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Area masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.Code = masterPOST.Code;
                masterData.CountryId = masterPOST.CountryId;
                masterData.StateId = masterPOST.StateId;
                masterData.CityId = masterPOST.CityId;
                //masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.TenantId = masterPOST.TenantId;
                //masterData.MenuModuleId = masterPOST.MenuModuleId;
                //masterData.LanguageId = masterPOST.LanguageId;
                masterData.IsDefault = masterPOST.IsDefault;
                masterData.IsDraft = masterPOST.IsDraft;
                

                await context.Areas.AddAsync(masterData);
                //await context.SaveChangesAsync();

                AreaHistory history = new();
                history.AreaId = masterData.Id;
                history.Name = masterPOST.Name;
                history.Code = masterPOST.Code;
                history.CountryId = masterPOST.CountryId;
                history.StateId = masterPOST.StateId;
                history.CityId = masterPOST.CityId;
                //history.TenantId = masterPOST.TenantId;
                //history.ActionTypeId = masterPOST.ActionTypeId;
                //history.MenuModuleId = masterPOST.MenuModuleId;
                //history.LanguageId = masterPOST.LanguageId;
                //history.ExportTypeId = masterPOST.ExportTypeId;
                //history.ExportTo = masterPOST.ExportTo;
                //history.SourceURL = masterPOST.SourceURL;
                history.IsDefault = masterPOST.IsDefault;
                history.IsDraft = masterPOST.IsDraft;
                //history.Browser = masterPOST.Browser;
                //history.Location = masterPOST.Location;
                //history.DeviceIP = masterPOST.DeviceIP;
                //history.LocationURL = masterPOST.LocationURL;
                //history.DeviceName = masterPOST.DeviceName;
                //history.Latitude = masterPOST.Latitude;
                //history.Longitude = masterPOST.Longitude;
                //history.ActionBy = masterPOST.ActionBy;
                //history.ActionAt = DateTime.Now;

                await context.AreaHistory.AddAsync(history);
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
            var ishistoryExists = await context.AreaHistory.AsNoTracking().AnyAsync(x => x.AreaId == id);

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
                await context.AreaHistory.Where(x => x.AreaId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Areas.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.Areas.Where(x => x.Id == id).ExecuteDeleteAsync();
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

            var data = (from a in context.Areas
                        //join st in context.StatusTypes on a.StatusTypeId equals st.Id
                        join co in context.Countries on a.CountryId equals co.Id
                        join sta in context.States on a.StateId equals sta.Id
                        join ci in context.Cities on a.CityId equals ci.Id
                        //join mm in context.MenuModules on a.MenuModuleId equals mm.Id
                        join t in context.Tenants on a.TenantId equals t.Id
                        //join l in context.Languages on a.LanguageId equals l.Id
                        select new
                        {
                            a.Id,
                            a.Name,
                            a.Code,
                            Tanent = t.Name,
                            //Language = l.Name,
                            //MenuModule = mm.Name,
                            Country = co.Name,
                            State = sta.Name,
                            //Status = st.Name,
                            City = ci.Name
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Area>(pageSize);
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
                result.Count = await shared.GetCounts<Area>(pageSize);
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

    public Task<RequestResponse> GetAll(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    {
        try
        {
            var data = (from aa in context.AreaHistory
                        join a in context.Areas on aa.AreaId equals a.Id
                        join c in context.Countries on aa.CountryId equals c.Id
                        join sta in context.States on aa.StateId equals sta.Id
                        join cit in context.Cities on aa.CityId equals cit.Id
                        //join mm in context.MenuModules on aa.MenuModuleId equals mm.Id
                        //join t in context.Tenants on aa.TenantId equals t.Id
                        //join l in context.Languages on aa.LanguageId equals l.Id
                        join at in context.ActionTypes on aa.ActionTypeId equals at.Id
                        //join et in context.ExportTypes on aa.ExportTypeId equals et.Id
                        select new
                        {
                            aa.Id,
                            aa.Name,
                            aa.Code,
                            Country = c.Name,
                            State = sta.Name,
                            City = cit.Name,
                            //Tanent = t.Name,
                            //Language = l.Name,
                            //MenuModule = mm.Name,
                            ActionType = at.Name,
                            //ExportType = et.Name,
                            //aa.ExportTo,
                            //aa.SourceURL,
                            //aa.Browser,
                            //aa.Location,
                            //aa.DeviceIP,
                            //aa.LocationURL,
                            //aa.DeviceName,
                            //aa.Latitude,
                            //aa.Longitude,
                            //aa.ActionBy,
                            //aa.ActionAt
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
        var result = await shared.GetSingle<Area>(id);
        return result;
    }

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> Lookup()
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> Restore(int id)
    {
        throw new NotImplementedException();
    }

    public Task<dynamic> SoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> Update(AreaPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Areas.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Areas.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Code, masterPUT.Code)
                .SetProperty(x => x.CountryId, masterPUT.CountryId)
                .SetProperty(x => x.StateId, masterPUT.StateId)
                .SetProperty(x => x.CityId, masterPUT.CityId)
                //.SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                .SetProperty(x => x.TenantId, masterPUT.TenantId)
                //.SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                //.SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.IsDefault, masterPUT.IsDefault)
                .SetProperty(x => x.IsDraft, masterPUT.IsDraft));

                AreaHistory history = new();
                history.AreaId = masterPUT.Id;
                history.Name = masterPUT.Name;
                history.Code = masterPUT.Code;
                history.CountryId = masterPUT.CountryId;
                history.StateId = masterPUT.StateId;
                history.CityId = masterPUT.CityId;
                //history.TenantId = masterPUT.TenantId;
                //history.ActionTypeId = masterPUT.ActionTypeId;
                //history.MenuModuleId = masterPUT.MenuModuleId;
                //history.LanguageId = masterPUT.LanguageId;
                //history.ExportTypeId = masterPUT.ExportTypeId;
                //history.ExportTo = masterPUT.ExportTo;
                //history.SourceURL = masterPUT.SourceURL;
                history.IsDefault = masterPUT.IsDefault;
                history.IsDraft = masterPUT.IsDraft;
                //history.Browser = masterPUT.Browser;
                //history.Location = masterPUT.Location;
                //history.DeviceIP = masterPUT.DeviceIP;
                //history.LocationURL = masterPUT.LocationURL;
                //history.DeviceName = masterPUT.DeviceName;
                //history.Latitude = masterPUT.Latitude;
                //history.Longitude = masterPUT.Longitude;
                //history.ActionBy = masterPUT.ActionBy;
                //history.ActionAt = DateTime.Now;

                await context.AreaHistory.AddAsync(history);
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

    public Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus)
    {
        throw new NotImplementedException();
    }

    Task<RequestResponse> IBase<AreaPOST, AreaPUT>.Create(AreaPOST masterPOST)
    {
        throw new NotImplementedException();
    }

    Task<RequestResponse> IBase<AreaPOST, AreaPUT>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<RequestResponse> IBase<AreaPOST, AreaPUT>.GetAll(int skip, int take)
    {
        throw new NotImplementedException();
    }

    

    Task<RequestResponse> IBase<AreaPOST, AreaPUT>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    

    Task<RequestResponse> IBase<AreaPOST, AreaPUT>.Update(AreaPUT masterPUT)
    {
        throw new NotImplementedException();
    }
}
