using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Infrastructure.Data;
using UpdateStatus = RapidERP.Application.DTOs.Shared.UpdateStatus;
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
        await context.SaveChangesAsync();
    }

    public async Task Update<TEntity>(TEntity entity) where TEntity : class
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<TEntity> FindById<TEntity>(int id) where TEntity : Master
    {
        var record = await context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
        return record;
    }

    public async Task<string> UpdateStatus<TEntity>(UpdateStatus updateStatus) where TEntity : BaseMaster
    {
        string message = "Status Updated";

        if (updateStatus.IsActive == true)
        {
            await context.Set<TEntity>().Where(x => x.Id == updateStatus.Id).ExecuteUpdateAsync(x => x.SetProperty(x => x.IsActive, true));
        }

        if (updateStatus.IsActive == false)
        {
            await context.Set<TEntity>().Where(x => x.Id == updateStatus.Id).ExecuteUpdateAsync(x => x.SetProperty(x => x.IsActive, false));
        }

        if (updateStatus.IsDelete == true)
        {
            await context.Set<TEntity>().Where(x => x.Id == updateStatus.Id).ExecuteUpdateAsync(x => x.SetProperty(x => x.IsDeleted, true));
        }

        return message;
    }

    public async Task<TEntity> GetSingle<TEntity>(int id) where TEntity : Master
    {
        var record = await context.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
        return record;
    }

    public async Task Delete<TEntity>(int id) where TEntity : Master
    {
        await context.Set<TEntity>().Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task DeleteQueryable<TEntity>(TEntity entity) where TEntity : class
    {
        context.Set<TEntity>().Remove(entity);
    }

    public async Task<dynamic> GetCounts<T>() where T : BaseMaster
    {
        //var activeStatusId = await context.StatusTypes.Where(x => x.Name == "Active").AsNoTracking().Select(x => x.Id).FirstOrDefaultAsync();
        //var inActiveStatusId = await context.StatusTypes.Where(x => x.Name == "InActive").AsNoTracking().Select(x => x.Id).FirstOrDefaultAsync();
        //var draftedStatusId = await context.StatusTypes.Where(x => x.Name == "Drafted").AsNoTracking().Select(x => x.Id).FirstOrDefaultAsync();
        //var updatedStatusId = await context.StatusTypes.Where(x => x.Name == "Updated").AsNoTracking().Select(x => x.Id).FirstOrDefaultAsync();
        //var softDeletedStatusId = await context.StatusTypes.Where(x => x.Name == "SoftDeleted").AsNoTracking().Select(x => x.Id).FirstOrDefaultAsync();

        float totalCount = await context.Set<T>().CountAsync();
        int activeCount = await context.Set<T>().Where(x => x.IsActive == true).CountAsync();
        int inActiveCount = await context.Set<T>().Where(x => x.IsActive == false).CountAsync();
        int draftCount = await context.Set<T>().Where(x => x.IsDraft == true).CountAsync();
        int updatedCount = await context.Set<T>().Where(x => x.UpdatedAt != null).CountAsync();
        int softDeletedCount = await context.Set<T>().Where(x => x.IsDeleted == true).CountAsync();

        float totalPercentage = totalCount / totalCount * 100;
        float activePercentage = activeCount / totalCount * 100;
        float inActivePercentage = inActiveCount / totalCount * 100;
        float draftPercentage = draftCount / totalCount * 100;
        float updatedPercentage = updatedCount / totalCount * 100;
        float softdeletedPercentage = softDeletedCount / totalCount * 100;

        //int totalItems = await context.Set<T>().CountAsync();
        //int totalPages = (totalItems + pageSize - 1) / pageSize;

        var result = new
        {
            totalCount,
            activeCount,
            inActiveCount,
            draftCount,
            updatedCount,
            softDeletedCount,

            totalPercentage = $"{totalPercentage.ToString()}%",
            activePercentage = $"{activePercentage.ToString()}%",
            inActivePercentage = $"{inActivePercentage.ToString()}%",
            draftPercentage = $"{draftPercentage.ToString()}%",
            updatedPercentage = $"{updatedPercentage.ToString()}%",
            softDeletedPercentage = $"{softdeletedPercentage.ToString()}%"
        };

        return result;
    }

    public async Task<bool> IsExists<T>(string name) where T : Master
    {
        var result = await context.Set<T>().AsNoTracking().AnyAsync(x => x.Name == name);
        return result;
    }

    public async Task<bool> IsExistsById<T>(int id, string name) where T : Master
    {
        var result = await context.Set<T>().AsNoTracking().AnyAsync(x => x.Name == name && x.Id != id);
        return result;
    }

    public IDbTransaction BeginTransaction()
    {
        var transaction = context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }

    public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : class
    {
        return await context.Set<TEntity>().AsNoTracking().ToListAsync();
    }
}
