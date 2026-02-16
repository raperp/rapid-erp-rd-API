using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.CreateSingleCommand;

public class CreateSingleCountryCommandHandler(IRepository repository)
{
    public async Task<CreateSingleCountryCommandResponseModel> Handle(CreateSingleCountryCommandRequestModel request)
    {
        CreateSingleCountryCommandResponseModel _response;
        string name = string.Empty;

        try
        {
            using var transaction = repository.BeginTransaction(); 
            var isExists = await repository.IsExists<Country>(request.masterPOST.Name);
           
            if (isExists == false)
            {
                Country masterData = new();
                //masterData.MenuModuleId = request.masterPOST.MenuModuleId;
                masterData.TenantId = request.masterPOST.TenantId;
                //masterData.StatusTypeId = request.masterPOST.StatusTypeId;
                //masterData.LanguageId = request.masterPOST.LanguageId;
                //masterData.CurrencyId = request.masterPOST.CurrencyId;
                //masterData.DialingCode = request.masterPOST.DialCode;
                masterData.Name = request.masterPOST.Name;
                masterData.IsDefault = request.masterPOST.IsDefault;
                //masterData.IsDraft = request.masterPOST.IsDraft;
                masterData.ISONumeric = request.masterPOST.ISONumeric;
                masterData.ISO2Code = request.masterPOST.ISO2Code;
                masterData.ISO3Code = request.masterPOST.ISO3Code;
                masterData.FlagURL = request.masterPOST.FlagURL;
                name = request.masterPOST.Name;

                await repository.Add(masterData); 

                CountryAudit history = new();
                history.CountryId = masterData.Id;
                //history.CurrencyId = request.masterPOST.CurrencyId;
                //history.TenantId = request.masterPOST.TenantId;
                //history.MenuModuleId = request.masterPOST.MenuModuleId;
                //history.ActionTypeId = request.masterPOST.ActionTypeId;
                //history.LanguageId = request.masterPOST.LanguageId;
                //history.ExportTypeId = request.masterPOST.ExportTypeId;
                //history.ExportTo = request.masterPOST.ExportTo;
                //history.SourceURL = request.masterPOST.SourceURL;
                //history.DialingCode = request.masterPOST.DialCode;
                history.Name = request.masterPOST.Name;
                history.IsDefault = request.masterPOST.IsDefault;
                //history.IsDraft = request.masterPOST.IsDraft;
                history.ISONumeric = request.masterPOST.ISONumeric;
                history.ISO2Code = request.masterPOST.ISO2Code;
                history.ISO3Code = request.masterPOST.ISO3Code;
                history.FlagURL = request.masterPOST.FlagURL;
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
                    Message = $"{ResponseMessage.RecordExists} {name}"
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
