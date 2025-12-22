using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Repository;

//public interface IRepository<T> where T : class
public interface IRepository
{
    //Task<IReadOnlyList<T>> GetAll(int skip, int take, int pageSize);
    //Task<T> GetSingle(int id);
    ////Task<IReadOnlyList<T>> GetHistory(int skip, int take, int pageSize);
    //Task<IReadOnlyList<T>> GetTemplate();
    //Task<T> CreateSingle(T masterPOST);
    //Task<IReadOnlyList<T>> CreateBulk(List<T> masterPOSTs);
    //Task<T> Update(T masterPUT);
    //Task  Delete(int id);
    
    ///
    Task<dynamic> FindById<TEntity>(TEntity entity) where TEntity : Master;
    Task Add<TEntity>(TEntity entity) where TEntity : class;
    Task Update<TEntity>(TEntity entity) where TEntity : class;
    Task CommitChanges();
    IQueryable<TEntity> Set<TEntity>() where TEntity : class;
    Task SoftDelete<TEntity>(int id) where TEntity : BaseMaster;
    Task<TEntity> GetSingle<TEntity>(int id) where TEntity : class;
    Task<dynamic> BeginTransactionAsync();
}
