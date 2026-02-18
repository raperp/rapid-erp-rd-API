using RapidERP.Domain.Entities.Shared;
using System.Data;
using UpdateStatus = RapidERP.Application.DTOs.Shared.UpdateStatus;

namespace RapidERP.Application.Repository;

public interface IRepository
{
    Task<List<TEntity>> GetAll<TEntity>() where TEntity : class;
    Task<TEntity> GetSingle<TEntity>(int id) where TEntity : Master;
    Task<dynamic> GetCounts<T>() where T : BaseMaster;
    Task<bool> IsExistsByName<T>(string name) where T : Master;
    Task<bool> IsExistsByIdName<T>(int id, string name) where T : Master;
    Task<bool> IsExistsById<T>(int id) where T : Master;
    Task<TEntity> FindById<TEntity>(int id) where TEntity : Master;
    Task Add<TEntity>(TEntity entity) where TEntity : class;
    Task Update<TEntity>(TEntity entity) where TEntity : class;
    Task Delete<TEntity>(int id) where TEntity : Master;
    Task<string> UpdateStatus<TEntity>(UpdateStatus updateStatus) where TEntity : BaseMaster;
    IDbTransaction BeginTransaction();
    IQueryable<TEntity> Set<TEntity>() where TEntity : class;
    IDbConnection ConnectDatabase();
    Task CommitChanges();
}
