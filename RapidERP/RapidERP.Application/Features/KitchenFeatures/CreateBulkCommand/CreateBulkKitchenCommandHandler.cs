using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.KitchenFeatures.CreateBulkCommand;

public class CreateBulkKitchenCommandHandler(IRepository repository)
{
    public async Task<CreateBulkKitchenCommandResponseModel> Handle(CreateBulkKitchenCommandRequestModel request)
    {
        CreateBulkKitchenCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<Kitchen>(item.Name);

                if (isExists == false)
                {
                    Kitchen masterData = new();
                    masterData.Name = item.Name;
                    masterData.Description = item.Description;
                    masterData.PrinterId = item.PrinterId;
                    masterData.StatusTypeId = item.StatusTypeId;
                    masterData.TenantId = item.TenantId;
                    masterData.MenuModuleId = item.MenuModuleId;

                    await repository.Add(masterData);

                    KitchenHistory history = new();
                    history.Name = item.Name;
                    history.Description = item.Description;
                    history.PrinterId = item.PrinterId;
                    history.KitchenId = masterData.Id;
                    history.TenantId = item.TenantId;
                    history.MenuModuleId = item.MenuModuleId;
                    history.ActionTypeId = item.ActionTypeId;
                    //history.ExportTypeId = item.ExportTypeId;
                    //history.ExportTo = item.ExportTo;
                    //history.SourceURL = item.SourceURL;
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
