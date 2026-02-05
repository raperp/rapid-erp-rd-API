using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Features.ActionTypeFeatures.GetAllQuery;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ActionTypeFeatures.GetSingleQuery;

public record GetSingleActionTypeHandler(IRepository repository)
{
    GetSingleActionTypeResponseModel _response;

    public async Task<GetSingleActionTypeResponseModel> Handle(GetSingleActionTypeRequestModel query)
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