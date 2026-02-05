using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Features.AreaFeatures.GetHistoryQuery;
using RapidERP.Application.Features.CountryFeatures.GetAllQuery;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.AreaFeatures.GetAllQuery;

public class GetAllAreaHandler(IRepository repository)
{
    GetAllAreaResponseModel _response;

    public async Task<GetAllAreaResponseModel> Handle(GetAllAreaRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from a in repository.Set<Area>()
                        join st in repository.Set<StatusType>() on a.StatusTypeId equals st.Id
                        join co in repository.Set<Country>() on a.CountryId equals co.Id
                        join sta in repository.Set<State>() on a.StateId equals sta.Id
                        join ci in repository.Set<City>() on a.CityId equals ci.Id
                        join mm in repository.Set<MenuModule>() on a.MenuModuleId equals mm.Id
                        join t in repository.Set<Tenant>() on a.TenantId equals t.Id
                        //join l in repository.Set<Language>() on a.LanguageId equals l.Id
                        select new GetAllAreaResponseDTOModel
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Code = a.Code,
                            Tanent = t.Name,
                            //Language = l.Name,
                            MenuModule = mm.Name,
                            Country = co.Name,
                            State = sta.Name,
                            Status = st.Name,
                            City = ci.Name
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<Area>(query.pageSize);
                result.Data = await data.ToListAsync();

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
                result.Count = await repository.GetCounts<Area>(query.pageSize);
                result.Data = await data.Skip(query.skip).Take(query.take).ToListAsync();

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
