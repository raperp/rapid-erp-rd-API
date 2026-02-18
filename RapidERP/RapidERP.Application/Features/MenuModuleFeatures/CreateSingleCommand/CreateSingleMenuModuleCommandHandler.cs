using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MenuModuleFeatures.CreateSingleCommand;

public class CreateSingleMenuModuleCommandHandler(IRepository repository)
{
    public async Task<CreateSingleMenuModuleCommandResponseModel> Handle(CreateSingleMenuModuleCommandRequestModel request)
    {
        CreateSingleMenuModuleCommandResponseModel _response; 

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByName<MenuModule>(request.masterPOST.Name);

            if (isExists == false)
            {
                MenuModule masterData = new();
                masterData.SubmoduleId = request.masterPOST.SubmoduleId;
                //masterData.LanguageId = request.masterPOST.LanguageId;
                masterData.Name = request.masterPOST.Name;
                masterData.IconURL = request.masterPOST.IconURL;
                masterData.SetSerial = request.masterPOST.SetSerial;

                await repository.Add(masterData);

                MenuModuleHistory history = new();
                history.MenuModuleId = masterData.Id;
                history.SubmoduleId = request.masterPOST.SubmoduleId;
                //history.LanguageId = request.masterPOST.LanguageId;
                history.ActionTypeId = request.masterPOST.ActionTypeId;
                //history.ExportTypeId = request.masterPOST.ExportTypeId;
                //history.ExportTo = request.masterPOST.ExportTo;
                //history.SourceURL = request.masterPOST.SourceURL;
                history.Name = request.masterPOST.Name;
                history.IconURL = request.masterPOST.IconURL;
                history.SetSerial = request.masterPOST.SetSerial;
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
