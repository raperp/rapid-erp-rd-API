using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TextModuleFeatures.UpdateCommand;

public class UpdateTextModuleCommandHandler(IRepository repository)
{
    UpdateTextModuleCommandResponseModel _response;

    public async Task<UpdateTextModuleCommandResponseModel> Handle(UpdateTextModuleCommandRequestModel request)
    {
        try
        { 
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<TextModule>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<TextModule>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;                 
                //request.masterPUT.MenuModuleId = (request.masterPUT.MenuModuleId != 0) ? request.masterPUT.MenuModuleId : masterRecord.MenuModuleId;
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId != 0) ? request.masterPUT.LanguageId : masterRecord.LanguageId;                
            }
            
            if (isExists == false)
            {
                //masterRecord.MenuModuleId = request.masterPUT.MenuModuleId;
                //masterRecord.LanguageId = request.masterPUT.LanguageId;
                masterRecord.Name = request.masterPUT.Name;

                await repository.Update(masterRecord);

                TextModuleHistory history = new();
                history.TextModuleId = request.masterPUT.Id;
                //history.MenuModuleId = request.masterPUT.MenuModuleId;
                //history.LanguageId = request.masterPUT.LanguageId;
                history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
                history.Name = request.masterPUT.Name;
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
