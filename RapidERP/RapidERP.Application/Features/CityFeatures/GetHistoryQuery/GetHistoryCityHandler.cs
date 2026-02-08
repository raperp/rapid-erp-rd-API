using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CityFeatures.GetHistoryQuery;

public class GetHistoryCityHandler(IRepository repository)
{
    GetHistoryCityResponseModel _response;

    public async Task<GetHistoryCityResponseModel> Handle(GetHistoryCityRequestModel query)
    {
        try
        {
            GetHistoryDTO result = new();

            var data = (from ch in repository.Set<CityHistory>()
                        join c in repository.Set<City>() on ch.CountryId equals c.Id
                        //join et in repository.Set<ExportType>() on ch.ExportTypeId equals et.Id
                        join at in repository.Set<ActionType>() on ch.ActionTypeId equals at.Id
                        //join t in repository.Set<Tenant>() on ch.TenantId equals t.Id
                        //join l in repository.Set<Language>() on ch.LanguageId equals l.Id
                        //join m in repository.Set<MenuModule>() on ch.MenuModuleId equals m.Id
                        select new GetHistoryCityResponseDTOModel
                        {
                            Id = ch.Id,
                            City = c.Name,
                            Name = ch.Name,
                            Code = ch.Code,
                            //Tanent = t.Name,
                            //Menu = m.Name,
                            Action = at.Name,
                            //Language = l.Name,
                            //ExportType = et.Name,
                            //ExportTo = ch.ExportTo,
                            //SourceURL = ch.SourceURL,
                            IsDefault = ch.IsDefault,
                            IsDraft = ch.IsDraft,
                            //Browser = ch.Browser,
                            //Location = ch.Location,
                            //DeviceIP = ch.DeviceIP,
                            //LocationURL = ch.LocationURL,
                            //DeviceName = ch.DeviceName,
                            //Latitude = ch.Latitude,
                            //Longitude = ch.Longitude,
                            //ActionBy = ch.ActionBy,
                            //ActionAt = ch.ActionAt
                        }).AsNoTracking().AsQueryable();

            //int totalItems = await repository.Set<CityHistory>().CountAsync();
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
