using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ActionTypeFeatures.GetAllQuery;

public class GetAllActionTypeHandler(IRepository repository)
{
    GetAllActionTypeResponseModel _response;

    public async Task<GetAllActionTypeResponseModel> Handle(GetAllActionTypeRequestModel query)
    {
        try
        {
            var data = (from at in repository.Set<ActionType>()
                        //join l in repository.Set<Language>() on at.LanguageId equals l.Id
                        select new GetAllActionTypeResponseDTOModel
                        {
                           Id = at.Id,
                           //Language = l.Name,
                           Name = at.Name,
                           Description = at.Description
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
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _response;
        }
    }
}
