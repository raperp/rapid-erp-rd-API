using Dapper;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces.Country;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Repository;

namespace RapidERP.Infrastructure.Services.CountryServices;

public class CountryAuditService(IRepository repository) : ICountryAudit
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Create(CountryAuditDTO masterPOST)
    {
        try
        {
            CountryAudit audit = new();
            audit.CountryId = masterPOST.CountryId;
            audit.CurrencyId = masterPOST.CurrencyId;
            audit.LanguageId = masterPOST.LanguageId;
            audit.DefaultCurrencyId = masterPOST.DefaultCurrencyId;
            audit.DefaultLanguageId = masterPOST.DefaultLanguageId;
            audit.StatusTypeId = masterPOST.StatusTypeId;
            audit.ActionTypeId = masterPOST.ActionTypeId;
            audit.Code = masterPOST.Code;
            audit.Name = masterPOST.Name;
            audit.IsDefault = masterPOST.IsDefault;
            audit.ISONumeric = masterPOST.ISONumeric;
            audit.ISO2Code = masterPOST.ISO2Code;
            audit.ISO3Code = masterPOST.ISO3Code;
            audit.FlagURL = masterPOST.FlagURL;
            audit.ActionBy = masterPOST.ActionBy;
            audit.ActionAt = DateTime.UtcNow;

            await repository.Add(audit);

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
                await repository.Delete<CountryAudit>(id);

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
            DynamicParameters parameters = new();
            var query = "SELECT c.Name AS Country, ca.Name, ca.ISO2Code, ca.ISO3Code, ca.ISONumeric, ca.FlagURL, ca.Code, ca.IsDefault, ca.ActionBy, ca.ActionAt, st.Name, act.Name, l.Name, dl.Name AS DefaultLanguage, dcu.Name AS DefaultCurrency FROM CountryAudits ca LEFT JOIN Countries c ON ca.CountryId = c.Id LEFT JOIN Currencies cu ON ca.CurrencyId = cu.Id LEFT JOIN StatusTypes st ON ca.StatusTypeId = st.Id LEFT JOIN ActionTypes act ON ca.ActionTypeId = act.Id LEFT JOIN Languages l ON ca.LanguageId = l.Id LEFT JOIN Languages dl ON ca.DefaultLanguageId = dl.Id LEFT JOIN Currencies dcu ON ca.DefaultCurrencyId = dcu.Id";

            var result = await repository.ConnectDatabase().QueryAsync<dynamic>(query, parameters);

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

    public Task<RequestResponse> Update(CountryAuditDTO masterPUT)
    {
        throw new NotImplementedException();
    }
}
