using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Features.LanguageFeatures.GetSingleLanguageQuery;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.LanguageFeatures.GetAllQuery;

public class GetAllLanguageHandler(IRepository repository)
{
    GetAllLanguageResponseModel _response;

    public async Task<GetAllLanguageResponseModel> Handle(GetAllLanguageRequestModel query)
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
                            IconURL = l.IconURL,
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                var result = await data.ToListAsync();

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
                var result = await data.Skip(query.skip).Take(query.take).ToListAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return _response;
        }

        catch (Exception ex)
        {
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _response;
        }
    }
}
