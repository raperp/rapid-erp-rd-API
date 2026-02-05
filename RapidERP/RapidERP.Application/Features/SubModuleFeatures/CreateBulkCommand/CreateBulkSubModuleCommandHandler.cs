using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SubModuleFeatures.CreateBulkCommand;

public class CreateBulkSubModuleCommandHandler(IRepository repository)
{
    public async Task<CreateBulkSubModuleCommandResponseModel> Handle(CreateBulkSubModuleCommandRequestModel request)
    {
        CreateBulkSubModuleCommandResponseModel _response = new();
        string name = string.Empty;

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<Submodule>(item.Name);

                if (isExists == false)
                {
                    Submodule masterData = new();
                    masterData.MainModuleId = item.MainModuleId;
                    //masterData.LanguageId = item.LanguageId;
                    masterData.Name = item.Name;
                    masterData.IconURL = item.IconURL;
                    masterData.SetSerial = item.SetSerial;

                    await repository.Add(masterData);

                    SubmoduleHistory history = new();
                    history.SubmoduleId = masterData.Id;
                    history.MainModuleId = item.MainModuleId;
                    //history.LanguageId = item.LanguageId;
                    history.ActionTypeId = item.ActionTypeId;
                    history.ExportTypeId = item.ExportTypeId;
                    history.ExportTo = item.ExportTo;
                    history.SourceURL = item.SourceURL;
                    history.Name = item.Name;
                    history.IconURL = item.IconURL;
                    history.SetSerial = item.SetSerial;
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
