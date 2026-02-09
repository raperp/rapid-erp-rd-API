using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DepartmentFeatures.GetSingleQuery;

public record GetSingleDepartmentHandler(IRepository repository)
{
    GetSingleDepartmentResponseModel _response;

    public async Task<GetSingleDepartmentResponseModel> Handle(GetSingleDepartmentRequestModel query)
    {
        try
        {
            var data = (from d in repository.Set<Department>()
                        //join st in repository.Set<StatusType>() on d.StatusTypeId equals st.Id
                        join t in repository.Set<Tenant>() on d.TenantId equals t.Id
                        //join l in repository.Set<Language>() on d.LanguageId equals l.Id
                        //join mm in repository.Set<MenuModule>() on d.MenuModuleId equals mm.Id
                        select new GetSingleDepartmentResponseDTOModel
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Description = d.Description,
                            //MenuModule = mm.Name,
                            Tanent = t.Name,
                            //Language = l.Name,
                            //Status = st.Name
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
