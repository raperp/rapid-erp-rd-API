using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class SharedServices(RapidERPDbContext context) : IShared
{
    public async Task<dynamic> GetCounts<T>() where T : BaseMaster
    {
        float totalCount = await context.Set<T>().CountAsync();
        int activeCount = await context.Set<T>().Where(x => x.StatusTypeId == 3).CountAsync();
        int inActiveCount = await context.Set<T>().Where(x => x.StatusTypeId == 10).CountAsync();
        int draftCount = await context.Set<T>().Where(x => x.StatusTypeId == 5).CountAsync();
        int updatedCount = await context.Set<T>().Where(x => x.UpdatedAt != null).CountAsync();
        int deletedCount = await context.Set<T>().Where(x => x.StatusTypeId == 7).CountAsync();
        int softDeletedCount = await context.Set<T>().Where(x => x.StatusTypeId == 6).CountAsync();

        float totalPercentage = totalCount / totalCount * 100;
        float activePercentage = activeCount / totalCount * 100;
        float inActivePercentage = inActiveCount / totalCount * 100;
        float draftPercentage = draftCount / totalCount * 100;
        float updatedPercentage = updatedCount / totalCount * 100;
        float deletedPercentage = deletedCount / totalCount * 100;

        var result = new
        {
            totalCount,
            activeCount,
            inActiveCount,
            draftCount,
            updatedCount,
            deletedCount,

            totalPercentage = $"{totalPercentage.ToString()}%",
            activePercentage = $"{activePercentage.ToString()}%",
            inActivePercentage = $"{inActivePercentage.ToString()}%",
            draftPercentage = $"{draftPercentage.ToString()}%",
            updatedPercentage = $"{updatedPercentage.ToString()}%",
            deletedPercentage = $"{deletedPercentage.ToString()}%"
        };

        return result;
    }
}

 