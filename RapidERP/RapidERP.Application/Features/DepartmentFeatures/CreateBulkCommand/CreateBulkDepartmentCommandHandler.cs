using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DepartmentFeatures.CreateBulkCommand;

public class CreateBulkDepartmentCommandHandler(IRepository repository)
{
    public async Task<CreateBulkDepartmentCommandResponseModel> Handle(CreateBulkDepartmentCommandRequestModel request)
    {
        CreateBulkDepartmentCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<Department>(item.Name);

                if (isExists == false)
                {
                    Department masterData = new();
                    masterData.Name = item.Name;
                    masterData.Description = item.Description;
                    //masterData.StatusTypeId = item.StatusTypeId;
                    masterData.TenantId = item.TenantId;
                    //masterData.MenuModuleId = item.MenuModuleId;
                    //masterData.LanguageId = item.LanguageId;
                    masterData.IsDefault = item.IsDefault;
                    //masterData.IsDraft = item.IsDraft;

                    await repository.Add(masterData);

                    DepartmentHistory history = new();
                    history.DepartmentId = masterData.Id;
                    history.Name = item.Name;
                    history.Description = item.Description;
                    //history.TenantId = item.TenantId;
                    //history.MenuModuleId = item.MenuModuleId;
                    //history.LanguageId = item.LanguageId;
                    //history.ActionTypeId = item.ActionTypeId;
                    //history.ExportTypeId = item.ExportTypeId;
                    //history.ExportTo = item.ExportTo;
                    //history.SourceURL = item.SourceURL;
                    history.IsDefault = item.IsDefault;
                    //history.IsDraft = item.IsDraft;
                    //history.Browser = item.Browser;
                    //history.Location = item.Location;
                    //history.DeviceIP = item.DeviceIP;
                    //history.LocationURL = item.LocationURL;
                    //history.DeviceName = item.DeviceName;
                    //history.Latitude = item.Latitude;
                    //history.Longitude = item.Longitude;
                    //history.ActionBy = item.ActionBy;
                    //history.ActionAt = DateTime.Now;

                    await repository.Add(history);
                    transaction.Commit();

                    _response = new()
                    {
                        StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                        IsSuccess = true,
                        Message = ResponseMessage.CreateSuccess,
                        Data = request
                    };
                }

                else
                {
                    _response = new()
                    {
                        StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                        IsSuccess = false,
                        Message = $"{ResponseMessage.RecordExists} {item.Name}"
                    };
                }
            }

            return _response;
        }

        catch
        {
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return _response;
        }
    }
}
