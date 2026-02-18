using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.KitchenFeatures.CreateSingleCommand;

public class CreateSingleKitchenCommandHandler(IRepository repository)
{
    public async Task<CreateSingleKitchenCommandResponseModel> Handle(CreateSingleKitchenCommandRequestModel request)
    {
        CreateSingleKitchenCommandResponseModel _response;

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByName<Kitchen>(request.masterPOST.Name);

            if (isExists == false)
            {
                Kitchen masterData = new();
                masterData.Name = request.masterPOST.Name;
                masterData.Description = request.masterPOST.Description;
                masterData.PrinterId = request.masterPOST.PrinterId;
                //masterData.StatusTypeId = request.masterPOST.StatusTypeId;
                masterData.TenantId = request.masterPOST.TenantId;
                //masterData.MenuModuleId = request.masterPOST.MenuModuleId;

                await repository.Add(masterData);

                KitchenHistory history = new();
                history.Name = request.masterPOST.Name;
                history.Description = request.masterPOST.Description;
                history.PrinterId = request.masterPOST.PrinterId;
                history.KitchenId = masterData.Id;
                //history.TenantId = request.masterPOST.TenantId;
                //history.MenuModuleId = request.masterPOST.MenuModuleId;
                //history.ActionTypeId = request.masterPOST.ActionTypeId;
                //history.ExportTypeId = request.masterPOST.ExportTypeId;
                //history.ExportTo = request.masterPOST.ExportTo;
                //history.SourceURL = request.masterPOST.SourceURL;
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
