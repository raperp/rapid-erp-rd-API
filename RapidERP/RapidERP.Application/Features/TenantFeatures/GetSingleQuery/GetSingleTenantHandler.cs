using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TenantFeatures.GetSingleQuery;

public class GetSingleTenantHandler(IRepository repository)
{
    GetSingleTenantResponseModel _response;

    public async Task<GetSingleTenantResponseModel> Handle(GetSingleTenantRequestModel query)
    {
        try
        {
            var data = (from t in repository.Set<Tenant>()
                        //join mm in repository.Set<MenuModule>() on t.MenuModuleId equals mm.Id
                        join c in repository.Set<Country>() on t.CountryId equals c.Id
                        join s in repository.Set<State>() on t.StateId equals s.Id
                        //join l in repository.Set<Language>() on t.LanguageId equals l.Id
                        //join st in repository.Set<StatusType>() on t.StatusTypeId equals st.Id
                        select new GetSingleTenantResponseDTOModel
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
