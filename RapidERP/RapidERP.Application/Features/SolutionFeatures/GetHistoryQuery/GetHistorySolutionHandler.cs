using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SolutionModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SolutionFeatures.GetHistoryQuery;

public class GetHistorySolutionHandler(IRepository repository)
{
    GetHistorySolutionResponseModel _response;

    public async Task<GetHistorySolutionResponseModel> Handle(GetHistorySolutionRequestModel query)
    {
        try
        {
            var data = (from sh in repository.Set<SolutionHistory>()
                        join s in repository.Set<Solution>() on sh.SolutionId equals s.Id
                        //join t in repository.Set<Tenant>() on sh.TenantId equals t.Id
                        //join mm in repository.Set<MenuModule>() on sh.MenuModuleId equals mm.Id
                        //join l in repository.Set<Language>() on sh.LanguageId equals l.Id
                        join at in repository.Set<ActionType>() on sh.ActionTypeId equals at.Id
                        //join et in repository.Set<ExportType>() on sh.ExportTypeId equals et.Id
                        select new GetHistorySolutionResponseDTOModel
                        {
                            Id = sh.Id,
                            Currency = s.Name,
                            //Tenant = t.Name,
                            //MenuModule = mm.Name,
                            //Language = l.Name,
                            Action = at.Name,
                            //ExportType = et.Name,
                            //ExportTo = sh.ExportTo,
                            //SourceURL = sh.SourceURL,
                            Code = sh.Code,
                            Name = sh.Name,
                            Icon = sh.Icon,
                            Description = sh.Description,
                            //Browser = sh.Browser,
                            //Location = sh.Location,
                            //DeviceIP = sh.DeviceIP,
                            //LocationURL = sh.LocationURL,
                            //DeviceName = sh.DeviceName,
                            //Latitude = sh.Latitude,
                            //Longitude = sh.Longitude,
                            //ActionBy = sh.ActionBy,
                            //ActionAt = sh.ActionAt
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
