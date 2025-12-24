using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.LanguageDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class LanguageService(RapidERPDbContext context, ISharedService shared) : ILanguageService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<LanguagePOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(LanguagePOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Languages.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name || x.ISONumeric == masterPOST.ISONumeric || x.ISO2Code == masterPOST.ISO2Code || x.ISO3Code == masterPOST.ISO3Code || x.IconURL == masterPOST.IconURL);

            if (isExists == false)
            {
                Language masterData = new();
                masterData.ISONumeric = masterPOST.ISONumeric;
                masterData.Name = masterPOST.Name;
                masterData.ISO2Code = masterPOST.ISO2Code;
                masterData.ISO3Code = masterPOST.ISO3Code;
                masterData.IconURL = masterPOST.IconURL;

                await context.Languages.AddAsync(masterData);
                await context.SaveChangesAsync();

                LanguageHistory history = new();
                history.LanguageId = masterData.Id;
                history.ISONumeric = masterPOST.ISONumeric;
                history.Name = masterPOST.Name;
                history.ISO2Code = masterPOST.ISO2Code;
                history.ISO3Code = masterPOST.ISO3Code;
                history.IconURL = masterPOST.IconURL;
                history.Browser = masterPOST.Browser;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                history.LocationURL = masterPOST.LocationURL;
                history.DeviceName = masterPOST.DeviceName;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                history.ActionBy = masterPOST.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.LanguageHistory.AddAsync(history);
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
            var ishistoryExists = await context.LanguageHistory.AsNoTracking().AnyAsync(x => x.LanguageId == id);

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
                await context.LanguageHistory.Where(x => x.LanguageId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Languages.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.Languages.Where(x => x.Id == id).ExecuteDeleteAsync();
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
            var data = (from l in context.Languages
                        select new
                        {
                            l.Id,
                            l.ISONumeric, 
                            l.Name,
                            l.ISO2Code,
                            l.ISO3Code,
                            l.IconURL,
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
            var data = (from la in context.LanguageHistory
                        join l in context.Languages on la.LanguageId equals l.Id
                        select new
                        {
                            la.Id,
                            Language = l.Name,
                            la.ISONumeric,
                            la.Name,
                            la.ISO2Code,
                            la.ISO3Code,
                            la.IconURL,
                            la.Browser,
                            la.Location,
                            la.DeviceIP,
                            la.LocationURL,
                            la.DeviceName,
                            la.Latitude,
                            la.Longitude,
                            la.ActionBy,
                            la.ActionAt
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
        var result = await shared.GetSingle<Language>(id);
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

    public async Task<RequestResponse> Update(LanguagePUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Languages.AsNoTracking().AnyAsync(x => (x.Name == masterPUT.Name || x.ISONumeric == masterPUT.ISONumeric || x.ISO2Code == masterPUT.ISO2Code || x.ISO3Code == masterPUT.ISO3Code || x.IconURL == masterPUT.IconURL) && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Languages.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.ISONumeric, masterPUT.ISONumeric)
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.ISO2Code, masterPUT.ISO2Code)
                .SetProperty(x => x.ISO3Code, masterPUT.ISO3Code)
                .SetProperty(x => x.IconURL, masterPUT.IconURL));

                LanguageHistory history = new();
                history.LanguageId = masterPUT.Id;
                history.ISONumeric = masterPUT.ISONumeric;
                history.Name = masterPUT.Name;
                history.ISO2Code = masterPUT.ISO2Code;
                history.ISO3Code = masterPUT.ISO3Code;
                history.IconURL = masterPUT.IconURL;
                history.Browser = masterPUT.Browser;
                history.Location = masterPUT.Location;
                history.DeviceIP = masterPUT.DeviceIP;
                history.LocationURL = masterPUT.LocationURL;
                history.DeviceName = masterPUT.DeviceName;
                history.Latitude = masterPUT.Latitude;
                history.Longitude = masterPUT.Longitude;
                history.ActionBy = masterPUT.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.LanguageHistory.AddAsync(history);
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
