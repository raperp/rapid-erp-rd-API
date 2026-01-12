using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Features.MainModuleFeatures.GetHistoryQuery;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using Microsoft.EntityFrameworkCore;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MainModuleFeatures.GetHistoryQuery;

public class GetHistoryMainModuleHandler(IRepository repository)
{
    GetHistoryMainModuleResponseModel _response;

    public async Task<GetHistoryMainModuleResponseModel> Handle(GetHistoryMainModuleRequestModel query)
    {
        try
        {
            GetHistoryDTO result = new();

            var data = (from mma in repository.Set<MainModuleHistory>()
                        join mm in repository.Set<MainModule>() on mma.MainModuleId equals mm.Id
                        join l in repository.Set<Language>() on mma.LanguageId equals l.Id
                        join at in repository.Set<ActionType>() on mma.ActionTypeId equals at.Id
                        join et in repository.Set<ExportType>() on mma.ExportTypeId equals et.Id
                        select new GetHistoryMainModuleResponseDTOModel
                        {
                            Id = mma.Id,
                            MainModule = mm.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            ExportTo = mma.ExportTo,
                            SourceURL = mma.SourceURL,
                            Name = mma.Name,
                            Prefix = mma.Prefix,
                            IconURL = mma.IconURL,
                            SetSerial = mma.SetSerial,
                            Browser = mma.Browser,
                            Location = mma.Location,
                            DeviceIP = mma.DeviceIP,
                            LocationURL = mma.LocationURL,
                            DeviceName = mma.DeviceName,
                            Latitude = mma.Latitude,
                            Longitude = mma.Longitude,
                            ActionBy = mma.ActionBy,
                            ActionAt = mma.ActionAt
                        }).AsNoTracking().AsQueryable();

            //int totalItems = await repository.Set<MainModuleHistory>().CountAsync();
            //int totalPages = (totalItems + query.pageSize - 1) / query.pageSize;

            if (query.skip == 0 || query.take == 0)
            {
                //result.TotalCount = totalItems;
                //result.TotalPages = totalPages;
                result.Data = await data.ToListAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result.Data
                };
            }

            else
            {
                //result.TotalCount = totalItems;
                //result.TotalPages = totalPages;
                result.Data = await data.Skip(query.skip).Take(query.take).ToListAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result.Data
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
