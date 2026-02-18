using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Interfaces.Country;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Repository;

namespace RapidERP.Infrastructure.Services.CountryServices;

public class CountryActivityService(IRepository repository) : ICountryActivity
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Create(CountryActivityPOST masterPOST)
    {
        try
        {
            CountryActivity activity = new();
            activity.CountryId = masterPOST.CountryId;
            activity.ActivityTypeId = masterPOST.ActivityTypeId;
            activity.PageViewStartedAt = masterPOST.PageViewStartedAt;
            activity.PageViewEndedAt = masterPOST.PageViewEndedAt;
            activity.Browser = masterPOST.Browser;
            activity.Location = masterPOST.Location;
            activity.LocationURL = masterPOST.LocationURL;
            activity.DeviceIP = masterPOST.DeviceIP;
            activity.DeviceName = masterPOST.DeviceName;
            activity.OS = masterPOST.OS;
            activity.Latitude = masterPOST.Latitude;
            activity.Longitude = masterPOST.Longitude;

            await repository.Add(activity);

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
                await repository.Set<CountryActivity>().Where(x => x.Id == id).ExecuteDeleteAsync();

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
            var data = (from ca in repository.Set<CountryActivity>()
                        join c in repository.Set<Country>() on ca.CountryId equals c.Id
                        select new
                        {
                            ca.Id,
                            Country = c.Name,
                            ca.ActivityTypeId,
                            ca.PageViewStartedAt,
                            ca.PageViewEndedAt,
                            ca.Browser,
                            ca.Location,
                            ca.LocationURL,
                            ca.DeviceIP,
                            ca.DeviceName,
                            ca.OS,
                            ca.Latitude, 
                            ca.Longitude
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

    public Task<RequestResponse> Update(CountryActivityPUT masterPUT)
    {
        throw new NotImplementedException();
    }
}
