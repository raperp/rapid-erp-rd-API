using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MenuModuleFeatures.CreateBulkCommand;

public class CreateBulkMenuModuleCommandHandler(IRepository repository)
{
    public async Task<CreateBulkMenuModuleCommandResponseModel> Handle(CreateBulkMenuModuleCommandRequestModel request)
    {
        CreateBulkMenuModuleCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<MenuModule>(item.Name);

                if (isExists == false)
                {
                    MenuModule masterData = new();
                    masterData.SubmoduleId = item.SubmoduleId;
                    //masterData.LanguageId = item.LanguageId;
                    masterData.Name = item.Name;
                    masterData.IconURL = item.IconURL;
                    masterData.SetSerial = item.SetSerial;

                    await repository.Add(masterData);

                    MenuModuleHistory history = new();
                    history.MenuModuleId = masterData.Id;
                    history.SubmoduleId = item.SubmoduleId;
                    //history.LanguageId = item.LanguageId;
                    history.ActionTypeId = item.ActionTypeId;
                    //history.ExportTypeId = item.ExportTypeId;
                    //history.ExportTo = item.ExportTo;
                    //history.SourceURL = item.SourceURL;
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
                        Data = request.masterPOSTs
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
