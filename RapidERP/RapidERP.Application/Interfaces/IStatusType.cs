using RapidERP.Application.DTOs.StatusTypeDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface IStatusType
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<RequestResponse> GetSingle(int id);
    Task<RequestResponse> GetAllAudits(int skip, int take);
    Task<RequestResponse> CreateSingle(StatusTypePOST masterPOST);
    Task<RequestResponse> CreateBulk(List<StatusTypePOST> masterPOSTs);
    Task<RequestResponse> Update(StatusTypePUT masterPUT);
    Task<RequestResponse> Delete(int id);
}
