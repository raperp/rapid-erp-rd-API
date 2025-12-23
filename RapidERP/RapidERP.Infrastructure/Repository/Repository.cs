using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Infrastructure.Data;
using System.Data;

namespace RapidERP.Infrastructure.Repository;

//public class Repository<T> : IRepository<T> where T : class
public class Repository : IRepository
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
     
    public async Task<string> SoftDelete<TEntity>(int id) where TEntity : BaseMaster
    {
        int statusTypeId = await context.StatusTypes.Where(x => x.Name == "Deleted")
                    .AsNoTracking().Select(x => x.Id).FirstOrDefaultAsync();

        await context.Set<TEntity>().Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.StatusTypeId, statusTypeId));
        return "Record soft deleted successfully.";
    }

    public async Task<TEntity> GetSingle<TEntity>(int id) where TEntity : class
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task Delete<TEntity>(int id) where TEntity : Master
    {
        await context.Set<TEntity>().Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task DeleteQueryable<TEntity>(TEntity entity) where TEntity : class
    {
        context.Set<TEntity>().Remove(entity);
    }

    public async Task<dynamic> GetCounts<T>(int pageSize) where T : BaseMaster
    {
        float totalCount = await context.Set<T>().CountAsync();
        int activeCount = await context.Set<T>().Where(x => x.StatusTypeId == 3).CountAsync();
        int inActiveCount = await context.Set<T>().Where(x => x.StatusTypeId == 10).CountAsync();
        int draftCount = await context.Set<T>().Where(x => x.StatusTypeId == 5).CountAsync();
        //int updatedCount = await context.Set<T>().Where(x => x.UpdatedAt != null).CountAsync();
        int deletedCount = await context.Set<T>().Where(x => x.StatusTypeId == 7).CountAsync();
        int softDeletedCount = await context.Set<T>().Where(x => x.StatusTypeId == 6).CountAsync();

        float totalPercentage = totalCount / totalCount * 100;
        float activePercentage = activeCount / totalCount * 100;
        float inActivePercentage = inActiveCount / totalCount * 100;
        float draftPercentage = draftCount / totalCount * 100;
        //float updatedPercentage = updatedCount / totalCount * 100;
        float deletedPercentage = deletedCount / totalCount * 100;

        int totalItems = await context.Set<T>().CountAsync();
        int totalPages = (totalItems + pageSize - 1) / pageSize;

        var result = new
        {
            totalCount,
            activeCount,
            inActiveCount,
            draftCount,
            //updatedCount,
            deletedCount,
            totalItems,
            totalPages,

            totalPercentage = $"{totalPercentage.ToString()}%",
            activePercentage = $"{activePercentage.ToString()}%",
            inActivePercentage = $"{inActivePercentage.ToString()}%",
            draftPercentage = $"{draftPercentage.ToString()}%",
            //updatedPercentage = $"{updatedPercentage.ToString()}%",
            deletedPercentage = $"{deletedPercentage.ToString()}%"
        };

        return result;
    }
}
