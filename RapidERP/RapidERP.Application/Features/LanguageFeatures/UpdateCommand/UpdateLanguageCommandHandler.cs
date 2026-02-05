using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.LanguageFeatures.UpdateCommand;
  
public class UpdateLanguageCommandHandler(IRepository repository)
{
    UpdateLanguageCommandResponseModel _response;

    public async Task<UpdateLanguageCommandResponseModel> Handle(UpdateLanguageCommandRequestModel request)
    {
        try
        {
            //Language masterData = new();
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<Language>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<Language>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.ISONumeric = (request.masterPUT.ISONumeric is not null) ? request.masterPUT.ISONumeric : masterRecord.ISONumeric;
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;
                request.masterPUT.ISO2Code = (request.masterPUT.ISO2Code is not null) ? request.masterPUT.ISO2Code : masterRecord.ISO2Code;
                request.masterPUT.ISO3Code = (request.masterPUT.ISO3Code is not null) ? request.masterPUT.ISO3Code : masterRecord.ISO3Code;
                request.masterPUT.IconURL = (request.masterPUT.IconURL is not null) ? request.masterPUT.IconURL : masterRecord.IconURL;               
            }

            if (isExists == false)
            {  
                masterRecord.ISONumeric = request.masterPUT.ISONumeric;
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.ISO2Code = request.masterPUT.ISO2Code;
                masterRecord.ISO3Code = request.masterPUT.ISO3Code;
                masterRecord.IconURL = request.masterPUT.IconURL;

                await repository.Update(masterRecord);

                LanguageHistory history = new();
                history.LanguageId = request.masterPUT.Id;
                history.ISONumeric = request.masterPUT.ISONumeric;  
                history.Name = request.masterPUT.Name;
                history.ISO2Code = request.masterPUT.ISO2Code;
                history.ISO3Code = request.masterPUT.ISO3Code;
                history.IconURL = request.masterPUT.IconURL;
                //history.Browser = request.masterPUT.Browser;
                //history.Location = request.masterPUT.Location;
                //history.DeviceIP = request.masterPUT.DeviceIP;
                //history.LocationURL = request.masterPUT.LocationURL;
                //history.DeviceName = request.masterPUT.DeviceName;
                //history.Latitude = request.masterPUT.Latitude;
                //history.Longitude = request.masterPUT.Longitude;
                //history.ActionBy = request.masterPUT.ActionBy;
                //history.ActionAt = DateTime.UtcNow;

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
