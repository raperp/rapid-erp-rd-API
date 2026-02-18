using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.LanguageFeatures.CreateSingleCommand;

public class CreateSingleLanguageCommandHandler(IRepository repository)
{
    public async Task<CreateSingleLanguageCommandResponseModel> Handle(CreateSingleLanguageCommandRequestModel request)
    {
        CreateSingleLanguageCommandResponseModel _response;
        string name = string.Empty;

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByName<Language>(request.masterPOST.Name);

            if (isExists == false)
            {
                Language masterData = new();
                masterData.ISONumeric = request.masterPOST.ISONumeric;
                masterData.Name = request.masterPOST.Name;
                masterData.ISO2Code = request.masterPOST.ISO2Code;
                masterData.ISO3Code = request.masterPOST.ISO3Code;
                masterData.IconURL = request.masterPOST.IconURL;

                await repository.Add(masterData); 

                LanguageHistory history = new();
                history.LanguageId = masterData.Id;
                history.ISONumeric = request.masterPOST.ISONumeric;
                history.Name = request.masterPOST.Name;
                history.ISO2Code = request.masterPOST.ISO2Code;
                history.ISO3Code = request.masterPOST.ISO3Code;
                history.IconURL = request.masterPOST.IconURL;
                //history.Browser = request.masterPOST.Browser;
                //history.Location = request.masterPOST.Location;
                //history.DeviceIP = request.masterPOST.DeviceIP;
                //history.LocationURL = request.masterPOST.LocationURL;
                //history.DeviceName = request.masterPOST.DeviceName;
                //history.Latitude = request.masterPOST.Latitude;
                //history.Longitude = request.masterPOST.Longitude;
                //history.ActionBy = request.masterPOST.ActionBy;
                //history.ActionAt = DateTime.UtcNow;

                await repository.Add(history); 
                transaction.Commit();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = request.masterPOST
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
