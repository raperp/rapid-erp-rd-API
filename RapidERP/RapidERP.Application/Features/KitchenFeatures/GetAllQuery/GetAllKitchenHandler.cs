using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.KitchenFeatures.GetAllQuery;

public class GetAllKitchenHandler(IRepository repository)
{
    GetAllKitchenResponseModel _response;

    public async Task<GetAllKitchenResponseModel> Handle(GetAllKitchenRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from k in repository.Set<Kitchen>()
                        //join st in repository.Set<StatusType>() on k.StatusTypeId equals st.Id
                        select new GetKitchenResponseDTOModel
                        {
                            Id = k.Id,
                            Name = k.Name,
                            Description = k.Description,
                            PrinterId = k.PrinterId,
                            //Status = st.Name
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<Kitchen>();
                result.Data = await data.ToListAsync();

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
                result.Count = await repository.GetCounts<Kitchen>();
                result.Data = await data.Skip(query.skip).Take(query.take).ToListAsync();

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
