using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StateFeatures.DeleteCommand;

public class DeleteStateCommandHandler(IRepository repository)
{
    DeleteStateCommandResponseModel _response;

    public async Task<DeleteStateCommandResponseModel> Handle(DeleteStateCommandRequestModel request)
    {
        try
        {
            if (request.id is not 0)
            {
                var histories = await repository.Set<StateHistory>().Where(c => c.StateId == request.id).AsNoTracking().ToListAsync();

                foreach (var item in histories)
                {
                    await repository.DeleteQueryable(item);
                }

                await repository.Delete<State>(request.id);

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
