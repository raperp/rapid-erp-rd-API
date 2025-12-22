using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Application.Features.CountryFeatures.GetHistoryQuery;

public class GetHistoryCountryHandler(IRepository repository)
{
    public async Task<List<GetHistoryCountryResponseModel>> Handle(GetHistoryCountryRequestModel query)
    {
        try
        {
            var data = (from ca in repository.Set<CountryHistory>()
                        join c in repository.Set<Country>() on ca.CountryId equals c.Id
                        join et in repository.Set<ExportType>() on ca.ExportTypeId equals et.Id
                        join at in repository.Set<ActionType>() on ca.ActionTypeId equals at.Id
                        join t in repository.Set<Tenant>() on ca.TenantId equals t.Id
                        join l in repository.Set<Language>() on ca.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on ca.MenuModuleId equals mm.Id
                        join cu in repository.Set<Currency>() on ca.CurrencyId equals cu.Id
                        select new GetHistoryCountryResponseModel
                        {
                            Id = ca.Id,
                            Country = c.Name,
                            Tanent = t.Name,
                            MenuModule = mm.Name,
                            Action = at.Name,
                            Language = l.Name,
                            ExportType = et.Name,
                            Currency = cu.Name,
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
                            Browser = ca.Browser,
                            Location = ca.Location,
                            DeviceIP = ca.DeviceIP,
                            LocationURL = ca.LocationURL,
                            DeviceName = ca.DeviceName,
                            Latitude = ca.Latitude,
                            Longitude = ca.Longitude,
                            ActionBy = ca.ActionBy,
                            ActionAt = ca.ActionAt
                        }).AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                return data.ToList();

                //_requestResponse = new()
                //{
                //    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                //    IsSuccess = true,
                //    Message = ResponseMessage.FetchSuccess,
                //    Data = result
                //};
            }

            else
            {
                return data.Skip(query.skip).Take(query.take).ToList();

                //_requestResponse = new()
                //{
                //    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                //    IsSuccess = true,
                //    Message = ResponseMessage.FetchSuccessWithPagination,
                //    Data = result
                //};
            }

             
        }

        catch (Exception ex)
        {
            //_requestResponse = new()
            //{
            //    StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
            //    IsSuccess = false,
            //    Message = ex.Message
            //};

            //return _requestResponse;
            throw new ApplicationException(ex.Message);
        }
    }
}
