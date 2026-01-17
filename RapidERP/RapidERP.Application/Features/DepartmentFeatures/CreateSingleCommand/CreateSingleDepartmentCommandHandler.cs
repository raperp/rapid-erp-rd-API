using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DepartmentFeatures.CreateSingleCommand;

public class CreateSingleDepartmentCommandHandler(IRepository repository)
{
    public async Task<CreateSingleDepartmentCommandResponseModel> Handle(CreateSingleDepartmentCommandRequestModel request)
    {
        CreateSingleDepartmentCommandResponseModel _response;

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<Department>(request.masterPOST.Name);

            if (isExists == false)
            {
                Department masterData = new();
                masterData.Name = request.masterPOST.Name;
                masterData.Description = request.masterPOST.Description;
                masterData.StatusTypeId = request.masterPOST.StatusTypeId;
                masterData.TenantId = request.masterPOST.TenantId;
                masterData.MenuModuleId = request.masterPOST.MenuModuleId;
                masterData.LanguageId = request.masterPOST.LanguageId;
                masterData.IsDefault = request.masterPOST.IsDefault;
                masterData.IsDraft = request.masterPOST.IsDraft;

                await repository.Add(masterData);

                DepartmentHistory history = new();
                history.DepartmentId = masterData.Id;
                history.Name = request.masterPOST.Name;
                history.Description = request.masterPOST.Description;
                history.TenantId = request.masterPOST.TenantId;
                history.MenuModuleId = request.masterPOST.MenuModuleId;
                history.LanguageId = request.masterPOST.LanguageId;
                history.ActionTypeId = request.masterPOST.ActionTypeId;
                history.ExportTypeId = request.masterPOST.ExportTypeId;
                history.ExportTo = request.masterPOST.ExportTo;
                history.SourceURL = request.masterPOST.SourceURL;
                history.IsDefault = request.masterPOST.IsDefault;
                history.IsDraft = request.masterPOST.IsDraft;
                history.Browser = request.masterPOST.Browser;
                history.Location = request.masterPOST.Location;
                history.DeviceIP = request.masterPOST.DeviceIP;
                history.LocationURL = request.masterPOST.LocationURL;
                history.DeviceName = request.masterPOST.DeviceName;
                history.Latitude = request.masterPOST.Latitude;
                history.Longitude = request.masterPOST.Longitude;
                history.ActionBy = request.masterPOST.ActionBy;
                history.ActionAt = DateTime.Now;

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
                    Message = $"{ResponseMessage.RecordExists} {request.masterPOST.Name}"
                };
            }

            return _response;
        }

        catch
        {
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return _response;
        }
    }
}
