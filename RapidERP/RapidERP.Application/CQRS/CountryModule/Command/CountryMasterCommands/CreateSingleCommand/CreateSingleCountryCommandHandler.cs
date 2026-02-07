using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Application.Repository;
using RapidERP.Domain.Utilities;
using RapidERP.Application.Interfaces;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryMasterCommands.CreateSingleCommand;

//public class CreateSingleCountryCommandHandler(IRepository repository)
public class CreateSingleCountryCommandHandler(ICountryBService service)
{
    public async Task<RequestResponse> Handle(CreateSingleCountryCommand command)
    {
        //RequestResponse requestResponse;

        //try
        //{
        //    using var transaction = repository.BeginTransaction();
        //    var isExists = await repository.IsExists<Country>(request.masterPOST.Name);


        //    if (isExists == false)
        //    {
        //        Country masterData = new();
        //        masterData.MenuModuleId = request.masterPOST.MenuModuleId;
        //        masterData.TenantId = request.masterPOST.TenantId;
        //        masterData.StatusTypeId = request.masterPOST.StatusTypeId;
        //        masterData.LanguageId = request.masterPOST.LanguageId;
        //        masterData.CurrencyId = request.masterPOST.CurrencyId;
        //        masterData.DialCode = request.masterPOST.DialCode;
        //        masterData.Name = request.masterPOST.Name;
        //        masterData.IsDefault = request.masterPOST.IsDefault;
        //        masterData.IsDraft = request.masterPOST.IsDraft;
        //        masterData.ISONumeric = request.masterPOST.ISONumeric;
        //        masterData.ISO2Code = request.masterPOST.ISO2Code;
        //        masterData.ISO3Code = request.masterPOST.ISO3Code;
        //        masterData.FlagURL = request.masterPOST.FlagURL;
        //        masterData.RegionId = request.masterPOST.RegionId;
        //        masterData.StateId = request.masterPOST.StateId;
        //        masterData.TimeZoneId = request.masterPOST.TimeZoneId;

        //        await repository.Add(masterData);

        //        CountryAudit history = new();
        //        history.CountryId = masterData.Id;
        //        history.CurrencyId = request.masterPOST.CurrencyId;
        //        history.TenantId = request.masterPOST.TenantId;
        //        history.MenuModuleId = request.masterPOST.MenuModuleId;
        //        history.ActionTypeId = request.masterPOST.ActionTypeId;
        //        history.LanguageId = request.masterPOST.LanguageId;
        //        history.ExportTypeId = request.masterPOST.ExportTypeId;
        //        history.ExportTo = request.masterPOST.ExportTo;
        //        history.SourceURL = request.masterPOST.SourceURL;
        //        history.DialCode = request.masterPOST.DialCode;
        //        history.Name = request.masterPOST.Name;
        //        history.IsDefault = request.masterPOST.IsDefault;
        //        history.IsDraft = request.masterPOST.IsDraft;
        //        history.ISONumeric = request.masterPOST.ISONumeric;
        //        history.ISO2Code = request.masterPOST.ISO2Code;
        //        history.ISO3Code = request.masterPOST.ISO3Code;
        //        history.FlagURL = request.masterPOST.FlagURL;
        //        history.RegionId = request.masterPOST.RegionId;
        //        history.StateId = request.masterPOST.StateId;
        //        history.TimeZoneId = request.masterPOST.TimeZoneId;
        //        history.Browser = request.masterPOST.Browser;
        //        history.Location = request.masterPOST.Location;
        //        history.DeviceIP = request.masterPOST.DeviceIP;
        //        history.LocationURL = request.masterPOST.LocationURL;
        //        history.DeviceName = request.masterPOST.DeviceName;
        //        history.Latitude = request.masterPOST.Latitude;
        //        history.Longitude = request.masterPOST.Longitude;
        //        history.ActionBy = request.masterPOST.ActionBy;
        //        history.ActionAt = DateTime.Now;

        //        await repository.Add(history);
        //        transaction.Commit();

        //        requestResponse = new()
        //        {
        //            StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
        //            IsSuccess = true,
        //            Message = ResponseMessage.CreateSuccess,
        //            Data = request
        //        };
        //    }

        //    else
        //    {
        //        requestResponse = new()
        //        {
        //            StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
        //            IsSuccess = false,
        //            Message = $"{ResponseMessage.RecordExists} {request.masterPOST.Name}"
        //        };
        //    }

        //    return requestResponse;
        //}

        //catch
        //{
        //    requestResponse = new()
        //    {
        //        StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
        //        IsSuccess = false,
        //        Message = ResponseMessage.WrongDataInput
        //    };

        //    return requestResponse;
        //}

        var result = await service.CreateSingle(command.masterPOST);
        return result;
    }
}
