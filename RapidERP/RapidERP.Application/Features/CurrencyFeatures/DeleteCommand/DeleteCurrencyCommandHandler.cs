using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CurrencyFeatures.DeleteCommand;

public class DeleteCurrencyCommandHandler(IRepository repository)
{
    DeleteCurrencyCommandResponseModel _response;

    public async Task<DeleteCurrencyCommandResponseModel> Handle(DeleteCurrencyCommandRequestModel request)
    {
        try
        {
            if (request.id is not 0)
            {
                var histories = await repository.Set<CurrencyHistory>().Where(c => c.CurrencyId == request.id).AsNoTracking().ToListAsync();

                foreach (var item in histories)
                {
                    await repository.DeleteQueryable(item);
                }

                await repository.Delete<Currency>(request.id);

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
