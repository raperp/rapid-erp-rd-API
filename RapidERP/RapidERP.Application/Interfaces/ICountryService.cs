using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface ICountryService : IBase<CountryPOST, CountryPUT> 
{
    Task<RequestResponse> GetAllLookupsLocalization();
    Task<RequestResponse> GetAllCurrencies();
    Task<RequestResponse> CreateCurrency(CountryCurrencyPOST currencyPOST);
    Task<RequestResponse> Import(List<CountryImport> imports);
    Task<RequestResponse> UpdateCurrency(CountryCurrencyPUT currencyPUT);
    Task<RequestResponse> DeleteCurrency(int id);
    Task<RequestResponse> CreateCountryCapture(CountryCapturedPOST captured);
    Task<RequestResponse> DeleteCountryCapture(int id);
    Task<RequestResponse> CreateAudit(CountryAudit post);
    Task<RequestResponse> CreateActivity(CountryActivity post);
    Task<RequestResponse> ImportLocalization(List<CountryLocalizationPOST> localizations);
    Task<RequestResponse> ImportCurrency(List<CountryCurrencyPOST> currencyPOSTs);
}