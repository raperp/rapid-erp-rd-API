using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TextModuleFeatures.GetSingleQuery;

public record GetSingleTextModuleHandler(IRepository repository)
{
    GetSingleTextModuleResponseModel _response;

    public async Task<GetSingleTextModuleResponseModel> Handle(GetSingleTextModuleRequestModel query)
    {
        try
        { 
            var data = (from tm in repository.Set<TextModule>()
                        //join mm in repository.Set<MenuModule>() on tm.MenuModuleId equals mm.Id
                        //join l in repository.Set<Language>() on tm.LanguageId equals l.Id
                        select new GetSingleTextModuleResponseDTOModel
                        {
                            Id = tm.Id,
                            //MenuModule = mm.Name,
                            //Language = l.Name,
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
