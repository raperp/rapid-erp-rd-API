using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Repository;

public class Repository(RapidERPDbContext context) : IRepository
{
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
        if (context.ChangeTracker.HasChanges())
        {
            await CommitChanges();
        }
    }

    public async Task<dynamic> FindById<TEntity>(TEntity entity) where TEntity : Master
    {
        var record = await context.Set<TEntity>().FindAsync(entity.Id)
        ?? throw new ApplicationException("Record not found"); 
        return record;
    }

    public async Task<dynamic> FindByName<TEntity>(TEntity entity) where TEntity : Master
    {
        var record = await context.Set<TEntity>().FindAsync(entity.Name)
        ?? throw new ApplicationException("Record not found");
        return record;
    }
}
