using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface ICountry
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<RequestResponse> GetSingle(int id);
    Task<RequestResponse> GetAllAudits(int skip, int take);
    Task<RequestResponse> CreateSingle(CountryPOST masterPOST);
    Task<RequestResponse> CreateBulk(List<CountryPOST> masterPOSTs);
    Task<RequestResponse> Update(CountryPUT masterPUT);
    Task<RequestResponse> Delete(int id);
}
