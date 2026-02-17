using RapidERP.Application.DTOs.Shared;
using RapidERP.Domain.Entities.Shared;
using System.Data;
using UpdateStatus = RapidERP.Application.DTOs.Shared.UpdateStatus;

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
    Task<TEntity> FindById<TEntity>(int id) where TEntity : Master;
    Task Add<TEntity>(TEntity entity) where TEntity : class;
    Task Update<TEntity>(TEntity entity) where TEntity : class;
    Task CommitChanges();
    IQueryable<TEntity> Set<TEntity>() where TEntity : class;
    Task<string> UpdateStatus<TEntity>(UpdateStatus updateStatus) where TEntity : BaseMaster;
    Task<string> Restore<TEntity>(int id) where TEntity : BaseMaster;
    Task Delete<TEntity>(int id) where TEntity : Master; 
    //Task DeleteQueryable<TEntity>(TEntity entity) where TEntity : class; 
    Task<TEntity> GetSingle<TEntity>(int id) where TEntity : Master;
    Task<List<TEntity>> GetAll<TEntity>() where TEntity : class;
    IDbTransaction BeginTransaction();
    Task<dynamic> GetCounts<T>() where T : BaseMaster;
    Task<bool> IsExists<T>(string name) where T : Master;
    Task<bool> IsExistsById<T>(int id, string name) where T : Master;
    IDbConnection ConnectDatabase();
}
