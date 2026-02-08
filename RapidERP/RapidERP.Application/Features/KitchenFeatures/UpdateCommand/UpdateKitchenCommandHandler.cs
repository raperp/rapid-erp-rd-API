using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.KitchenFeatures.UpdateCommand;

public class UpdateKitchenCommandHandler(IRepository repository)
{
    UpdateKitchenCommandResponseModel _response;

    public async Task<UpdateKitchenCommandResponseModel> Handle(UpdateKitchenCommandRequestModel request)
    {
        try
        { 
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<Kitchen>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<Kitchen>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;
                request.masterPUT.Description = (request.masterPUT.Description is not null) ? request.masterPUT.Description : masterRecord.Description;
                request.masterPUT.PrinterId = (request.masterPUT.PrinterId != 0) ? request.masterPUT.PrinterId : masterRecord.PrinterId;
                request.masterPUT.StatusTypeId = (request.masterPUT.StatusTypeId != 0) ? request.masterPUT.StatusTypeId : masterRecord.StatusTypeId;
                request.masterPUT.TenantId = (request.masterPUT.TenantId != 0) ? request.masterPUT.TenantId : masterRecord.TenantId;
                request.masterPUT.MenuModuleId = (request.masterPUT.MenuModuleId != 0) ? request.masterPUT.MenuModuleId : masterRecord.MenuModuleId;
            }

            if (isExists == false)
            {
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.Description = request.masterPUT.Description;
                masterRecord.PrinterId = request.masterPUT.PrinterId;
                masterRecord.StatusTypeId = request.masterPUT.StatusTypeId;
                masterRecord.TenantId = request.masterPUT.TenantId;
                masterRecord.MenuModuleId = request.masterPUT.MenuModuleId;

                await repository.Update(masterRecord);

                KitchenHistory history = new();
                history.KitchenId = request.masterPUT.Id;
                history.Name = request.masterPUT.Name;
                history.Description = request.masterPUT.Description;
                history.PrinterId = request.masterPUT.PrinterId;
                //history.TenantId = request.masterPUT.TenantId;
                //history.MenuModuleId = request.masterPUT.MenuModuleId;
                history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
                //history.Browser = request.masterPUT.Browser;
                //history.Location = request.masterPUT.Location;
                //history.DeviceIP = request.masterPUT.DeviceIP;
                //history.LocationURL = request.masterPUT.LocationURL;
                //history.DeviceName = request.masterPUT.DeviceName;
                //history.Latitude = request.masterPUT.Latitude;
                //history.Longitude = request.masterPUT.Longitude;
                //history.ActionBy = request.masterPUT.ActionBy;
                //history.ActionAt = DateTime.Now;

                await repository.Add(history);
                transaction.Commit();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.UpdateSuccess,
                    Data = request
                };
            }

            else
            {
                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = ResponseMessage.RecordExists
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
