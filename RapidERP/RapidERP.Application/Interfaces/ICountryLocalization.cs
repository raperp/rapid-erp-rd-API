using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface ICountryLocalization : IMaster<CountryLocalizationPOST, CountryLocalizationPUT> 
{
    Task<RequestResponse> ImportLocalization(List<CountryLocalizationPOST> imports);
}
