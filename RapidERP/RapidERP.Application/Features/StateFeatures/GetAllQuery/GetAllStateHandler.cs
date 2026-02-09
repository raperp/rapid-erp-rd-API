using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StateFeatures.GetAllQuery;

public class GetAllStateHandler(IRepository repository)
{
    GetAllStateResponseModel _response;

    public async Task<GetAllStateResponseModel> Handle(GetAllStateRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

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

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<State>();
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
                result.Count = await repository.GetCounts<State>();
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
