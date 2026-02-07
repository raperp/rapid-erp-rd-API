using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryMasterCommands.CreateBulkCommand;

//public class CreateBulkCountryCommandHandler(IRepository repository)
public class CreateBulkCountryCommandHandler(ICountryBService service)
{
    public async Task<RequestResponse> Handle(CreateBulkCountryCommand command)
    {
        //RequestResponse requestResponse = new();

        //try
        //{
        //    foreach (var item in request.masterPOSTs)
        //    {
        //        using var transaction = repository.BeginTransaction();
        //        var isExists = await repository.IsExists<Country>(item.Name);

        //        if (isExists == false)
        //        {
        //            Country masterData = new();
        //            masterData.MenuModuleId = item.MenuModuleId;
        //            masterData.TenantId = item.TenantId;
        //            masterData.StatusTypeId = item.StatusTypeId;
        //            masterData.LanguageId = item.LanguageId;
        //            masterData.CurrencyId = item.CurrencyId;
        //            masterData.DialCode = item.DialCode;
        //            masterData.Name = item.Name;
        //            masterData.IsDefault = item.IsDefault;
        //            masterData.IsDraft = item.IsDraft;
        //            masterData.ISONumeric = item.ISONumeric;
        //            masterData.ISO2Code = item.ISO2Code;
        //            masterData.ISO3Code = item.ISO3Code;
        //            masterData.FlagURL = item.FlagURL;
        //            masterData.RegionId = item.RegionId;
        //            masterData.StateId = item.StateId;
        //            masterData.TimeZoneId = item.TimeZoneId;

        //            await repository.Add(masterData);

        //            CountryAudit history = new();
        //            history.CountryId = masterData.Id;
        //            history.CurrencyId = item.CurrencyId;
        //            history.TenantId = item.TenantId;
        //            history.MenuModuleId = item.MenuModuleId;
        //            history.ActionTypeId = item.ActionTypeId;
        //            history.LanguageId = item.LanguageId;
        //            history.ExportTypeId = item.ExportTypeId;
        //            history.ExportTo = item.ExportTo;
        //            history.SourceURL = item.SourceURL;
        //            history.DialCode = item.DialCode;
        //            history.Name = item.Name;
        //            history.IsDefault = item.IsDefault;
        //            history.IsDraft = item.IsDraft;
        //            history.ISONumeric = item.ISONumeric;
        //            history.ISO2Code = item.ISO2Code;
        //            history.ISO3Code = item.ISO3Code;
        //            history.FlagURL = item.FlagURL;
        //            history.RegionId = item.RegionId;
        //            history.StateId = item.StateId;
        //            history.TimeZoneId = item.TimeZoneId;
        //            history.Browser = item.Browser;
        //            history.Location = item.Location;
        //            history.DeviceIP = item.DeviceIP;
        //            history.LocationURL = item.LocationURL;
        //            history.DeviceName = item.DeviceName;
        //            history.Latitude = item.Latitude;
        //            history.Longitude = item.Longitude;
        //            history.ActionBy = item.ActionBy;
        //            history.ActionAt = DateTime.Now;

        //            await repository.Add(history);
        //            transaction.Commit();

        //            requestResponse = new()
        //            {
        //                StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
        //                IsSuccess = true,
        //                Message = ResponseMessage.CreateSuccess,
        //                Data = request
        //            };
        //        }

        //        else
        //        {
        //            requestResponse = new()
        //            {
        //                StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
        //                IsSuccess = false,
        //                Message = $"{ResponseMessage.RecordExists} {item.Name}"
        //            };
        //        }
        //    }

        //    return requestResponse;
        //}

        //catch
        //{
        //    requestResponse = new()
        //    {
        //        StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
        //        IsSuccess = false,
        //        Message = ResponseMessage.WrongDataInput
        //    };

        //    return requestResponse;
        //}

        var result = await service.CreateBulk(command.masterPOSTs);
        return result;
    }
}
