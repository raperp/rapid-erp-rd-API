using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.SalesmanDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.SalesmanModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class SalesmanService(RapidERPDbContext context, ISharedService shared) : ISalesmanService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<SalesmanPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(SalesmanPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Salesmen.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Salesman masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.Code = masterPOST.Code;
                masterData.Commission = masterPOST.Commission;
                masterData.Territory = masterPOST.Territory;
                masterData.Experience = masterPOST.Experience;
                masterData.DepartmentId = masterPOST.DepartmentId;
                masterData.ManagerId = masterPOST.ManagerId;
                masterData.Phone = masterPOST.Phone;
                masterData.Email = masterPOST.Email;
                masterData.Description = masterPOST.Description;
                masterData.MenuModuleId = masterPOST.MenuModuleId;
                masterData.TenantId = masterPOST.TenantId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                //masterData.LanguageId = masterPOST.LanguageId;

                await context.Salesmen.AddAsync(masterData);
                //await context.SaveChangesAsync();

                SalesmanHistory history = new();
                history.SalesmanId = masterData.Id;
                history.Name = masterPOST.Name;
                history.Code = masterPOST.Code;
                history.Commission = masterPOST.Commission;
                history.Territory = masterPOST.Territory;
                history.Experience = masterPOST.Experience;
                history.DepartmentId = masterPOST.DepartmentId;
                history.ManagerId = masterPOST.ManagerId;
                history.Phone = masterPOST.Phone;
                history.Email = masterPOST.Email;
                history.Description = masterPOST.Description;
                history.TenantId = masterPOST.TenantId;
                history.MenuModuleId = masterPOST.MenuModuleId;
                history.ActionTypeId = masterPOST.ActionTypeId;
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

                await context.SalesmanHistory.AddAsync(history);
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
            var ishistoryExists = await context.SalesmanHistory.AsNoTracking().AnyAsync(x => x.SalesmanId == id);

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
                await context.SalesmanHistory.Where(x => x.SalesmanId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Salesmen.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.Salesmen.Where(x => x.Id == id).ExecuteDeleteAsync();
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

            var data = (from s in context.Salesmen
                        join st in context.StatusTypes on s.StatusTypeId equals st.Id
                        join d in context.Departments on s.DepartmentId equals d.Id
                        join t in context.Tenants on s.TenantId equals t.Id
                        //join l in context.Languages on s.LanguageId equals l.Id
                        join mm in context.MenuModules on s.MenuModuleId equals mm.Id
                        select new
                        {
                            s.Id,
                            s.Name,
                            s.Code,
                            s.Description,
                            s.Phone,
                            s.Email,
                            s.Territory,
                            s.Experience,
                            Department = d.Name,
                            MenuModule = mm.Name,
                            Tanent = t.Name,
                            //Language = l.Name,
                            Status = st.Name,
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Salesman>(pageSize);
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
                result.Count = await shared.GetCounts<Salesman>(pageSize);
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
            var data = (from sh in context.SalesmanHistory
                        join s in context.Salesmen on sh.SalesmanId equals s.Id
                        join d in context.Departments on sh.DepartmentId equals d.Id
                        //join et in context.ExportTypes on sh.ExportTypeId equals et.Id
                        join at in context.ActionTypes on sh.ActionTypeId equals at.Id
                        join t in context.Tenants on sh.TenantId equals t.Id
                        //join l in context.Languages on sh.LanguageId equals l.Id
                        join mm in context.MenuModules on sh.MenuModuleId equals mm.Id
                        select new
                        {
                            sh.Id,
                            Salesman = s.Name,
                            sh.Name,
                            sh.Code,
                            sh.Commission,
                            sh.Territory,
                            sh.Experience,
                            Department = d.Name,
                            sh.Phone,
                            sh.Email,
                            sh.Description,
                            Tanent = t.Name,
                            MenuModule = mm.Name,
                            Action = at.Name,
                            //Language = l.Name,
                            //ExportType = et.Name,
                            //sh.ExportTo,
                            //sh.SourceURL,
                            sh.IsDefault,
                            sh.IsDraft,
                            //sh.Browser,
                            //sh.Location,
                            //sh.DeviceIP,
                            //sh.LocationURL,
                            //sh.DeviceName,
                            //sh.Latitude,
                            //sh.Longitude,
                            //sh.ActionBy,
                            //sh.ActionAt
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
        var result = await shared.GetSingle<Salesman>(id);
        return result;
    }

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = await shared.SoftDelete<Salesman>(id);
        return result;
    }

    public async Task<RequestResponse> Update(SalesmanPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Salesmen.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Salesmen.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Code, masterPUT.Code)
                .SetProperty(x => x.Commission, masterPUT.Commission)
                .SetProperty(x => x.Territory, masterPUT.Territory)
                .SetProperty(x => x.Experience, masterPUT.Experience)
                .SetProperty(x => x.DepartmentId, masterPUT.DepartmentId)
                .SetProperty(x => x.ManagerId, masterPUT.ManagerId)
                .SetProperty(x => x.Phone, masterPUT.Phone)
                .SetProperty(x => x.Email, masterPUT.Email)
                .SetProperty(x => x.Description, masterPUT.Description)
                .SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                .SetProperty(x => x.TenantId, masterPUT.TenantId)
                .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId));

                SalesmanHistory history = new();
                history.SalesmanId = masterPUT.Id;
                history.Name = masterPUT.Name;
                history.Code = masterPUT.Code;
                history.Commission = masterPUT.Commission;
                history.Territory = masterPUT.Territory;
                history.Experience = masterPUT.Experience;
                history.DepartmentId = masterPUT.DepartmentId;
                history.ManagerId = masterPUT.ManagerId;
                history.Phone = masterPUT.Phone;
                history.Email = masterPUT.Email;
                history.Description = masterPUT.Description;
                history.TenantId = masterPUT.TenantId;
                history.MenuModuleId = masterPUT.MenuModuleId;
                history.ActionTypeId = masterPUT.ActionTypeId;
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

                await context.SalesmanHistory.AddAsync(history);
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
