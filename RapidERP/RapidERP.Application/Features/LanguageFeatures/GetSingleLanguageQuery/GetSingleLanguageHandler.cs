using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.LanguageFeatures.GetSingleLanguageQuery;

public class GetSingleLanguageHandler(IRepository repository)
{
    GetSingleLanguageResponseModel _response;

    public async Task<GetSingleLanguageResponseModel> Handle(GetSingleLanguageRequestModel query)
    {
        try
        {
            var data = (from l in repository.Set<Language>()
                        select new GetLanguageResponseDTOModel
                        {
                            Id = l.Id,
                            ISONumeric = l.ISONumeric,
                            Name = l.Name,
                            ISO2Code = l.ISO2Code,
                            ISO3Code = l.ISO3Code,
                            IconURL = l.IconURL
                        }).AsNoTracking().AsQueryable();
    
            var result = await data.Where(x => x.Id == query.id).ToListAsync();

            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = result
            };

            return _response;
        }

        catch (Exception ex)
        {
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _response;
        }
    }
}
