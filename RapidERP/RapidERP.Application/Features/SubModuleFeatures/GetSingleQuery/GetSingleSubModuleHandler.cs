using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SubModuleFeatures.GetSingleQuery;

public class GetSingleSubModuleHandler(IRepository repository)
{
    GetSingleSubModuleResponseModel _response;

    public async Task<GetSingleSubModuleResponseModel> Handle(GetSingleSubModuleRequestModel query)
    {
        try
        {
            var data = (from sm in repository.Set<Submodule>()
                        join mm in repository.Set<MainModule>() on sm.MainModuleId equals mm.Id
                        //join l in repository.Set<Language>() on sm.LanguageId equals l.Id
                        select new GetSingleSubModuleResponseDTOModel
                        {
                            Id = sm.Id,
                            MainModule = mm.Name,
                            //Language = l.Name,
                            Name = sm.Name,
                            IconURL = sm.IconURL,
                            SetSerial = sm.SetSerial
                        }).AsNoTracking().AsQueryable();


            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = data.ToListAsync()
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
