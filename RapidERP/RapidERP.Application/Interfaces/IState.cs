using RapidERP.Application.DTOs.StateDTOs;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;
public interface IState
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<RequestResponse> GetSingle(int id);
    Task<RequestResponse> GetAllAudits(int skip, int take);
    Task<RequestResponse> CreateSingle(StatePOST masterPOST);
    Task<RequestResponse> CreateBulk(List<StatePOST> masterPOSTs);
    Task<RequestResponse> Update(StatePUT masterPUT);
    Task<RequestResponse> Delete(int id);
}
