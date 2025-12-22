using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Repository;

//public class Repository<T> : IRepository<T> where T : class
public class Repository  : IRepository 
{
    private readonly RapidERPDbContext context;

    public Repository(RapidERPDbContext context)
    {
        this.context = context;
    }

    public IQueryable<T> Set<T>() where T : class
    {
        return context.Set<T>();
    }

    public async Task CommitChanges()
    {
        await context.SaveChangesAsync();
    }

    public async Task Add<TEntity>(TEntity entity) where TEntity : class
    {
        await context.Set<TEntity>().AddAsync(entity);
    }

    public async Task Update<TEntity>(TEntity entity) where TEntity : class
    {
        context.Entry<TEntity>(entity).State = EntityState.Modified;
    }

    public async Task<dynamic> FindById<TEntity>(TEntity entity) where TEntity : Master
    {
        var record = await context.Set<TEntity>().FindAsync(entity.Id) ?? 
            throw new ApplicationException("Record not found");
        return record;
    }

    public async Task<dynamic> FindByName<TEntity>(TEntity entity) where TEntity : Master
    {
        var record = await context.Set<TEntity>().FindAsync(entity.Name) ?? 
            throw new ApplicationException("Record not found");
        return record;
    }

    public async Task<dynamic> BeginTransactionAsync()
    {
        return await context.Database.BeginTransactionAsync();
    }

     
}
