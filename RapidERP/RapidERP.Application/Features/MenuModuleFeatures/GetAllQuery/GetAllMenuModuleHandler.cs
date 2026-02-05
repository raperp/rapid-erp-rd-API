using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MenuModuleFeatures.GetAllQuery;

public class GetAllMenuModuleHandler(IRepository repository)
{
    GetAllMenuModuleResponseModel _response;

    public async Task<GetAllMenuModuleResponseModel> Handle(GetAllMenuModuleRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from mm in repository.Set<MenuModule>()
                        join sm in repository.Set<Submodule>() on mm.SubmoduleId equals sm.Id
                        //join l in repository.Set<Language>() on mm.LanguageId equals l.Id
                        select new GetAllMenuModuleResponseDTOModel
                        {
                            Id = mm.Id,
                            Submodule = sm.Name,
                            //Language = l.Name,
                            Name = mm.Name,
                            IconURL = mm.IconURL,
                            SetSerial = mm.SetSerial
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<MenuModule>(query.pageSize);
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
                result.Count = await repository.GetCounts<MenuModule>(query.pageSize);
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
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _response;
        }
    }
}
