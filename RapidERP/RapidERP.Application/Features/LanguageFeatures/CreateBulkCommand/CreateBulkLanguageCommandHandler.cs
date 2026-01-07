using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.LanguageFeatures.CreateBulkCommand;

public class CreateBulkLanguageCommandHandler(IRepository repository)
{
    public async Task<CreateBulkLanguageCommandResponseModel> Handle(CreateBulkLanguageCommandRequestModel request)
    {
        CreateBulkLanguageCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<Language>(item.Name);

                if (isExists == false)
                {
                    Language masterData = new();
                    masterData.ISONumeric = item.ISONumeric;
                    masterData.Name = item.Name;
                    masterData.ISO2Code = item.ISO2Code;
                    masterData.ISO3Code = item.ISO3Code;
                    masterData.IconURL = item.IconURL;

                    await repository.Add(masterData);

                    LanguageHistory history = new();
                    history.LanguageId = masterData.Id;
                    history.ISONumeric = item.ISONumeric;
                    history.Name = item.Name;
                    history.ISO2Code = item.ISO2Code;
                    history.ISO3Code = item.ISO3Code;
                    history.IconURL = item.IconURL;
                    history.Browser = item.Browser;
                    history.Location = item.Location;
                    history.DeviceIP = item.DeviceIP;
                    history.LocationURL = item.LocationURL;
                    history.DeviceName = item.DeviceName;
                    history.Latitude = item.Latitude;
                    history.Longitude = item.Longitude;
                    history.ActionBy = item.ActionBy;
                    history.ActionAt = DateTime.UtcNow;

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
