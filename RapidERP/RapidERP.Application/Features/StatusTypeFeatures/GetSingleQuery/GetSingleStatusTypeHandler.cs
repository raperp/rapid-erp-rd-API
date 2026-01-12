using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Features.StatusTypeFeatures.GetAllQuery;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StatusTypeFeatures.GetSingleQuery;

public class GetSingleStatusTypeHandler(IRepository repository)
{
    GetSingleStatusTypeResponseModel _response;

    public async Task<GetSingleStatusTypeResponseModel> Handle(GetSingleStatusTypeRequestModel request)
    {
        try
        {
            var data = (from st in repository.Set<StatusType>()
                        join l in repository.Set<Language>() on st.LanguageId equals l.Id
                        select new GetStatusTypeResponseDTOModel
                        {
                            Id = st.Id,
                            Language = l.Name,
                            Name = st.Name,
                            Description = st.Description
                        }).AsNoTracking().AsQueryable();

            var result = await data.Where(x => x.Id == request.id).ToListAsync();

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
