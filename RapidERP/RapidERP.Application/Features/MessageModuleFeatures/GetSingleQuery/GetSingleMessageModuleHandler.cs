using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MessageModuleModels;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MessageModuleFeatures.GetSingleQuery;

public class GetSingleMessageModuleHandler(IRepository repository)
{
    GetSingleMessageModuleResponseModel _response;

    public async Task<GetSingleMessageModuleResponseModel> Handle(GetSingleMessageModuleRequestModel query)
    {
        try
        {
            var data = (from mm in repository.Set<MessageModule>()
                        join tm in repository.Set<TextModule>() on mm.TextModuleId equals tm.Id
                        join l in repository.Set<Language>() on mm.LanguageId equals l.Id
                        select new GetSingleMessageModuleResponseDTOModel
                        {
                            Id = tm.Id,
                            TextModule = tm.Name,  
                            Language = l.Name,
                            Name = tm.Name
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
