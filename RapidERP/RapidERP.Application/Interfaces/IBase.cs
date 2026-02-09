using RapidERP.Application.DTOs.Shared;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface IBase<POSTEntity, PUTEntity> where POSTEntity : class
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<RequestResponse> GetSingle(int id); 
    Task<RequestResponse> CreateSingle(POSTEntity masterPOST);
    //Task<RequestResponse> CreateBulk(List<POSTEntity> masterPOSTs);
    Task<RequestResponse> Update(PUTEntity masterPUT);
    Task<RequestResponse> Delete(int id);
    Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus); 
}
