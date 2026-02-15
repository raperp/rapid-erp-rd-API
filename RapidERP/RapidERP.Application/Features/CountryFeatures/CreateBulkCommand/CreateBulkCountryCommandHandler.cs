  using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;
using System.Xml.Linq;

namespace RapidERP.Application.Features.CountryFeatures.CreateBulkCommand;

public class CreateBulkCountryCommandHandler(IRepository repository)
{
    public async Task<CreateBulkCountryCommandResponseModel> Handle(CreateBulkCountryCommandRequestModel request)
    {
        CreateBulkCountryCommandResponseModel _response = new();
        string name = string.Empty;

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<Country>(item.masterPOST.Name);

                if (isExists == false)
                {
                    Country masterData = new();
                    //masterData.MenuModuleId = item.masterPOST.MenuModuleId;
                    masterData.TenantId = item.masterPOST.TenantId;
                    //masterData.StatusTypeId = item.masterPOST.StatusTypeId;
                    //masterData.LanguageId = item.masterPOST.LanguageId;
                    //masterData.CurrencyId = item.masterPOST.CurrencyId;
                    //masterData.DialingCode = item.masterPOST.DialCode;
                    masterData.Name = item.masterPOST.Name;
                    masterData.IsDefault = item.masterPOST.IsDefault;
                    masterData.IsDraft = item.masterPOST.IsDraft;
                    masterData.ISONumeric = item.masterPOST.ISONumeric;
                    masterData.ISO2Code = item.masterPOST.ISO2Code;
                    masterData.ISO3Code = item.masterPOST.ISO3Code;
                    masterData.FlagURL = item.masterPOST.FlagURL;
                    name = item.masterPOST.Name;

                    await repository.Add(masterData);

                    CountryAudit history = new();
                    history.CountryId = masterData.Id;
                    //history.CurrencyId = item.masterPOST.CurrencyId;
                    //history.TenantId = item.masterPOST.TenantId;
                    //history.MenuModuleId = item.masterPOST.MenuModuleId;
                    //history.ActionTypeId = item.masterPOST.ActionTypeId;
                    //history.LanguageId = item.masterPOST.LanguageId;
                    //history.ExportTypeId = item.masterPOST.ExportTypeId;
                    //history.ExportTo = item.masterPOST.ExportTo;
                    //history.SourceURL = item.masterPOST.SourceURL;
                    //history.DialingCode = item.masterPOST.DialCode;
                    history.Name = item.masterPOST.Name;
                    history.IsDefault = item.masterPOST.IsDefault;
                    //history.IsDraft = item.masterPOST.IsDraft;
                    history.ISONumeric = item.masterPOST.ISONumeric;
                    history.ISO2Code = item.masterPOST.ISO2Code;
                    history.ISO3Code = item.masterPOST.ISO3Code;
                    history.FlagURL = item.masterPOST.FlagURL;
                    //history.Browser = item.masterPOST.Browser;
                    //history.Location = item.masterPOST.Location;
                    //history.DeviceIP = item.masterPOST.DeviceIP;
                    //history.LocationURL = item.masterPOST.LocationURL;
                    //history.DeviceName = item.masterPOST.DeviceName;
                    //history.Latitude = item.masterPOST.Latitude;
                    //history.Longitude = item.masterPOST.Longitude;
                    //history.ActionBy = item.masterPOST.ActionBy;
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
