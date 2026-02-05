using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MessageModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MessageModuleFeatures.CreateSingleCommand;

public class CreateSingleMessageModuleCommandHandler(IRepository repository)
{
    public async Task<CreateSingleMessageModuleCommandResponseModel> Handle(CreateSingleMessageModuleCommandRequestModel request)
    {
        CreateSingleMessageModuleCommandResponseModel _response; 
         
        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<MessageModule>(request.masterPOST.Name);

            if (isExists == false)
            {
                MessageModule masterData = new();
                masterData.TextModuleId = request.masterPOST.TextModuleId;
                //masterData.LanguageId = request.masterPOST.LanguageId;
                masterData.Name = request.masterPOST.Name;

                await repository.Add(masterData);

                MessageModuleHistory history = new();
                history.MessageModuleId = masterData.Id;
                history.TextModuleId = request.masterPOST.TextModuleId;
                //history.LanguageId = request.masterPOST.LanguageId;
                history.ActionTypeId = request.masterPOST.ActionTypeId;
                history.ExportTypeId = request.masterPOST.ExportTypeId;
                history.ExportTo = request.masterPOST.ExportTo;
                history.SourceURL = request.masterPOST.SourceURL;
                history.Name = request.masterPOST.Name;
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
