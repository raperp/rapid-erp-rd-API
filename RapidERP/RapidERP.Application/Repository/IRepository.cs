using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Repository;

public interface IRepository  
{
    //Task<dynamic> GetAll(int skip, int take);
    //Task<dynamic> GetSingle(int id);
    //Task<dynamic> GetHistory(int skip, int take);
    Task<dynamic> FindById<TEntity>(TEntity entity) where TEntity : Master;
    Task<dynamic> FindByName<TEntity>(TEntity entity) where TEntity : Master;
    Task Add<TEntity>(TEntity entity) where TEntity : class;
    Task Update<TEntity>(TEntity entity) where TEntity : class;
    Task CommitChanges();
    //Task<dynamic> CreateBulk(List<TEntity> masterPOSTs);
}
