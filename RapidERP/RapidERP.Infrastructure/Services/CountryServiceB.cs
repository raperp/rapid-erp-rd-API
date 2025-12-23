using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Infrastructure.Services;

public class CountryServiceB(IRepository repository) : ICountry
{
    public Task<RequestResponse> CreateBulk(List<Country> masterPOSTs)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> CreateSingle(Country masterPOST)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<dynamic> GetSingle(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public Task<dynamic> SoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> Update(Country masterPUT)
    {
        throw new NotImplementedException();
    }
}
