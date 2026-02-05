using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using System;

namespace RapidERP.Application.Features.CountryFeatures.GetHistoryQuery;

public class GetHistoryCountryHandler(IRepository repository)
{
    GetHistoryCountryResponseModel _response;

    public async Task<GetHistoryCountryResponseModel> Handle(GetHistoryCountryRequestModel query)
    {
        try
        {
            GetHistoryDTO result = new();

            var data = (from ca in repository.Set<CountryAudit>()
                        join c in repository.Set<Country>() on ca.CountryId equals c.Id
                        //join et in repository.Set<ExportType>() on ca.ExportTypeId equals et.Id
                        join at in repository.Set<ActionType>() on ca.ActionTypeId equals at.Id
                        join t in repository.Set<Tenant>() on ca.TenantId equals t.Id
                        //join l in repository.Set<Language>() on ca.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on ca.MenuModuleId equals mm.Id
                        //join cu in repository.Set<Currency>() on ca.CurrencyId equals cu.Id
                        select new GetHistoryCountryResponseDTOModel
                        {
                            Id = ca.Id,
                            Country = c.Name,
                            Tanent = t.Name,
                            MenuModule = mm.Name,
                            Action = at.Name,
                            //Language = l.Name,
                            //ExportType = et.Name,
                            //Currency = cu.Name,
                            ExportTo = ca.ExportTo,
                            SourceURL = ca.SourceURL,
                            DialCode = ca.DialCode,
                            Name = ca.Name,
                            IsDefault = ca.IsDefault,
                            IsDraft = ca.IsDraft,
                            ISONumeric = ca.ISONumeric,
                            ISO2Code = ca.ISO2Code,
                            ISO3Code = ca.ISO3Code,
                            FlagURL = ca.FlagURL,
                            //Browser = ca.Browser,
                            //Location = ca.Location,
                            //DeviceIP = ca.DeviceIP,
                            //LocationURL = ca.LocationURL,
                            //DeviceName = ca.DeviceName,
                            //Latitude = ca.Latitude,
                            //Longitude = ca.Longitude,
                            //ActionBy = ca.ActionBy,
                            //ActionAt = ca.ActionAt
                        }).AsNoTracking().AsQueryable();

            //int totalItems = await repository.Set<CountryHistory>().CountAsync();
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
