using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.TextModuleDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class TextModuleService(RapidERPDbContext context, ISharedService shared) : ITextModuleService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<TextModulePOST> masterPOSTs)
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

    public async Task<RequestResponse> Create(TextModulePOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.TextModules.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                TextModule masterData = new();
                //masterData.MenuModuleId = masterPOST.MenuModuleId;
                //masterData.LanguageId = masterPOST.LanguageId;
                masterData.Name = masterPOST.Name;

                await context.TextModules.AddAsync(masterData);
                await context.SaveChangesAsync();

                TextModuleHistory history = new();
                history.TextModuleId = masterData.Id;
                //history.MenuModuleId = masterPOST.MenuModuleId;
                //history.LanguageId = masterPOST.LanguageId;
                history.ActionTypeId = masterPOST.ActionTypeId;
                //history.ExportTypeId = masterPOST.ExportTypeId;
                //history.ExportTo = masterPOST.ExportTo;
                //history.SourceURL = masterPOST.SourceURL;
                history.Name = masterPOST.Name;
                //history.Browser = masterPOST.Browser;
                //history.Location = masterPOST.Location;
                //history.DeviceIP = masterPOST.DeviceIP;
                //history.LocationURL = masterPOST.LocationURL;
                //history.DeviceName = masterPOST.DeviceName;
                //history.Latitude = masterPOST.Latitude;
                //history.Longitude = masterPOST.Longitude;
                //history.ActionBy = masterPOST.ActionBy;
                //history.ActionAt = DateTime.Now;

                await context.TextModuleHistory.AddAsync(history);
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

    public Task<RequestResponse> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from tm in context.TextModules
                        //join mm in context.MenuModules on tm.MenuModuleId equals mm.Id
                        //join l in context.Languages on tm.LanguageId equals l.Id
                        select new
                        {
                            tm.Id,
                            //MenuModule = mm.Name,
                            //Language = l.Name,
                            tm.Name
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<TextModule>(pageSize);
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
                result.Count = await shared.GetCounts<TextModule>(pageSize);
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
            var data = (from tma in context.TextModuleHistory
                        join tm in context.TextModules on tma.TextModuleId equals tm.Id
                        //join mm in context.MenuModules on tma.MenuModuleId equals mm.Id
                        join at in context.ActionTypes on tma.ActionTypeId equals at.Id
                        //join l in context.Languages on tma.LanguageId equals l.Id
                        //join et in context.ExportTypes on tma.ExportTypeId equals et.Id
                        select new
                        {
                            tma.Id,
                            TextModule = tm.Name,
                            //MenuModule = mm.Name,
                            //Language = l.Name,
                            Action = at.Name,
                            //ExportType = et.Name,
                            //tma.ExportTo,
                            //tma.SourceURL,
                            tma.Name,
                            //tma.Browser,
                            //tma.Location,
                            //tma.DeviceIP,
                            //tma.LocationURL,
                            //tma.DeviceName,
                            //tma.Latitude,
                            //tma.Longitude,
                            //tma.ActionBy,
                            //tma.ActionAt
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
        var result = await shared.GetSingle<TextModule>(id);
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

    public async Task<RequestResponse> Update(TextModulePUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.TextModules.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                //ActionDTO actionDTO = new();
                //actionDTO.UpdatedBy = (masterPUT.IsDraft == false) ? masterPUT.ActionBy : null;
                //actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.Now : null;
                //actionDTO.DraftedBy = (masterPUT.IsDraft == true) ? masterPUT.ActionBy : null;
                //actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.Now : null;

                await context.TextModules.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                //.SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                //.SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.Name, masterPUT.Name));

                TextModuleHistory history = new();
                history.TextModuleId = masterPUT.Id;
                //history.MenuModuleId = masterPUT.MenuModuleId;
                //history.LanguageId = masterPUT.LanguageId;
                history.ActionTypeId = masterPUT.ActionTypeId;
                //history.ExportTypeId = masterPUT.ExportTypeId;
                //history.ExportTo = masterPUT.ExportTo;
                //history.SourceURL = masterPUT.SourceURL;
                history.Name = masterPUT.Name;
                //history.Browser = masterPUT.Browser;
                //history.Location = masterPUT.Location;
                //history.DeviceIP = masterPUT.DeviceIP;
                //history.LocationURL = masterPUT.LocationURL;
                //history.DeviceName = masterPUT.DeviceName;
                //history.Latitude = masterPUT.Latitude;
                //history.Longitude = masterPUT.Longitude;
                //history.ActionBy = masterPUT.ActionBy;
                //history.ActionAt = DateTime.Now;

                await context.TextModuleHistory.AddAsync(history);
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

    Task<RequestResponse> IBase<TextModulePOST, TextModulePUT>.GetById(int id)
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
