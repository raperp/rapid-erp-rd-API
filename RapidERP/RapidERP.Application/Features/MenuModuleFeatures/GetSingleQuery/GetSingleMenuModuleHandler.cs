using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MenuModuleFeatures.GetSingleQuery;

public class GetSingleMenuModuleHandler(IRepository repository)
{
    GetSingleMenuModuleResponseModel _response;

    public async Task<GetSingleMenuModuleResponseModel> Handle(GetSingleMenuModuleRequestModel query)
    {
        try
        {
            var data = (from mm in repository.Set<MenuModule>()
                        join sm in repository.Set<Submodule>() on mm.SubmoduleId equals sm.Id
                        join l in repository.Set<Language>() on mm.LanguageId equals l.Id
                        select new GetSingleMenuModuleResponseDTOModel
                        {
                            Id = mm.Id,
                            Submodule = sm.Name,
                            Language = l.Name,
                            Name = mm.Name,
                            IconURL = mm.IconURL,
                            SetSerial = mm.SetSerial
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
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _response;
        }
    }
}
