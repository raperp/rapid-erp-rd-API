using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Interfaces.Country;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services.CountryServices;

public class CountryCaptureService(IRepository repository) : ICountryCapture
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Create(CountryCapturePOST masterPOST)
    {
        try
        {
            CountryCapture masterData = new();
            masterData.CountryId = masterPOST.CountryId;
            masterData.ActivityTypeId = masterPOST.ActivityTypeId;
            masterData.StorageURL = masterPOST.StorageURL;
            masterData.FileHash = masterPOST.FileHash;

            await repository.Add(masterData);

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                IsSuccess = true,
                Message = ResponseMessage.CreateSuccess,
                Data = masterPOST
            };
            
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
            if (id is not 0)
            {
                await repository.Delete<CountryCapture>(id);

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.DeleteSuccess
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
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

    public async Task<RequestResponse> GetAll()
    {
        try
        {
            var data = (from cc in repository.Set<CountryCapture>()
                        join c in repository.Set<Country>() on cc.CountryId equals c.Id 
                        select new
                        {
                            cc.Id,
                            Country = c.Name,
                            cc.StorageURL,
                            cc.FileHash
                        }).AsNoTracking().AsQueryable();

            var result = await data.ToListAsync();

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = result
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

    public Task<RequestResponse> Update(CountryCapturePOST masterPUT)
    {
        throw new NotImplementedException();
    }
}
