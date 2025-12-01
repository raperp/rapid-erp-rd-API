using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.MainModuleDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class MainModuleService(RapidERPDbContext context, IShared shared) : IMainModule
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<MainModulePOST> masterPOSTs)
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

            //requestResponse = new()
            //{
            //    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
            //    IsSuccess = true,
            //    Message = ResponseMessage.CreateSuccess,
            //    Data = masterPOSTs
            //};

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

    public async Task<RequestResponse> CreateSingle(MainModulePOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.MainModules.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                MainModule masterData = new();
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.Name = masterPOST.Name;
                masterData.Prefix = masterPOST.Prefix;
                masterData.IconURL = masterPOST.IconURL;
                masterData.SetSerial = masterPOST.SetSerial;

                await context.MainModules.AddAsync(masterData);
                await context.SaveChangesAsync();

                MainModuleHistory audit = new();
                audit.MainModuleId = masterData.Id;
                audit.LanguageId = masterPOST.LanguageId;
                audit.ActionTypeId = masterPOST.ActionTypeId;
                audit.ExportTypeId = masterPOST.ExportTypeId;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.Name = masterPOST.Name;
                audit.Prefix = masterPOST.Prefix;
                audit.IconURL = masterPOST.IconURL;
                audit.SetSerial = masterPOST.SetSerial;
                audit.Browser = masterPOST.Browser;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                audit.LocationURL = masterPOST.LocationURL;
                audit.DeviceName = masterPOST.DeviceName;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                audit.ActionBy = masterPOST.ActionBy;
                audit.ActionAt = DateTime.Now;

                await context.MainModuleAudits.AddAsync(audit);
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
            var isAuditExists = await context.MainModuleAudits.AsNoTracking().AnyAsync(x => x.MainModuleId == id);

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
                await context.MainModuleAudits.Where(x => x.MainModuleId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.MainModules.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.MainModules.Where(x => x.Id == id).ExecuteDeleteAsync();
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

            var data = (from mm in context.MainModules
                        join l in context.Languages on mm.LanguageId equals l.Id
                        select new
                        {
                            mm.Id,
                            Language = l.Name,
                            mm.Name,
                            mm.Prefix,
                            mm.IconURL,
                            mm.SetSerial
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<MainModule>();
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
                result.Count = await shared.GetCounts<MainModule>();
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
            var data = (from mma in context.MainModuleAudits
                        join mm in context.MainModules on mma.MainModuleId equals mm.Id
                        join l in context.Languages on mma.LanguageId equals l.Id
                        join at in context.ActionTypes on mma.ActionTypeId equals at.Id
                        join et in context.ExportTypes on mma.ExportTypeId equals et.Id
                        select new
                        {
                            mma.Id,
                            MainModule = mm.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            mma.ExportTo,
                            mma.SourceURL,
                            mma.Name,
                            mma.Prefix,
                            mma.IconURL,
                            mma.SetSerial,
                            mma.Browser,
                            mma.Location,
                            mma.DeviceIP,
                            mma.LocationURL,
                            mma.DeviceName,
                            mma.Latitude,
                            mma.Longitude,
                            mma.ActionBy,
                            mma.ActionAt
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
        var result = await shared.GetSingle<MainModule>(id);
        return result;
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = "Not Applicable";
        return result;
    }

    public async Task<RequestResponse> Update(MainModulePUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.MainModules.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                ActionDTO actionDTO = new();
                actionDTO.UpdatedBy = (masterPUT.IsDraft == false) ? masterPUT.ActionBy : null;
                actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.Now : null;
                actionDTO.DraftedBy = (masterPUT.IsDraft == true) ? masterPUT.ActionBy : null;
                actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.Now : null;

                await context.MainModules.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Prefix, masterPUT.Prefix)
                .SetProperty(x => x.IconURL, masterPUT.IconURL)
                .SetProperty(x => x.SetSerial, masterPUT.SetSerial));

                MainModuleHistory audit = new();
                audit.MainModuleId = masterPUT.Id;
                audit.LanguageId = masterPUT.LanguageId;
                audit.ActionTypeId = masterPUT.ActionTypeId;
                audit.ExportTypeId = masterPUT.ExportTypeId;
                audit.ExportTo = masterPUT.ExportTo;
                audit.SourceURL = masterPUT.SourceURL;
                audit.Name = masterPUT.Name;
                audit.Prefix = masterPUT.Prefix;
                audit.IconURL = masterPUT.IconURL;
                audit.SetSerial = masterPUT.SetSerial;
                audit.Browser = masterPUT.Browser;
                audit.Location = masterPUT.Location;
                audit.DeviceIP = masterPUT.DeviceIP;
                audit.LocationURL = masterPUT.LocationURL;
                audit.DeviceName = masterPUT.DeviceName;
                audit.Latitude = masterPUT.Latitude;
                audit.Longitude = masterPUT.Longitude;
                audit.ActionBy = masterPUT.ActionBy;
                audit.ActionAt = DateTime.Now;

                await context.MainModuleAudits.AddAsync(audit);
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
