using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class SharedServices(RapidERPDbContext context) : IShared
{
    RequestResponse requestResponse { get; set; }

    public async Task<dynamic> GetCounts<T>() where T : BaseMaster
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

        var result = new
        {
            totalCount,
            activeCount,
            inActiveCount,
            draftCount,
            //updatedCount,
            deletedCount,

            totalPercentage = $"{totalPercentage.ToString()}%",
            activePercentage = $"{activePercentage.ToString()}%",
            inActivePercentage = $"{inActivePercentage.ToString()}%",
            draftPercentage = $"{draftPercentage.ToString()}%",
            //updatedPercentage = $"{updatedPercentage.ToString()}%",
            deletedPercentage = $"{deletedPercentage.ToString()}%"
        };

        return result;
    }

    public async Task<RequestResponse> GetSingle<T>(int id) where T : Master
    {
        try
        {
            var data = await context.Set<T>().Where(x => x.Id == id).AsNoTracking().ToListAsync();

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = data
            };

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> SoftDelete<T>(int id) where T : BaseMaster
    {
        try
        {
            var isExists = await context.Set<T>().AsNoTracking().AnyAsync(x => x.Id == id);

            if (isExists == false)
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }

            else
            {
                int statusTypeId = await context.StatusTypes.Where(x => x.Name == "Deleted")
                    .AsNoTracking().Select(x => x.Id).FirstOrDefaultAsync();

                await context.Set<T>().Where(x => x.Id == id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.StatusTypeId, statusTypeId));
            }

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.DeleteSuccess
            };

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }
}