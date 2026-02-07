using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services.CountryServices;

public class CountryExportService(IRepository repository) : ICountryExport
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Create(CountryExportDTO masterPOST)
    {
        try
        {
            CountryExport masterData = new(); 
            masterData.CountryId = masterPOST.CountryId; 
            masterData.ExportMediaId = masterPOST.ExportMediaId; 
            masterData.ExportMediaTo = masterPOST.ExportMediaTo; 
            masterData.ExportMediaURL = masterPOST.ExportMediaURL; 
            masterData.ActionTypeId = masterPOST.ActionTypeId; 
            masterData.ActionBy = masterPOST.ActionBy; 
            masterData.ActionAt = masterPOST.ActionAt;

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
                await repository.Delete<CountryExport>(id);

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
            var data = (from ce in repository.Set<CountryExport>()
                        join c in repository.Set<Country>() on ce.CountryId equals c.Id
                        select new
                        {
                            ce.Id,
                            ce.Name,
                            Country = c.Name,
                            ce.ExportMediaTo,
                            ce.ExportMediaURL,
                            ce.ActionAt,
                            ce.ActionBy
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

    public async Task<RequestResponse> Update(CountryExportDTO masterPUT)
    {
        throw new NotImplementedException();
    }
}
