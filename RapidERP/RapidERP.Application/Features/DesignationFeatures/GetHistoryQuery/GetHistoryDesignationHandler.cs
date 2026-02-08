using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Entities.DesignationModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DesignationFeatures.GetHistoryQuery;

public class GetHistoryDesignationHandler(IRepository repository)
{
    GetHistoryDesignationResponseModel _response;

    public async Task<GetHistoryDesignationResponseModel> Handle(GetHistoryDesignationRequestModel query)
    {
        try
        {
            GetHistoryDTO result = new();

            var data = (from dh in repository.Set<DesignationHistory>()
                        join des in repository.Set<Designation>() on dh.DesignationId equals des.Id
                        join dep in repository.Set<Department>() on dh.DepartmentId equals dep.Id
                        //join et in repository.Set<ExportType>() on dh.ExportTypeId equals et.Id
                        join at in repository.Set<ActionType>() on dh.ActionTypeId equals at.Id
                        //join t in repository.Set<Tenant>() on dh.TenantId equals t.Id
                        //join l in repository.Set<Language>() on dh.LanguageId equals l.Id
                        //join mm in repository.Set<MenuModule>() on dh.MenuModuleId equals mm.Id
                        select new GetHistoryDesignationResponseDTOModel
                        {
                            Id = dh.Id,
                            Department = dep.Name,
                            Designation = des.Name,
                            Name = dh.Name,
                            Description = dh.Description,
                            //Tanent = t.Name,
                            //MenuModule = mm.Name,
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
