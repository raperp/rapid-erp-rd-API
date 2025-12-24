using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.CountryTemplate;

public class CountryTemplateQueryHandlar(IRepository repository)
{
    CountryTemplateResponseModel _response;

    public async Task<CountryTemplateResponseModel> Handle(CountryTemplateRequestModel model)
    {
        try
        {
            var result = await repository.Set<RapidERP.Domain.Entities.CountryModels.CountryTemplate>().AsNoTracking().ToListAsync();

            if(result is not null)
            {
                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
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
            
            return _response;
        }

        catch
        {
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return _response;
        }
    }
}