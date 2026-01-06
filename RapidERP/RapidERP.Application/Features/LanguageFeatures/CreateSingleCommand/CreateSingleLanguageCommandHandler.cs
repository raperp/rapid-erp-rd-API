using RapidERP.Application.Features.CountryFeatures.CreateSingleCommand;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.LanguageFeatures.CreateSingleCommand;

public class CreateSingleLanguageCommandHandler(IRepository repository)
{
    public async Task<CreateSingleLanguageCommandResponseModel> Handle(CreateSingleCountryCommandRequestModel request)
    {
        CreateSingleLanguageCommandResponseModel _response;
        string name = string.Empty;

        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Languages.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name || x.ISONumeric == masterPOST.ISONumeric || x.ISO2Code == masterPOST.ISO2Code || x.ISO3Code == masterPOST.ISO3Code || x.IconURL == masterPOST.IconURL);

            if (isExists == false)
            {
                Language masterData = new();
                masterData.ISONumeric = masterPOST.ISONumeric;
                masterData.Name = masterPOST.Name;
                masterData.ISO2Code = masterPOST.ISO2Code;
                masterData.ISO3Code = masterPOST.ISO3Code;
                masterData.IconURL = masterPOST.IconURL;

                await context.Languages.AddAsync(masterData);
                await context.SaveChangesAsync();

                LanguageHistory history = new();
                history.LanguageId = masterData.Id;
                history.ISONumeric = masterPOST.ISONumeric;
                history.Name = masterPOST.Name;
                history.ISO2Code = masterPOST.ISO2Code;
                history.ISO3Code = masterPOST.ISO3Code;
                history.IconURL = masterPOST.IconURL;
                history.Browser = masterPOST.Browser;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                history.LocationURL = masterPOST.LocationURL;
                history.DeviceName = masterPOST.DeviceName;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                history.ActionBy = masterPOST.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.LanguageHistory.AddAsync(history);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = masterPOST
                };
            }

            else
            {
                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = $"{ResponseMessage.RecordExists} {masterPOST.Name}"
                };
            }

            return _response;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }
}
