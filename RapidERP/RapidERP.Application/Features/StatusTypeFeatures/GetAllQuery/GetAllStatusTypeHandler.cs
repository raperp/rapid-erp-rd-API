using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StatusTypeFeatures.GetAllQuery;

public class GetAllStatusTypeHandler(IRepository repository)
{
    GetAllStatusTypeResponseModel _response;

    public async Task<GetAllStatusTypeResponseModel> Handle(GetAllStatusTypeRequestModel query)
    {
        try
        {
            var data = (from st in repository.Set<StatusType>()
                        join l in repository.Set<Language>() on st.LanguageId equals l.Id
                        select new
                        {
                            st.Id,
                            Language = l.Name,
                            st.Name,
                            st.Description
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
