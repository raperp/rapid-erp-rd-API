using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TenantFeatures.GetAllQuery;

public class GetAllTenantHandler(IRepository repository)
{
    GetAllTenantResponseModel _response;

    public async Task<GetAllTenantResponseModel> Handle(GetAllTenantRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from t in repository.Set<Tenant>()
                        //join mm in repository.Set<MenuModule>() on t.MenuModuleId equals mm.Id
                        join c in repository.Set<Country>() on t.CountryId equals c.Id
                        join s in repository.Set<State>() on t.StateId equals s.Id
                        //join l in repository.Set<Language>() on t.LanguageId equals l.Id
                        //join st in repository.Set<StatusType>() on t.StatusTypeId equals st.Id
                        select new GetAllTenantResponseDTOModel
                        {
                            Id = t.Id,
                            //MenuModule = mm.Name,
                            Country = c.Name,
                            State = s.Name,
                            //Status = st.Name,
                            //Language = l.Name,
                            Name = t.Name,
                            Contact = t.Contact,
                            Phone = t.Phone,
                            Mobile = t.Mobile,
                            Address = t.Address,
                            Email = t.Email,
                            Website = t.Website
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<Tenant>();
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
                result.Count = await repository.GetCounts<Tenant>();
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
