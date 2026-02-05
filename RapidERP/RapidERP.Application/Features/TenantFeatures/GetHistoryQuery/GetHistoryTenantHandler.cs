using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TenantFeatures.GetHistoryQuery;

public class GetHistoryTenantHandler(IRepository repository)
{
    GetHistoryTenantResponseModel _response;

    public async Task<GetHistoryTenantResponseModel> Handle(GetHistoryTenantRequestModel query)
    {
        try
        {
            var data = (from th in repository.Set<TenantHistory>()
                        join t in repository.Set<Tenant>() on th.TenantId equals t.Id
                        join mm in repository.Set<MenuModule>() on th.MenuModuleId equals mm.Id
                        join c in repository.Set<Country>() on th.CountryId equals c.Id
                        join s in repository.Set<State>() on th.StateId equals s.Id
                        //join l in repository.Set<Language>() on th.LanguageId equals l.Id
                        join at in repository.Set<ActionType>() on th.ActionTypeId equals at.Id
                        join et in repository.Set<ExportType>() on th.ExportTypeId equals et.Id
                        select new GetHistoryTenantResponseDTOModel
                        {
                            Id = th.Id,
                            Tenant = t.Name,
                            MenuModule = mm.Name,
                            Country = c.Name,
                            State = s.Name,
                            //Language = l.Name,
                            Action = at.Name,
                            ExportMedia = et.Name,
                            ExportTo = th.ExportTo,
                            SourceURL = th.SourceURL,
                            Name = th.Name,
                            Contact = th.Contact,
                            Phone = th.Phone,
                            Mobile = th.Mobile,
                            Address = th.Address,
                            Email = th.Email,
                            Website = th.Website,
                            //Browser = th.Browser,
                            //Location = th.Location,
                            //DeviceIP = th.DeviceIP,
                            //LocationURL = th.LocationURL,
                            //DeviceName = th.DeviceName,
                            //Latitude = th.Latitude,
                            //Longitude = th.Longitude,
                            //ActionBy = th.ActionBy,
                            //ActionAt = th.ActionAt
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
