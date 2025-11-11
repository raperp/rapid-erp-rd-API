using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;
public class SharedServices(RapidERPDbContext context) : IShared
{
    public async Task<dynamic>  GetSum<T>() where T : GetDTO
    {
        //var p = await context.Set<T>().Where(x => x.StatusTypeId == 23).CountAsync();
        float totalCount = await context.Set<T>().CountAsync();
        int activeCount = await context.Set<T>().Where(x => x.StatusTypeId == 3).CountAsync();
        int inActiveCount = await context.Set<T>().Where(x => x.StatusTypeId == 3).CountAsync();
        int draftCount = await context.Set<T>().Where(x => x.StatusTypeId == 3).CountAsync();
        int updatedCount = await context.Set<T>().Where(x => x.StatusTypeId == 3).CountAsync();
        int deletedCount = await context.Set<T>().Where(x => x.StatusTypeId == 3).CountAsync();

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

 