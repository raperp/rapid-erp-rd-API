using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CityFeatures.GetSingleQuery;

public class GetSingleCityHandler(IRepository repository)
{
    GetSingleCityResponseModel _response;

    public async Task<GetSingleCityResponseModel> Handle(GetSingleCityRequestModel query)
    {
        try
        {
            var data = (from c in repository.Set<City>()
                        join st in repository.Set<StatusType>() on c.StatusTypeId equals st.Id
                        join co in repository.Set<Country>() on c.CountryId equals co.Id
                        join sta in repository.Set<State>() on c.StateId equals sta.Id
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        join l in repository.Set<Language>() on c.LanguageId equals l.Id
                        join m in repository.Set<MenuModule>() on c.MenuModuleId equals m.Id
                        select new GetSingleCityResponseDTOModel
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Tanent = st.Name,
                            MenuModule = m.Name,
                            Country = co.Name,
                            Language = l.Name,
                            State = sta.Name,
                            Status = st.Name
                        }).AsNoTracking().AsQueryable();
              
            var result = await data.Where(x => x.Id == query.id).ToListAsync();
              
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = result
            };

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
