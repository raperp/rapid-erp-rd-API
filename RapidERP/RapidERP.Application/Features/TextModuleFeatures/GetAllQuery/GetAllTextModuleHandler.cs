using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TextModuleFeatures.GetAllQuery;

public class GetAllTextModuleHandler(IRepository repository)
{
    GetAllTextModuleResponseModel _response;

    public async Task<GetAllTextModuleResponseModel> Handle(GetAllTextModuleRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from tm in repository.Set<TextModule>()
                        //join mm in repository.Set<MenuModule>() on tm.MenuModuleId equals mm.Id
                        //join l in repository.Set<Language>() on tm.LanguageId equals l.Id
                        select new GetAllTextModuleResponseDTOModel
                        {
                            Id = tm.Id,
                            //MenuModule = mm.Name,
                            //Language = l.Name,
                            Name = tm.Name
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<TextModule>();
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
                result.Count = await repository.GetCounts<TextModule>();
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
