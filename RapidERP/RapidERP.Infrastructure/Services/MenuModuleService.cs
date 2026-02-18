using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.MenuModuleDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class MenuModuleService(RapidERPDbContext context, ISharedService shared) : IMenuModuleService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<MenuModulePOST> masterPOSTs)
    {
        try
        {
            requestResponse = new();

            foreach (var masterPOST in masterPOSTs)
            {
                var task = Create(masterPOST);
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

    public async Task<RequestResponse> Create(MenuModulePOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.MenuModules.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                MenuModule masterData = new();
                masterData.SubmoduleId = masterPOST.SubmoduleId;
                //masterData.LanguageId = masterPOST.LanguageId;
                masterData.Name = masterPOST.Name;
                masterData.IconURL = masterPOST.IconURL;
                masterData.SetSerial = masterPOST.SetSerial;

                await context.MenuModules.AddAsync(masterData);
                await context.SaveChangesAsync();

                MenuModuleHistory history = new();
                history.MenuModuleId = masterData.Id;
                history.SubmoduleId = masterPOST.SubmoduleId;
                //history.LanguageId = masterPOST.LanguageId;
                history.ActionTypeId = masterPOST.ActionTypeId;
                //history.ExportTypeId = masterPOST.ExportTypeId;
                //history.ExportTo = masterPOST.ExportTo;
                //history.SourceURL = masterPOST.SourceURL;
                history.Name = masterPOST.Name;
                history.IconURL = masterPOST.IconURL;
                history.SetSerial = masterPOST.SetSerial;
                //history.Browser = masterPOST.Browser;
                //history.Location = masterPOST.Location;
                //history.DeviceIP = masterPOST.DeviceIP;
                //history.LocationURL = masterPOST.LocationURL;
                //history.DeviceName = masterPOST.DeviceName;
                //history.Latitude = masterPOST.Latitude;
                //history.Longitude = masterPOST.Longitude;
                //history.ActionBy = masterPOST.ActionBy;
                //history.ActionAt = DateTime.Now;

                await context.MenuModuleHistory.AddAsync(history);
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
            var ishistoryExists = await context.MenuModuleHistory.AsNoTracking().AnyAsync(x => x.MenuModuleId == id);

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
                await context.MenuModuleHistory.Where(x => x.MenuModuleId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.MenuModules.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.MenuModules.Where(x => x.Id == id).ExecuteDeleteAsync();
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

            var data = (from mm in context.MenuModules
                        join sm in context.Submodules on mm.SubmoduleId equals sm.Id
                        //join l in context.Languages on mm.LanguageId equals l.Id
                        select new
                        {
                            mm.Id,
                            Submodule = sm.Name,
                            //Language = l.Name,
                            mm.Name,
                            mm.IconURL,
                            mm.SetSerial
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<MenuModule>(pageSize);
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
                result.Count = await shared.GetCounts<MenuModule>(pageSize);
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
            var data = (from mma in context.MenuModuleHistory
                        join mm in context.MenuModules on mma.MenuModuleId equals mm.Id
                        join at in context.ActionTypes on mma.ActionTypeId equals at.Id
                        join sm in context.Submodules on mma.SubmoduleId equals sm.Id
                        //join l in context.Languages on mma.LanguageId equals l.Id
                        //join et in context.ExportTypes on mma.ExportTypeId equals et.Id
                        select new
                        {
                            mma.Id,
                            MainModule = mm.Name,
                            Submodule = mm.Name,
                            //Language = l.Name,
                            Action = at.Name,
                            //ExportType = et.Name,
                            //mma.ExportTo,
                            //mma.SourceURL,
                            mma.Name,
                            mma.IconURL,
                            mma.SetSerial,
                            //mma.Browser,
                            //mma.Location,
                            //mma.DeviceIP,
                            //mma.LocationURL,
                            //mma.DeviceName,
                            //mma.Latitude,
                            //mma.Longitude,
                            //mma.ActionBy,
                            //mma.ActionAt
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
        var result = await shared.GetSingle<MenuModule>(id);
        return result;
    }

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = "Not Applicable";
        return result;
    }

    public async Task<RequestResponse> Update(MenuModulePUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.MenuModules.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                //ActionDTO actionDTO = new();
                //actionDTO.UpdatedBy = (masterPUT.IsDraft == false) ? masterPUT.ActionBy : null;
                //actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.Now : null;
                //actionDTO.DraftedBy = (masterPUT.IsDraft == true) ? masterPUT.ActionBy : null;
                //actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.Now : null;

                await context.MenuModules.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.SubmoduleId, masterPUT.SubmoduleId)
                //.SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.IconURL, masterPUT.IconURL)
                .SetProperty(x => x.SetSerial, masterPUT.SetSerial));

                MenuModuleHistory history = new();
                history.MenuModuleId = masterPUT.Id;
                history.SubmoduleId = masterPUT.SubmoduleId;
                //history.LanguageId = masterPUT.LanguageId;
                history.ActionTypeId = masterPUT.ActionTypeId;
                //history.ExportTypeId = masterPUT.ExportTypeId;
                //history.ExportTo = masterPUT.ExportTo;
                //history.SourceURL = masterPUT.SourceURL;
                history.Name = masterPUT.Name;
                history.IconURL = masterPUT.IconURL;
                history.SetSerial = masterPUT.SetSerial;
                //history.Browser = masterPUT.Browser;
                //history.Location = masterPUT.Location;
                //history.DeviceIP = masterPUT.DeviceIP;
                //history.LocationURL = masterPUT.LocationURL;
                //history.DeviceName = masterPUT.DeviceName;
                //history.Latitude = masterPUT.Latitude;
                //history.Longitude = masterPUT.Longitude;
                //history.ActionBy = masterPUT.ActionBy;
                //history.ActionAt = DateTime.Now;

                await context.MenuModuleHistory.AddAsync(history);
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

    Task<RequestResponse> IBase<MenuModulePOST, MenuModulePUT>.GetById(int id)
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

    public Task<RequestResponse> Import(List<CountryImport> imports)
    {
        throw new NotImplementedException();
    }
}
