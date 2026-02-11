using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface ICountryService : IBase<CountryPOST, CountryPUT> 
{
    Task<RequestResponse> GetAllLookupsLocalization();
    Task<RequestResponse> GetAllCurrencies();
    Task<RequestResponse> CreateCurrency(CountryCurrencyPOST currencyPOST);
    Task<RequestResponse> UpdateCurrency(CountryCurrencyPUT currencyPUT);
    Task<RequestResponse> DeleteCurrency(int id);
}  
