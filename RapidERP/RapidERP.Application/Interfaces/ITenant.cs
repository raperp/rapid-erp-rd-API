using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.TenantDTOs;

namespace RapidERP.Application.Interfaces;
public interface ITenant : IBase<TenantPOST, TenantPUT, SoftDeleteRestore>
{
    //Task<RequestResponse> GetAll(int skip, int take);
    //Task<RequestResponse> GetSingle(int id);
    //Task<RequestResponse> GetAllAudits(int skip, int take);
    //Task<RequestResponse> CreateSingle(TenantPOST masterPOST);
    //Task<RequestResponse> CreateBulk(List<TenantPOST> masterPOSTs);
    //Task<RequestResponse> Update(TenantPUT masterPUT);
    //Task<RequestResponse> Delete(int id);
}
