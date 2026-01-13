using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TextModuleFeatures.DeleteCommand;

public class DeleteTextModuleCommandHandler(IRepository repository)
{
    DeleteTextModuleCommandResponseModel _response;

    public async Task<DeleteTextModuleCommandResponseModel> Handle(DeleteTextModuleCommandRequestModel request)
    {
        try
        {
            if (request.id is not 0)
            {
                var histories = await repository.Set<TextModuleHistory>().Where(c => c.TextModuleId == request.id).AsNoTracking().ToListAsync();

                foreach (var item in histories)
                {
                    await repository.DeleteQueryable(item);
                }

                await repository.Delete<TextModule>(request.id);

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
