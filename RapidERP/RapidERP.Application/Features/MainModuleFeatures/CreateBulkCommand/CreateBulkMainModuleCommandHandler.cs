using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MainModuleFeatures.CreateBulkCommand;

public class CreateBulkMainModuleCommandHandler(IRepository repository)
{
    public async Task<CreateBulkMainModuleCommandResponseModel> Handle(CreateBulkMainModuleCommandRequestModel request)
    {
        CreateBulkMainModuleCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<MainModule>(item.Name);

                if (isExists == false)
                {
                    MainModule masterData = new();
                    masterData.LanguageId = item.LanguageId;
                    masterData.Name = item.Name;
                    masterData.Prefix = item.Prefix;
                    masterData.IconURL = item.IconURL;
                    masterData.SetSerial = item.SetSerial;

                    await repository.Add(masterData);

                    MainModuleHistory history = new();
                    history.MainModuleId = masterData.Id;
                    history.LanguageId = item.LanguageId;
                    history.ActionTypeId = item.ActionTypeId;
                    history.ExportTypeId = item.ExportTypeId;
                    history.ExportTo = item.ExportTo;
                    history.SourceURL = item.SourceURL;
                    history.Name = item.Name;
                    history.Prefix = item.Prefix;
                    history.IconURL = item.IconURL;
                    history.SetSerial = item.SetSerial;
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
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return _response;
        }
    }
}
