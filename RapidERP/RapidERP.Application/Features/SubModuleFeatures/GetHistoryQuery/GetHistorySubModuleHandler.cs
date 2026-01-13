using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SubModuleFeatures.GetHistoryQuery;

public class GetHistorySubModuleHandler(IRepository repository)
{
    GetHistorySubModuleResponseModel _response;

    public async Task<GetHistorySubModuleResponseModel> Handle(GetHistorySubModuleRequestModel query)
    {
        try
        {
            var data = (from sa in repository.Set<SubmoduleHistory>()
                        join s in repository.Set<Submodule>() on sa.SubmoduleId equals s.Id
                        join mm in repository.Set<MainModule>() on sa.MainModuleId equals mm.Id
                        join at in repository.Set<ActionType>() on sa.ActionTypeId equals at.Id
                        join et in repository.Set<ExportType>() on sa.ExportTypeId equals et.Id
                        join l in repository.Set<Language>() on sa.LanguageId equals l.Id
                        select new GetHistorySubModuleResponseDTOModel
                        {
                            Id = sa.Id,
                            SubModule = s.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            ExportTo = sa.ExportTo,
                            SourceURL = sa.SourceURL,
                            Name = sa.Name,
                            IconURL = sa.IconURL,
                            SetSerial = sa.SetSerial,
                            Browser = sa.Browser,
                            Location = sa.Location,
                            DeviceIP = sa.DeviceIP,
                            LocationURL = sa.LocationURL,
                            DeviceName = sa.DeviceName,
                            Latitude = sa.Latitude,
                            Longitude = sa.Longitude,
                            ActionBy = sa.ActionBy,
                            ActionAt = sa.ActionAt
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
