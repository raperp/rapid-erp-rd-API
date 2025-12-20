using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Repository;

public interface IRepository<TEntity, PUTEntity> where TEntity : class
{
    Task<RequestResponse> GetAll(int skip, int take, int pageSize);
    Task<dynamic> GetSingle(int id);
    Task<RequestResponse> GetHistory(int skip, int take, int pageSize);
    Task<RequestResponse> CreateSingle(TEntity masterPOST);
    Task<RequestResponse> CreateBulk(List<TEntity> masterPOSTs);
    Task<RequestResponse> Update(PUTEntity masterPUT);
    //Task<RequestResponse> Delete(int id);
    Task<dynamic> SoftDelete(int id);
    Task CommitChanges();
    IQueryable<TEntity> DbSet();
    //Task<dynamic> CreateBulk(List<TEntity> masterPOSTs);
}
