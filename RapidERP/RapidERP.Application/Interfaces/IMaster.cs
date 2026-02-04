using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface IMaster<POSTEntity, PUTEntity> where POSTEntity : class
{
    Task<RequestResponse> GetAll();
    Task<RequestResponse> Create(POSTEntity masterPOST);
    Task<RequestResponse> Update(PUTEntity masterPUT);
    Task<RequestResponse> Delete(int id);
}
