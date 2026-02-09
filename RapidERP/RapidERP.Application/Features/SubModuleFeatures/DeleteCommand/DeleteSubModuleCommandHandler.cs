using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SubModuleFeatures.DeleteCommand;

public class DeleteSubModuleCommandHandler(IRepository repository)
{
    DeleteSubModuleCommandResponseModel _response;

    public async Task<DeleteSubModuleCommandResponseModel> Handle(DeleteSubModuleCommandRequestModel request)
    {
        try
        {
            if (request.id is not 0)
            {
                var histories = await repository.Set<SubmoduleHistory>().Where(c => c.SubmoduleId == request.id).AsNoTracking().ToListAsync();

                foreach (var item in histories)
                {
                    //await repository.DeleteQueryable(item);
                }

                await repository.Delete<Submodule>(request.id);

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
