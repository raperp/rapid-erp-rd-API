using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MessageModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MessageModuleFeatures.CreateBulkCommand;

public class CreateBulkMessageModuleCommandHandler(IRepository repository)
{
    public async Task<CreateBulkMessageModuleCommandResponseModel> Handle(CreateBulkMessageModuleCommandRequestModel request)
    {
        CreateBulkMessageModuleCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<MessageModule>(item.Name);

                if (isExists == false)
                {
                    MessageModule masterData = new();
                    masterData.TextModuleId = item.TextModuleId;
                    masterData.LanguageId = item.LanguageId;
                    masterData.Name = item.Name;

                    await repository.Add(masterData);

                    MessageModuleHistory history = new();
                    history.MessageModuleId = masterData.Id;
                    history.TextModuleId = item.TextModuleId;
                    history.LanguageId = item.LanguageId;
                    history.ActionTypeId = item.ActionTypeId;
                    history.ExportTypeId = item.ExportTypeId;
                    history.ExportTo = item.ExportTo;
                    history.SourceURL = item.SourceURL;
                    history.Name = item.Name;
                    history.Browser = item.Browser;
                    history.Location = item.Location;
                    history.DeviceIP = item.DeviceIP;
                    history.LocationURL = item.LocationURL;
                    history.DeviceName = item.DeviceName;
                    history.Latitude = item.Latitude;
                    history.Longitude = item.Longitude;
                    history.ActionBy = item.ActionBy;
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
