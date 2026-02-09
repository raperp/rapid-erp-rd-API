using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.AreaFeatures.DeleteCommand;

public class DeleteAreaCommandHandler(IRepository repository)
{
    DeleteAreaCommandResponseModel _response;

    public async Task<DeleteAreaCommandResponseModel> Handle(DeleteAreaCommandRequestModel request)
    {
        try
        {
            if (request.id is not 0)
            {
                var histories = await repository.Set<AreaHistory>().Where(c => c.AreaId == request.id).AsNoTracking().ToListAsync();

                foreach (var item in histories)
                {
                    //await repository.DeleteQueryable(item);
                }

                await repository.Delete<Area>(request.id);

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.DeleteSuccess
                };
            }

            else
            {
                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }
        }

        catch (Exception ex)
        {
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };
        }

        return _response;
    }
}
