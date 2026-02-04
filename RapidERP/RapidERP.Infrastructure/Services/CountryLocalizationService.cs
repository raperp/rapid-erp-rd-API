using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services;

public class CountryLocalizationService(IRepository repository) : ICountryLocalization
{
    public async Task<RequestResponse> Create(CountryLocalizationPOST masterPOST)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> Update(CountryLocalizationPUT masterPUT)
    {
        throw new NotImplementedException();
    }
}
