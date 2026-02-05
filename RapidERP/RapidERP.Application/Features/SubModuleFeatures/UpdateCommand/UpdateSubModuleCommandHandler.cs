using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SubModuleFeatures.UpdateCommand;

public record UpdateSubModuleCommandHandler(IRepository repository)
{
    UpdateSubModuleCommandResponseModel _response;

    public async Task<UpdateSubModuleCommandResponseModel> Handle(UpdateSubModuleCommandRequestModel request)
    {
        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<Submodule>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<Submodule>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;               
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId != 0) ? request.masterPUT.LanguageId : masterRecord.LanguageId;
                request.masterPUT.MainModuleId = (request.masterPUT.MainModuleId != 0) ? request.masterPUT.MainModuleId : masterRecord.MainModuleId;
                request.masterPUT.IconURL = (request.masterPUT.IconURL is not null) ? request.masterPUT.IconURL : masterRecord.IconURL;
                request.masterPUT.SetSerial = (request.masterPUT.SetSerial != 0) ? request.masterPUT.SetSerial : masterRecord.SetSerial;
            }

            if (isExists == false)
            {
                masterRecord.Name = request.masterPUT.Name;
                //masterRecord.LanguageId = request.masterPUT.LanguageId;
                masterRecord.MainModuleId = request.masterPUT.MainModuleId;
                masterRecord.SetSerial = request.masterPUT.SetSerial;
                masterRecord.IconURL = request.masterPUT.IconURL;
                
                await repository.Update(masterRecord);

                SubmoduleHistory history = new();
                history.SubmoduleId = request.masterPUT.Id;
                history.MainModuleId = request.masterPUT.MainModuleId;
                //history.LanguageId = request.masterPUT.LanguageId;
                history.ActionTypeId = request.masterPUT.ActionTypeId;
                history.ExportTypeId = request.masterPUT.ExportTypeId;
                history.ExportTo = request.masterPUT.ExportTo;
                history.SourceURL = request.masterPUT.SourceURL;
                history.Name = request.masterPUT.Name;
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
