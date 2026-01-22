using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.KitchenFeatures.GetSingleQuery;

public class GetSingleKitchenHandler(IRepository repository)
{
    GetSingleKitchenResponseModel _response;

    public async Task<GetSingleKitchenResponseModel> Handle(GetSingleKitchenRequestModel query)
    {
        try
        { 
            var data = (from k in repository.Set<Kitchen>()
                        join st in repository.Set<StatusType>() on k.StatusTypeId equals st.Id
                        select new GetSingleKitchenResponseDTOModel
                        {
                            Id = k.Id,
                            Name = k.Name,
                            Description = k.Description,
                            PrinterId = k.PrinterId,
                            Status = st.Name
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
