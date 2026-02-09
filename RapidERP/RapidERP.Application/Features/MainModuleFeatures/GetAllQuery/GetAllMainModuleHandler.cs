using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MainModuleFeatures.GetAllQuery;

public class GetAllMainModuleHandler(IRepository repository)
{
    GetAllMainModuleResponseModel _response;

    public async Task<GetAllMainModuleResponseModel> Handle(GetAllMainModuleRequestModel query)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from mm in repository.Set<MainModule>()
                        //join l in repository.Set<Language>() on mm.LanguageId equals l.Id
                        select new GetAllMainModuleResponseDTOModel
                        {
                            Id = mm.Id,
                            //Language = l.Name,
                            Name = mm.Name,
                            Prefix = mm.Prefix,
                            IconURL = mm.IconURL,
                            SetSerial = mm.SetSerial
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                result.Count = await repository.GetCounts<MainModule>();
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
                result.Count = await repository.GetCounts<MainModule>();
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
