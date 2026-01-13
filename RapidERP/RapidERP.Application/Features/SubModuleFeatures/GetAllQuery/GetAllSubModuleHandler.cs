using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Features.SubModuleFeatures.GetAllQuery;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SubModuleFeatures.GetAllQuery;

public class GetAllSubModuleHandler(IRepository repository)
{
    GetAllSubModuleResponseModel _response;

    public async Task<GetAllSubModuleResponseModel> Handle(GetAllSubModuleRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from sm in repository.Set<Submodule>()
                        join mm in repository.Set<MainModule>() on sm.MainModuleId equals mm.Id
                        join l in repository.Set<Language>() on sm.LanguageId equals l.Id
                        select new GetAllSubModuleResponseDTOModel
                        {
                            Id = sm.Id,
                            MainModule = mm.Name,
                            Language = l.Name,
                            Name = sm.Name,
                            IconURL = sm.IconURL,
                            SetSerial = sm.SetSerial
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<Submodule>(query.pageSize);
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
                result.Count = await repository.GetCounts<Submodule>(query.pageSize);
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
