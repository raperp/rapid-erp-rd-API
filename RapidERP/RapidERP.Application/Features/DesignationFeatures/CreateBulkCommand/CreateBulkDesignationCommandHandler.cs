using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DesignationModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DesignationFeatures.CreateBulkCommand;

public class CreateBulkDesignationCommandHandler(IRepository repository)
{
    public async Task<CreateBulkDesignationCommandResponseModel> Handle(CreateBulkDesignationCommandRequestModel request)
    {
        CreateBulkDesignationCommandResponseModel _response = new();
        string name = string.Empty;

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExistsByName<Designation>(item.Name);

                if (isExists == false)
                {
                    Designation masterData = new();
                    masterData.Name = item.Name;
                    masterData.Description = item.Description;
                    masterData.DepartmentId = item.DepartmentId;
                    //masterData.StatusTypeId = item.StatusTypeId;
                    //masterData.MenuModuleId = item.MenuModuleId;
                    masterData.TenantId = item.TenantId;
                    //masterData.LanguageId = item.LanguageId;

                    await repository.Add(masterData);

                    DesignationHistory history = new();
                    history.DesignationId = masterData.Id;
                    history.Name = item.Name;
                    history.Description = item.Description;
                    history.DepartmentId = item.DepartmentId;
                    //history.TenantId = item.TenantId;
                    //history.MenuModuleId = item.MenuModuleId;
                    //history.ActionTypeId = item.ActionTypeId;
                    //history.LanguageId = item.LanguageId;
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
                        Message = $"{ResponseMessage.RecordExists} {name}"
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
