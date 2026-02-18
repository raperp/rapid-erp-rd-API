using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.UpdateCommand;

public class UpdateCountryCommandHandler(IRepository repository)
{
    UpdateCountryCommandResponseModel _response;

    public async Task<UpdateCountryCommandResponseModel> Handle(UpdateCountryCommandRequestModel request)
    {
        try
        {
            //Country masterData = new();
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByIdName<Country>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<Country>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.ISONumeric = (request.masterPUT.ISONumeric is not null) ? request.masterPUT.ISONumeric : masterRecord.ISONumeric;
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;
                request.masterPUT.ISO2Code = (request.masterPUT.ISO2Code is not null) ? request.masterPUT.ISO2Code : masterRecord.ISO2Code;
                request.masterPUT.ISO3Code = (request.masterPUT.ISO3Code is not null) ? request.masterPUT.ISO3Code : masterRecord.ISO3Code;
                //request.masterPUT.MenuModuleId = (request.masterPUT.MenuModuleId is not null) ? request.masterPUT.MenuModuleId : masterRecord.MenuModuleId;
                request.masterPUT.TenantId = (request.masterPUT.TenantId is not null) ? request.masterPUT.TenantId : masterRecord.TenantId;
                //request.masterPUT.StatusTypeId = (request.masterPUT.StatusTypeId is not null) ? request.masterPUT.StatusTypeId : masterRecord.StatusTypeId;
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId is not null) ? request.masterPUT.LanguageId : masterRecord.LanguageId;
                //request.masterPUT.CurrencyId = (request.masterPUT.CurrencyId is not null) ? request.masterPUT.CurrencyId : masterRecord.CurrencyId;
                //request.masterPUT.DialCode = (request.masterPUT.DialCode is not null) ? request.masterPUT.DialCode : masterRecord.DialingCode;
                request.masterPUT.FlagURL = (request.masterPUT.FlagURL is not null) ? request.masterPUT.FlagURL : masterRecord.FlagURL;
            }

            if (isExists == false)
            {
                //await context.Countries.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                //.SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                //.SetProperty(x => x.TenantId, masterPUT.TenantId)
                //.SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                //.SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                //.SetProperty(x => x.CurrencyId, masterPUT.CurrencyId)
                //.SetProperty(x => x.DialCode, masterPUT.DialCode)
                //.SetProperty(x => x.Name, masterPUT.Name)
                //.SetProperty(x => x.IsDefault, masterPUT.IsDefault)
                //.SetProperty(x => x.IsDraft, masterPUT.IsDraft)
                //.SetProperty(x => x.ISONumeric, masterPUT.ISONumeric)
                //.SetProperty(x => x.ISO2Code, masterPUT.ISO2Code)
                //.SetProperty(x => x.ISO3Code, masterPUT.ISO3Code)
                //.SetProperty(x => x.FlagURL, masterPUT.FlagURL));

                //masterRecord.MenuModuleId = request.masterPUT.MenuModuleId;
                masterRecord.TenantId = request.masterPUT.TenantId;
                //masterRecord.StatusTypeId = request.masterPUT.StatusTypeId;
                //masterRecord.LanguageId = request.masterPUT.LanguageId;
                //masterRecord.CurrencyId = request.masterPUT.CurrencyId;
                //masterRecord.DialingCode = request.masterPUT.DialCode;
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.IsDefault = request.masterPUT.IsDefault;
                //masterRecord.IsDraft = request.masterPUT.IsDraft;
                masterRecord.ISONumeric = request.masterPUT.ISONumeric;
                masterRecord.ISO2Code = request.masterPUT.ISO2Code;
                masterRecord.ISO3Code = request.masterPUT.ISO3Code;
                masterRecord.FlagURL = request.masterPUT.FlagURL;

                await repository.Update(masterRecord);

                CountryAudit history = new();
                history.CountryId = request.masterPUT.Id;
                //history.CurrencyId = request.masterPUT.CurrencyId;
                //history.TenantId = request.masterPUT.TenantId;
                //history.MenuModuleId = request.masterPUT.MenuModuleId;
                //history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.LanguageId = request.masterPUT.LanguageId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
                //history.DialingCode = request.masterPUT.DialCode;
                history.Name = request.masterPUT.Name;
                //history.IsDefault = request.masterPUT.IsDefault;
                //history.IsDraft = request.masterPUT.IsDraft;
                history.ISONumeric = request.masterPUT.ISONumeric;
                history.ISO2Code = request.masterPUT.ISO2Code;
                history.ISO3Code = request.masterPUT.ISO3Code;
                history.FlagURL = request.masterPUT.FlagURL;
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
