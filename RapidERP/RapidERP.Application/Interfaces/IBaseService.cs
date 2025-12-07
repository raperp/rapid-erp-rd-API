using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Interfaces;

public interface IBaseService<POSTEntity, PUTEntity> where POSTEntity : class 
{
    Task<RequestResponse> GetAll(int skip, int take);
    Task<dynamic> GetSingle(int id);
    Task<RequestResponse> GetHistory(int skip, int take);
    Task<RequestResponse> CreateSingle(POSTEntity masterPOST);
    Task<RequestResponse> CreateBulk(List<POSTEntity> masterPOSTs);
    Task<RequestResponse> Update(PUTEntity masterPUT);
    //Task<RequestResponse> Delete(int id);
    Task<dynamic> SoftDelete(int id);
}
