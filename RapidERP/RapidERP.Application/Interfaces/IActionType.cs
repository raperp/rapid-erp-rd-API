using RapidERP.Application.DTOs.ActionTypeDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface IActionType
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<RequestResponse> GetSingle(int id);
    Task<RequestResponse> GetAllAudits(int skip, int take);
    Task<RequestResponse> CreateSingle(ActionTypePOST masterPOST);
    Task<RequestResponse> CreateBulk(List<ActionTypePOST> masterPOSTs);
    Task<RequestResponse> Update(ActionTypePUT masterPUT);
    Task<RequestResponse> Delete(int id);
}
