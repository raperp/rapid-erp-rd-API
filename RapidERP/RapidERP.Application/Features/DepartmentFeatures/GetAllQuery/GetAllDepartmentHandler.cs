using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DepartmentFeatures.GetAllQuery;

public class GetAllDepartmentHandler(IRepository repository)
{
    GetAllDepartmentResponseModel _response;

    public async Task<GetAllDepartmentResponseModel> Handle(GetAllDepartmentRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from d in repository.Set<Department>()
                        join st in repository.Set<StatusType>() on d.StatusTypeId equals st.Id
                        join t in repository.Set<Tenant>() on d.TenantId equals t.Id
                        //join l in repository.Set<Language>() on d.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on d.MenuModuleId equals mm.Id
                        select new GetAllDepartmentResponseDTOModel
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Description = d.Description,
                            MenuModule = mm.Name,
                            Tanent = t.Name,
                            //Language = l.Name,
                            Status = st.Name
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<Department>(query.pageSize);
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
                result.Count = await repository.GetCounts<Department>(query.pageSize);
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
