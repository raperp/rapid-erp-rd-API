using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MainModuleFeatures.UpdateCommand;

public class UpdateMainModuleCommandHandler(IRepository repository)
{
    UpdateMainModuleCommandResponseModel _response;

    public async Task<UpdateMainModuleCommandResponseModel> Handle(UpdateMainModuleCommandRequestModel request)
    {
        try
        {
            MainModule masterData = new();
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<MainModule>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<MainModule>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;
                request.masterPUT.Prefix = (request.masterPUT.Prefix is not null) ? request.masterPUT.Prefix : masterRecord.Prefix;
                request.masterPUT.IconURL = (request.masterPUT.IconURL is not null) ? request.masterPUT.IconURL : masterRecord.IconURL;
                request.masterPUT.SetSerial = (request.masterPUT.SetSerial != 0) ? request.masterPUT.SetSerial : masterRecord.SetSerial;
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId is not null) ? request.masterPUT.LanguageId : masterRecord.LanguageId;
 
            }

            if (isExists == false)
            {
                //masterRecord.LanguageId = request.masterPUT.LanguageId;
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.Prefix = request.masterPUT.Prefix;
                masterRecord.IconURL = request.masterPUT.IconURL;
                masterRecord.SetSerial = request.masterPUT.SetSerial;

                await repository.Update(masterRecord);

                MainModuleHistory history = new();
                history.MainModuleId = masterData.Id;
                //history.LanguageId = request.masterPUT.LanguageId;
                history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
                history.Name = request.masterPUT.Name;
                history.Prefix = request.masterPUT.Prefix;
                history.IconURL = request.masterPUT.IconURL;
                history.SetSerial = request.masterPUT.SetSerial;
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
