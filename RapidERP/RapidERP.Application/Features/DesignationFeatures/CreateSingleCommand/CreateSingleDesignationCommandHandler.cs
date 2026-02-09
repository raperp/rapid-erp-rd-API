using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DesignationModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DesignationFeatures.CreateSingleCommand;

public class CreateSingleDesignationCommandHandler(IRepository repository)
{
    public async Task<CreateSingleDesignationCommandResponseModel> Handle(CreateSingleDesignationCommandRequestModel request)
    {
        CreateSingleDesignationCommandResponseModel _response;

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<Designation>(request.masterPOST.Name);

            if (isExists == false)
            {
                Designation masterData = new();
                masterData.Name = request.masterPOST.Name;
                masterData.Description = request.masterPOST.Description;
                masterData.DepartmentId = request.masterPOST.DepartmentId;
                //masterData.StatusTypeId = request.masterPOST.StatusTypeId;
                //masterData.MenuModuleId = request.masterPOST.MenuModuleId;
                masterData.TenantId = request.masterPOST.TenantId;
                //masterData.LanguageId = request.masterPOST.LanguageId;

                await repository.Add(masterData);

                DesignationHistory history = new();
                history.DesignationId = masterData.Id;
                history.Name = request.masterPOST.Name;
                history.Description = request.masterPOST.Description;
                history.DepartmentId = request.masterPOST.DepartmentId;
                //history.TenantId = request.masterPOST.TenantId;
                //history.MenuModuleId = request.masterPOST.MenuModuleId;
                //history.ActionTypeId = request.masterPOST.ActionTypeId;
                //history.LanguageId = request.masterPOST.LanguageId;
                //history.ExportTypeId = request.masterPOST.ExportTypeId;
                //history.ExportTo = request.masterPOST.ExportTo;
                //history.SourceURL = request.masterPOST.SourceURL;
                history.IsDefault = request.masterPOST.IsDefault;
                history.IsDraft = request.masterPOST.IsDraft;
                //history.Browser = request.masterPOST.Browser;
                //history.Location = request.masterPOST.Location;
                //history.DeviceIP = request.masterPOST.DeviceIP;
                //history.LocationURL = request.masterPOST.LocationURL;
                //history.DeviceName = request.masterPOST.DeviceName;
                //history.Latitude = request.masterPOST.Latitude;
                //history.Longitude = request.masterPOST.Longitude;
                //history.ActionBy = request.masterPOST.ActionBy;
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
