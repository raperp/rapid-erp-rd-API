using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Features.MainModuleFeatures.GetAllQuery;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MainModuleFeatures.GetSingleQuery;

public class GetSingleMainModuleHandler(IRepository repository)
{
    GetSingleMainModuleResponseModel _response;

    public async Task<GetSingleMainModuleResponseModel> Handle(GetSingleMainModuleRequestModel request)
    {
        try
        {
            var data = (from mm in repository.Set<MainModule>()
                        join l in repository.Set<Language>() on mm.LanguageId equals l.Id
                        select new GetSingleMainModuleResponseDTOModel
                        {
                            Id = mm.Id,
                            Language = l.Name,
                            Name = mm.Name,
                            Prefix = mm.Prefix,
                            IconURL = mm.IconURL,
                            SetSerial = mm.SetSerial
                        }).AsNoTracking().AsQueryable();

            var result = data.Where(x => x.Id == request.id).ToListAsync();

            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = result.Result.FirstOrDefault()
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
