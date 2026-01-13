using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MenuModuleFeatures.GetHistoryQuery;

public class GetHistoryMenuModuleHandler(IRepository repository)
{
    GetHistoryMenuModuleResponseModel _response;

    public async Task<GetHistoryMenuModuleResponseModel> Handle(GetHistoryMenuModuleRequestModel query)
    {
        try
        {
            var data = (from mma in repository.Set<MenuModuleHistory>()
                        join mm in repository.Set<MenuModule>() on mma.MenuModuleId equals mm.Id
                        join at in repository.Set<ActionType>() on mma.ActionTypeId equals at.Id
                        join sm in repository.Set<Submodule>() on mma.SubmoduleId equals sm.Id
                        join l in repository.Set<Language>() on mma.LanguageId equals l.Id
                        join et in repository.Set<ExportType>() on mma.ExportTypeId equals et.Id
                        select new GetHistoryMenuModuleResponseDTOModel
                        {
                            Id = mma.Id,
                            MainModule = mm.Name,
                            Submodule = mm.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            ExportTo = mma.ExportTo,
                            SourceURL = mma.SourceURL,
                            Name = mma.Name,
                            IconURL = mma.IconURL,
                            SetSerial = mma.SetSerial,
                            Browser = mma.Browser,
                            Location = mma.Location,
                            DeviceIP = mma.DeviceIP,
                            LocationURL = mma.LocationURL,
                            DeviceName = mma.DeviceName,
                            Latitude = mma.Latitude,
                            Longitude = mma.Longitude,
                            ActionBy = mma.ActionBy,
                            ActionAt = mma.ActionAt
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
