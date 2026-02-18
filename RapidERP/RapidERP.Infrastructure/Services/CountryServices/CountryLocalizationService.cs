using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Interfaces.Country;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services.CountryServices;

public class CountryLocalizationService(IRepository repository) : ICountryLocalization
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Create(CountryLocalizationPOST masterPOST)
    {
        try
        {
            var isExists = await repository.IsExistsByName<CountryLocalization>(masterPOST.Name);

            if (isExists == false)
            {
                CountryLocalization masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.CountryId = masterPOST.CountryId;
                masterData.LanguageId = masterPOST.LanguageId;

                await repository.Add(masterData);

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
            if (id is not 0)
            {
                await repository.Delete<CountryLocalization>(id);

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
            var data = (from cl in repository.Set<CountryLocalization>()
                        join c in repository.Set<Country>() on cl.CountryId equals c.Id
                        join l in repository.Set<Language>() on cl.LanguageId equals l.Id
                        select new
                        {
                            cl.Id,
                            cl.Name,
                            Language = l.Name,
                            Country = c.Name
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

    public async Task<RequestResponse> Update(CountryLocalizationPUT masterPUT)
    {
        try
        {
            var isExists = await repository.IsExistsByIdName<CountryLocalization>(masterPUT.Id, masterPUT.Name);
            var masterRecord = await repository.FindById<CountryLocalization>(masterPUT.Id);

            if (masterRecord is not null)
            {
                masterPUT.Name = (masterPUT.Name is not null) ? masterPUT.Name : masterRecord.Name;
                masterPUT.CountryId = (masterPUT.CountryId != 0) ? masterPUT.CountryId : masterRecord.CountryId;
                masterPUT.LanguageId = (masterPUT.LanguageId != 0) ? masterPUT.LanguageId : masterRecord.LanguageId;
            }

            if (isExists == false)
            {
                masterRecord.Name = masterPUT.Name;
                masterRecord.CountryId = masterPUT.CountryId;
                masterRecord.LanguageId = masterPUT.LanguageId;

                await repository.Update(masterRecord);

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = masterPUT
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = $"{ResponseMessage.RecordExists} {masterPUT.Name}"
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
