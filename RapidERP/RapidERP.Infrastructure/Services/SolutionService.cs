using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.SolutionDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.CalendarModels;
using RapidERP.Domain.Entities.SolutionModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class SolutionService(RapidERPDbContext context, IShared shared) : ISolution
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<SolutionPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(SolutionPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Solutions.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Solution masterData = new();
                masterData.TenantId = masterPOST.TenantId;
                masterData.MenuModuleId = masterPOST.MenuModuleId;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.Code = masterPOST.Code;
                masterData.Name = masterPOST.Name;
                masterData.Icon = masterPOST.Icon;
                masterData.Description = masterPOST.Description;

                await context.Solutions.AddAsync(masterData);
                await context.SaveChangesAsync();

                SolutionHistory audit = new();
                audit.SolutionId = masterData.Id;
                audit.TenantId = masterPOST.TenantId;
                audit.MenuModuleId = masterPOST.MenuModuleId;
                audit.LanguageId = masterPOST.LanguageId;
                audit.ActionTypeId = masterPOST.ActionTypeId;
                audit.ExportTypeId = masterPOST.ExportTypeId;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.Code = masterPOST.Code;
                audit.Name = masterPOST.Name;
                audit.Icon = masterPOST.Icon;
                audit.Description = masterPOST.Description;
                audit.Browser = masterPOST.Browser;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                audit.LocationURL = masterPOST.LocationURL;
                audit.DeviceName = masterPOST.DeviceName;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                audit.ActionBy = masterPOST.ActionBy;
                audit.ActionAt = DateTime.Now;

                await context.SolutionHistory.AddAsync(audit);
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

    public async Task<RequestResponse> GetAll(int skip, int take)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from c in context.Solutions
                        join t in context.Tenants on c.TenantId equals t.Id
                        join mm in context.MenuModules on c.MenuModuleId equals mm.Id
                        join l in context.Languages on c.LanguageId equals l.Id
                        join st in context.StatusTypes on c.StatusTypeId equals st.Id

                        select new
                        {
                            c.Id,
                            Tenant = t.Name,
                            MenuModule = mm.Name,
                            Language = l.Name,
                            Status = st.Name,
                            c.Code,
                            c.Name,
                            c.Icon,
                            c.Description
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Solution>();
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
                result.Count = await shared.GetCounts<Solution>();
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

    public async Task<RequestResponse> GetHistory(int skip, int take)
    {
        try
        {
            var data = (from sh in context.SolutionHistory
                        join s in context.Solutions on sh.SolutionId equals s.Id
                        join t in context.Tenants on sh.TenantId equals t.Id
                        join mm in context.MenuModules on sh.MenuModuleId equals mm.Id
                        join l in context.Languages on sh.LanguageId equals l.Id
                        join at in context.ActionTypes on sh.ActionTypeId equals at.Id
                        join et in context.ExportTypes on sh.ExportTypeId equals et.Id
                        select new
                        {
                            sh.Id,
                            Currency = s.Name,
                            Tenant = t.Name,
                            MenuModule = mm.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            sh.ExportTo,
                            sh.SourceURL,
                            sh.Code,
                            sh.Name,
                            sh.Icon,
                            sh.Description,
                            sh.Browser,
                            sh.Location,
                            sh.DeviceIP,
                            sh.LocationURL,
                            sh.DeviceName,
                            sh.Latitude,
                            sh.Longitude,
                            sh.ActionBy,
                            sh.ActionAt
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
        var result = await shared.GetSingle<Solution>(id);
        return result;
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = await shared.SoftDelete<Solution>(id);
        return result;
    }

    public async Task<RequestResponse> Update(SolutionPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Solutions.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Solutions.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.TenantId, masterPUT.TenantId)
                .SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                .SetProperty(x => x.Code, masterPUT.Code)
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Icon, masterPUT.Icon)
                .SetProperty(x => x.Description, masterPUT.Description));

                SolutionHistory audit = new();
                audit.SolutionId = masterPUT.Id;
                audit.TenantId = masterPUT.TenantId;
                audit.MenuModuleId = masterPUT.MenuModuleId;
                audit.LanguageId = masterPUT.LanguageId;
                audit.ActionTypeId = masterPUT.ActionTypeId;
                audit.ExportTypeId = masterPUT.ExportTypeId;
                audit.ExportTo = masterPUT.ExportTo;
                audit.SourceURL = masterPUT.SourceURL;
                audit.Code = masterPUT.Code;
                audit.Name = masterPUT.Name;
                audit.Icon = masterPUT.Icon;
                audit.Description = masterPUT.Description;
                audit.Browser = masterPUT.Browser;
                audit.Location = masterPUT.Location;
                audit.DeviceIP = masterPUT.DeviceIP;
                audit.LocationURL = masterPUT.LocationURL;
                audit.DeviceName = masterPUT.DeviceName;
                audit.Latitude = masterPUT.Latitude;
                audit.Longitude = masterPUT.Longitude;
                audit.ActionBy = masterPUT.ActionBy;
                audit.ActionAt = DateTime.Now;

                await context.SolutionHistory.AddAsync(audit);
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
