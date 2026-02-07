using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.KitchenFeatures.GetHistoryQuery;

public class GetHistoryKitchenHandler(IRepository repository)
{
    GetHistoryKitchenResponseModel _response;

    public async Task<GetHistoryKitchenResponseModel> Handle(GetHistoryKitchenRequestModel query)
    {
        try
        {
            GetHistoryDTO result = new();

            var data = (from ka in repository.Set<KitchenHistory>()
                        join k in repository.Set<Kitchen>() on ka.KitchenId equals k.Id
                        join at in repository.Set<ActionType>() on ka.ActionTypeId equals at.Id
                        //join et in repository.Set<ExportType>() on ka.ExportTypeId equals et.Id
                        select new GetHistoryKitchenResponseDTOModel
                        {
                            Id = ka.Id,
                            Kitchen = k.Name,
                            Name = ka.Name,
                            Description = ka.Description, 
                            //ExportType = et.Name,
                            ActionType = at.Name,
                            //ExportTo = ka.ExportTo,
                            //SourceURL = ka.SourceURL,
                            //Browser = ka.Browser,
                            //Location = ka.Location,
                            //DeviceIP = ka.DeviceIP,
                            //LocationURL = ka.LocationURL,
                            //DeviceName = ka.DeviceName,
                            //Latitude = ka.Latitude,
                            //Longitude = ka.Longitude,
                            //ActionBy = ka.ActionBy,
                            //ActionAt = ka.ActionAt
                        }).AsNoTracking().AsQueryable();

            //int totalItems = await repository.Set<KitchenHistory>().CountAsync();
            //int totalPages = (totalItems + query.pageSize - 1) / query.pageSize;

            if (query.skip == 0 || query.take == 0)
            {
                //result.TotalCount = totalItems;
                //result.TotalPages = totalPages;
                result.Data = await data.ToListAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result.Data
                };
            }

            else
            {
                //result.TotalCount = totalItems;
                //result.TotalPages = totalPages;
                result.Data = await data.Skip(query.skip).Take(query.take).ToListAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result.Data
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
