using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Application.Repository;

//public interface IRepository<T> where T : class
public interface IRepository 
{
    Task<dynamic> FindById<TEntity>(TEntity entity) where TEntity : Master;
    Task<dynamic> FindByName<TEntity>(TEntity entity) where TEntity : Master;
    Task Add<TEntity>(TEntity entity) where TEntity : class;
    Task Update<TEntity>(TEntity entity) where TEntity : class;
    Task CommitChanges();
    //IQueryable<T> DbSet();
    IQueryable<T> Set<T>() where T : class;
    IQueryable DbContext();
}
