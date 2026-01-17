using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SolutionModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SolutionFeatures.GetSingleQuery;

public class GetSingleSolutionHandler(IRepository repository)
{
    GetSingleSolutionResponseModel _response;

    public async Task<GetSingleSolutionResponseModel> Handle(GetSingleSolutionRequestModel query)
    {
        try
        {
            var data = (from c in repository.Set<Solution>()
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        join mm in repository.Set<MenuModule>() on c.MenuModuleId equals mm.Id
                        join l in repository.Set<Language>() on c.LanguageId equals l.Id
                        join st in repository.Set<StatusType>() on c.StatusTypeId equals st.Id
                        select new GetSingleSolutionResponseDTOModel
                        {
                            Id = c.Id,
                            Tenant = t.Name,
                            MenuModule = mm.Name,
                            Language = l.Name,
                            Status = st.Name,
                            Code = c.Code,
                            Name = c.Name,
                            Icon = c.Icon,
                            Description = c.Description
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
