using RapidERP.Application.DTOs.CurrencyDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface ICurrency
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<RequestResponse> GetSingle(int id);
    Task<RequestResponse> GetAllAudits(int skip, int take);
    Task<RequestResponse> CreateSingle(CurrencyPOST masterPOST);
    Task<RequestResponse> CreateBulk(List<CurrencyPOST> masterPOSTs);
    Task<RequestResponse> Update(CurrencyPUT masterPUT);
    Task<RequestResponse> Delete(int id);
}
