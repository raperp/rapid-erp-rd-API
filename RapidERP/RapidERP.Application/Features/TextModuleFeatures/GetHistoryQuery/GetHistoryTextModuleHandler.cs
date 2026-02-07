using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TextModuleFeatures.GetHistoryQuery;

public class GetHistoryTextModuleHandler(IRepository repository)
{
    GetHistoryTextModuleResponseModel _response;

    public async Task<GetHistoryTextModuleResponseModel> Handle(GetHistoryTextModuleRequestModel query)
    {
        try
        {
            var data = (from tma in repository.Set<TextModuleHistory>()
                        join tm in repository.Set<TextModule>() on tma.TextModuleId equals tm.Id
                        join mm in repository.Set<MenuModule>() on tma.MenuModuleId equals mm.Id
                        join at in repository.Set<ActionType>() on tma.ActionTypeId equals at.Id
                        //join l in repository.Set<Language>() on tma.LanguageId equals l.Id
                        //join et in repository.Set<ExportType>() on tma.ExportTypeId equals et.Id
                        select new GetHistoryTextModuleResponseDTOModel
                        {
                            Id = tma.Id,
                            TextModule = tm.Name,
                            MenuModule = mm.Name,
                            //Language = l.Name,
                            Action = at.Name,
                            //ExportType = et.Name,
                            //ExportTo = tma.ExportTo,
                            //SourceURL = tma.SourceURL,
                            Name = tma.Name,
                            //Browser = tma.Browser,
                            //Location = tma.Location,
                            //DeviceIP = tma.DeviceIP,
                            //LocationURL = tma.LocationURL,
                            //DeviceName = tma.DeviceName,
                            //Latitude = tma.Latitude,
                            //Longitude = tma.Longitude,
                            //ActionBy = tma.ActionBy,
                            //ActionAt = tma.ActionAt
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
