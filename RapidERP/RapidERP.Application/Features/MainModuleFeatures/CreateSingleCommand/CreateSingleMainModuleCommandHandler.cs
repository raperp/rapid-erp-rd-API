using RapidERP.Application.Features.MainModuleFeatures.CreateSingleCommand;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MainModuleFeatures.CreateSingleCommand;

public class CreateSingleMainModuleCommandHandler(IRepository repository)
{
    public async Task<CreateSingleMainModuleCommandResponseModel> Handle(CreateSingleMainModuleCommandRequestModel request)
    {
        CreateSingleMainModuleCommandResponseModel _response; 

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<MainModule>(request.masterPOST.Name);

            if (isExists == false)
            {
                MainModule masterData = new();
                masterData.LanguageId = request.masterPOST.LanguageId;
                masterData.Name = request.masterPOST.Name;
                masterData.Prefix = request.masterPOST.Prefix;
                masterData.IconURL = request.masterPOST.IconURL;
                masterData.SetSerial = request.masterPOST.SetSerial;

                await repository.Add(masterData);

                MainModuleHistory history = new();
                history.MainModuleId = masterData.Id;
                history.LanguageId = request.masterPOST.LanguageId;
                history.ActionTypeId = request.masterPOST.ActionTypeId;
                history.ExportTypeId = request.masterPOST.ExportTypeId;
                history.ExportTo = request.masterPOST.ExportTo;
                history.SourceURL = request.masterPOST.SourceURL;
                history.Name = request.masterPOST.Name;
                history.Prefix = request.masterPOST.Prefix;
                history.IconURL = request.masterPOST.IconURL;
                history.SetSerial = request.masterPOST.SetSerial;
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
