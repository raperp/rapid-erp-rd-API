using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface ICountryService : IBase<CountryPOST, CountryPUT> 
{
    Task<RequestResponse> GetAllLookupsLocalization();
}  
