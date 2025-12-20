using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;
using RapidERP.Application.Repository;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Repository;

public class Repository<T, Q> : IRepository<T, Q> where T : class
{
    private readonly RapidERPDbContext context;
    private readonly DbSet<T> dbSet;
    public Repository(RapidERPDbContext context)
    {
        this.context = context;
        dbSet = context.Set<T>();
    }

    public Task CommitChanges()
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> CreateBulk(List<T> masterPOSTs)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> CreateSingle(T masterPOST)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> DbSet()
    {
        return dbSet;
    }

    public Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<dynamic> GetSingle(int id)
    {
        throw new NotImplementedException();
    }

    public Task<dynamic> SoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> Update(Q masterPUT)
    {
        throw new NotImplementedException();
    }
    //public async Task CommitChanges()
    //{
    //    await context.SaveChangesAsync();
    //}

    //public async Task Add<TEntity>(TEntity entity) where TEntity : class
    //{
    //    await context.Set<TEntity>().AddAsync(entity);         
    //}

    //public async Task Update<TEntity>(TEntity entity) where TEntity : class
    //{
    //    if (context.ChangeTracker.HasChanges())
    //    {
    //        await CommitChanges();
    //    }
    //}

    //public async Task<dynamic> FindById<TEntity>(TEntity entity) where TEntity : Master
    //{
    //    var record = await context.Set<TEntity>().FindAsync(entity.Id)
    //    ?? throw new ApplicationException("Record not found"); 
    //    return record;
    //}

    //public async Task<dynamic> FindByName<TEntity>(TEntity entity) where TEntity : Master
    //{
    //    var record = await context.Set<TEntity>().FindAsync(entity.Name)
    //    ?? throw new ApplicationException("Record not found");
    //    return record;
    //}
}
