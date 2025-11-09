using RapidERP.Application.DTOs.TenantDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface ITenant
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<RequestResponse> GetSingle(int id);
    Task<RequestResponse> GetAllAudits(int skip, int take);
    Task<RequestResponse> CreateSingle(TenantPOST masterPOST);
    Task<RequestResponse> CreateBulk(List<TenantPOST> masterPOSTs);
    Task<RequestResponse> Update(TenantPUT masterPUT);
    Task<RequestResponse> Delete(int id);
}
