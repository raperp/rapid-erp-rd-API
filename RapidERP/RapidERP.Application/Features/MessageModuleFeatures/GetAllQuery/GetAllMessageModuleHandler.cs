using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MessageModuleModels;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MessageModuleFeatures.GetAllQuery;

public class GetAllMessageModuleHandler(IRepository repository)
{
    GetAllMessageModuleResponseModel _response;

    public async Task<GetAllMessageModuleResponseModel> Handle(GetAllMessageModuleRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from mm in repository.Set<MessageModule>()
                        join tm in repository.Set<TextModule>() on mm.TextModuleId equals tm.Id
                        join l in repository.Set<Language>() on mm.LanguageId equals l.Id
                        select new GetAllMessageModuleResponseDTOModel
                        {
                            Id = tm.Id,
                            TextModule = tm.Name,
                            Language = l.Name,
                            Name = tm.Name
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<MessageModule>(query.pageSize);
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
                result.Count = await repository.GetCounts<MessageModule>(query.pageSize);
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
