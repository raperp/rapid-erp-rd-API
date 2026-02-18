using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Interfaces.Country;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services.CountryServices;

public class CountryCurrencyService(IRepository repository)  : ICountryCurrency
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Create(CountryCurrencyPOST masterPOST)
    {
        try
        {
            var countryCurrencyIds = await repository.Set<CountryCurrency>().Where(c => c.CurrencyId == masterPOST.CurrencyId).Select(x => x.Id).ToListAsync();
            
            if (countryCurrencyIds.Count() == 0)
            {
                CountryCurrency masterData = new();
                masterData.CountryId = masterPOST.CountryId;
                masterData.CurrencyId = masterPOST.CurrencyId;

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
                    Message = $"{ResponseMessage.RecordExists} currency id {masterPOST.CurrencyId}"
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
                await repository.Delete<CountryCurrency>(id);

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
            var data = (from cc in repository.Set<CountryCurrency>()
                        join c in repository.Set<Country>() on cc.CountryId equals c.Id
                        join cu in repository.Set<Currency>() on cc.CurrencyId equals cu.Id
                        select new
                        {
                            cc.Id,
                            Currency = cu.Name,
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

    public async Task<RequestResponse> Update(CountryCurrencyPUT masterPUT)
    {
        try
        {
            var countryCurrencyIds = await repository.Set<CountryCurrency>().Where(c => c.CurrencyId == masterPUT.CurrencyId).Select(x => x.Id).ToListAsync();
            var masterRecord = await repository.FindById<CountryCurrency>(masterPUT.Id);

            if (masterRecord is not null)
            {
                masterPUT.CountryId = (masterPUT.CountryId != 0) ? masterPUT.CountryId : masterRecord.CountryId;
                masterPUT.CurrencyId = (masterPUT.CurrencyId != 0) ? masterPUT.CurrencyId : masterRecord.CurrencyId;
            }

            if (countryCurrencyIds.Count() == 0)
            {
                masterRecord.CountryId = masterPUT.CountryId;
                masterRecord.CurrencyId = masterPUT.CurrencyId;

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
                    Message = $"{ResponseMessage.RecordExists} currency id {masterPUT.CurrencyId}"
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
