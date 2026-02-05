using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ExportTypeFeatures.CreateSingleCommand;

public class CreateSingleExportTypeCommandHandler(IRepository repository)
{
    public async Task<CreateSingleExportTypeCommandResponseModel> Handle(CreateSingleExportTypeCommandRequestModel request)
    {
        CreateSingleExportTypeCommandResponseModel _response;
        string name = string.Empty;

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<ExportType>(request.masterPOST.Name);

            if (isExists == false)
            {
                ExportType masterData = new();
                //masterData.LanguageId = request.masterPOST.LanguageId;
                masterData.Name = request.masterPOST.Name;
                masterData.Description = request.masterPOST.Description;

                await repository.Add(masterData); 

                ExportTypeHistory history = new();
                history.ExportTypeId = masterData.Id;
                //history.LanguageId = request.masterPOST.LanguageId;
                history.Name = request.masterPOST.Name;
                history.Description = request.masterPOST.Description;
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
                    Message = $"{ResponseMessage.RecordExists} {name}"
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
