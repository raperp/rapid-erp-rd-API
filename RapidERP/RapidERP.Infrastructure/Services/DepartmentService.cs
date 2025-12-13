using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.DepartmentDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class DepartmentService(RapidERPDbContext context, ISharedService shared) : IDepartmentService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<DepartmentPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(DepartmentPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Departments.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Department masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.Description = masterPOST.Description;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.TenantId = masterPOST.TenantId;
                masterData.MenuModuleId = masterPOST.MenuModuleId;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.IsDefault = masterPOST.IsDefault;
                masterData.IsDraft = masterPOST.IsDraft;

                await context.Departments.AddAsync(masterData);
                //await context.SaveChangesAsync();

                DepartmentHistory history = new();
                history.DepartmentId = masterData.Id;
                history.Name = masterPOST.Name;
                history.Description = masterPOST.Description;
                history.TenantId = masterPOST.TenantId;
                history.MenuModuleId = masterPOST.MenuModuleId;
                history.LanguageId = masterPOST.LanguageId;
                history.ActionTypeId = masterPOST.ActionTypeId;
                history.ExportTypeId = masterPOST.ExportTypeId;
                history.ExportTo = masterPOST.ExportTo;
                history.SourceURL = masterPOST.SourceURL;
                history.IsDefault = masterPOST.IsDefault;
                history.IsDraft = masterPOST.IsDraft;
                history.Browser = masterPOST.Browser;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                history.LocationURL = masterPOST.LocationURL;
                history.DeviceName = masterPOST.DeviceName;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                history.ActionBy = masterPOST.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.DepartmentHistory.AddAsync(history);
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
            var ishistoryExists = await context.DepartmentHistory.AsNoTracking().AnyAsync(x => x.DepartmentId == id);

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
                await context.DepartmentHistory.Where(x => x.DepartmentId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Departments.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.Departments.Where(x => x.Id == id).ExecuteDeleteAsync();
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

            var data = (from d in context.Departments
                        join st in context.StatusTypes on d.StatusTypeId equals st.Id
                        join t in context.Tenants on d.TenantId equals t.Id
                        join l in context.Languages on d.LanguageId equals l.Id
                        join mm in context.MenuModules on d.MenuModuleId equals mm.Id
                        select new
                        {
                            d.Id,
                            d.Name,
                            d.Description,
                            MenuModule = mm.Name,
                            Tanent = t.Name,
                            Language = l.Name,
                            Status = st.Name
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Department>(pageSize);
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
                result.Count = await shared.GetCounts<Department>(pageSize);
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
            var data = (from dh in context.DepartmentHistory
                        join d in context.Departments on dh.DepartmentId equals d.Id
                        join et in context.ExportTypes on dh.ExportTypeId equals et.Id
                        join at in context.ActionTypes on dh.ActionTypeId equals at.Id
                        join t in context.Tenants on dh.TenantId equals t.Id
                        join l in context.Languages on dh.LanguageId equals l.Id
                        join mm in context.MenuModules on dh.MenuModuleId equals mm.Id
                        select new
                        {
                            dh.Id,
                            Department = d.Name,
                            dh.Name,
                            dh.Description,
                            Tanent = t.Name,
                            MenuModule = mm.Name,
                            Action = at.Name,
                            Language = l.Name,
                            ExportType = et.Name,
                            dh.ExportTo,
                            dh.SourceURL,
                            dh.IsDefault,
                            dh.IsDraft,
                            dh.Browser,
                            dh.Location,
                            dh.DeviceIP,
                            dh.LocationURL,
                            dh.DeviceName,
                            dh.Latitude,
                            dh.Longitude,
                            dh.ActionBy,
                            dh.ActionAt
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
        var result = await shared.GetSingle<Department>(id);
        return result;
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = await shared.SoftDelete<Department>(id);
        return result;
    }

    public async Task<RequestResponse> Update(DepartmentPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Departments.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Departments.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Description, masterPUT.Description)
                .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                .SetProperty(x => x.TenantId, masterPUT.TenantId)
                .SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.IsDefault, masterPUT.IsDefault)
                .SetProperty(x => x.IsDraft, masterPUT.IsDraft));

                DepartmentHistory history = new();
                history.DepartmentId = masterPUT.Id;
                history.Name = masterPUT.Name;
                history.Description = masterPUT.Description;
                history.TenantId = masterPUT.TenantId;
                history.MenuModuleId = masterPUT.MenuModuleId;
                history.LanguageId = masterPUT.LanguageId;
                history.ActionTypeId = masterPUT.ActionTypeId;
                history.ExportTypeId = masterPUT.ExportTypeId;
                history.ExportTo = masterPUT.ExportTo;
                history.SourceURL = masterPUT.SourceURL;
                history.IsDefault = masterPUT.IsDefault;
                history.IsDraft = masterPUT.IsDraft;
                history.Browser = masterPUT.Browser;
                history.Location = masterPUT.Location;
                history.DeviceIP = masterPUT.DeviceIP;
                history.LocationURL = masterPUT.LocationURL;
                history.DeviceName = masterPUT.DeviceName;
                history.Latitude = masterPUT.Latitude;
                history.Longitude = masterPUT.Longitude;
                history.ActionBy = masterPUT.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.DepartmentHistory.AddAsync(history);
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
