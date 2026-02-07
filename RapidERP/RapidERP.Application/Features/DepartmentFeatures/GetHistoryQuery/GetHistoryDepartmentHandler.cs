using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DepartmentFeatures.GetHistoryQuery;

public class GetHistoryDepartmentHandler(IRepository repository)
{
    GetHistoryDepartmentResponseModel _response;

    public async Task<GetHistoryDepartmentResponseModel> Handle(GetHistoryDepartmentRequestModel query)
    {
        try
        {
            var data = (from dh in repository.Set<DepartmentHistory>()
                        join d in repository.Set<Department>() on dh.DepartmentId equals d.Id
                        //join et in repository.Set<ExportType>() on dh.ExportTypeId equals et.Id
                        join at in repository.Set<ActionType>() on dh.ActionTypeId equals at.Id
                        join t in repository.Set<Tenant>() on dh.TenantId equals t.Id
                        //join l in repository.Set<Language>() on dh.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on dh.MenuModuleId equals mm.Id
                        select new GetHistoryDepartmentResponseDTOModel
                        {
                            Id = dh.Id,
                            Department = d.Name,
                            Name = dh.Name,
                            Description = dh.Description,
                            Tanent = t.Name,
                            MenuModule = mm.Name,
                            Action = at.Name,
                            //Language = l.Name,
                            //ExportType = et.Name,
                            //ExportTo = dh.ExportTo,
                            //SourceURL = dh.SourceURL,
                            IsDefault = dh.IsDefault,
                            IsDraft = dh.IsDraft,
                            //Browser = dh.Browser,
                            //Location = dh.Location,
                            //DeviceIP = dh.DeviceIP,
                            //LocationURL = dh.LocationURL,
                            //DeviceName = dh.DeviceName,
                            //Latitude = dh.Latitude,
                            //Longitude = dh.Longitude,
                            //ActionBy = dh.ActionBy,
                            //ActionAt = dh.ActionAt
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                var result = await data.ToListAsync();

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
                var result = await data.Skip(query.skip).Take(query.take).ToListAsync();

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
