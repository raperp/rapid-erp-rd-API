using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StatusTypeFeatures.GetHistoryQuery;

public class GetHistoryStatusTypeHandler(IRepository repository)
{
    GetHistoryStatusTypeResponseModel _response;

    public async Task<GetHistoryStatusTypeResponseModel> Handle(GetHistoryStatusTypeRequestModel query)
    {
        try
        {
            var data = (from sta in repository.Set<StatusTypeHistory>()
                        join st in repository.Set<StatusType>() on sta.StatusTypeId equals st.Id
                        join at in repository.Set<ActionType>() on sta.ActionTypeId equals at.Id
                        //join l in repository.Set<Language>() on sta.LanguageId equals l.Id
                        //join et in repository.Set<ExportType>() on sta.ExportTypeId equals et.Id
                        select new GetHistoryStatusTypeResponseDTOModel
                        {
                            Id = sta.Id,
                            Status = st.Name,
                            //Language = l.Name,
                            Action = at.Name,
                            //ExportType = et.Name,
                            //ExportTo = sta.ExportTo,
                            //SourceURL = sta.SourceURL,
                            Name = sta.Name,
                            Description = sta.Description,
                            //Browser = sta.Browser,
                            //Location = sta.Location,
                            //DeviceIP = sta.DeviceIP,
                            //LocationURL = sta.LocationURL,
                            //DeviceName = sta.DeviceName,
                            //Latitude = sta.Latitude,
                            //Longitude = sta.Longitude,
                            //ActionBy = sta.ActionBy,
                            //ActionAt = sta.ActionAt
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
