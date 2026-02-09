using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Features.StateFeatures.GetSingleQuery;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StateFeatures.GetSingleQuery;

public class GetSingleStateHandler(IRepository repository)
{
    GetSingleStateResponseModel _response;

    public async Task<GetSingleStateResponseModel> Handle(GetSingleStateRequestModel query)
    {
        try
        {
            var data = (from s in repository.Set<State>()
                        join mm in repository.Set<MenuModule>() on s.CountryId equals mm.Id
                        join c in repository.Set<Country>() on s.CountryId equals c.Id
                        //join st in repository.Set<StatusType>() on s.StatusTypeId equals st.Id
                        //join l in repository.Set<Language>() on s.LanguageId equals l.Id
                        select new  
                        {
                            Id = s.Id,
                            Menu = mm.Name,
                            Country = c.Name,
                            //Status = st.Name,
                            //Language = l.Name,
                            Name = s.Name,
                            Code = s.Code,
                            IsDefault = s.IsDefault,
                            IsDraft = s.IsDraft
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
