using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.UpdateCommand;

public class UpdateCountryCommandHandler(IRepository repository)
{
    public async Task<UpdateCountryCommandResponseModel> Handle(UpdateCountryCommandRequestModel request)
    {
        try
        {
            Country masterData = new();
            CountryHistory history = new();
            UpdateCountryCommandResponseModel response = new();
            //await using var transaction = await context.Database.BeginTransactionAsync();
            await using var transaction = await repository.BeginTransactionAsync();
            //var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);
            var masterRecord = await repository.FindById(masterData);

            //Loading current data to parameter
            request.ISONumeric = (request.ISONumeric is not null) ? request.ISONumeric : masterRecord.ISONumeric;
            request.Name = (request.Name is not null) ? request.Name : masterRecord.Name;
            request.ISO2Code = (request.ISO2Code is not null) ? request.ISO2Code : masterRecord.ISO2Code;
            request.ISO3Code = (request.ISO3Code is not null) ? request.ISO3Code : masterRecord.ISO3Code;
            request.MenuModuleId = (request.MenuModuleId is not null) ? request.MenuModuleId : masterRecord.MenuModuleId;
            request.TenantId = (request.TenantId is not null) ? request.TenantId : masterRecord.TenantId;
            request.StatusTypeId = (request.StatusTypeId != 0) ? request.StatusTypeId : masterRecord.StatusTypeId;
            request.LanguageId = (request.LanguageId is not null) ? request.LanguageId : masterRecord.LanguageId;
            request.CurrencyId = (request.CurrencyId != 0) ? request.CurrencyId : masterRecord.CurrencyId;
            request.DialCode = (request.DialCode is not null) ? request.DialCode : masterRecord.DialCode;
            request.FlagURL = (request.FlagURL is not null) ? request.FlagURL : masterRecord.FlagURL;



            if (masterRecord is null)
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


                masterData.MenuModuleId = request.MenuModuleId;
                masterData.TenantId = request.TenantId;
                masterData.StatusTypeId = request.StatusTypeId;
                masterData.LanguageId = request.LanguageId;
                masterData.CurrencyId = request.CurrencyId;
                masterData.DialCode = request.DialCode;
                masterData.Name = request.Name;
                masterData.IsDefault = request.IsDefault;
                masterData.IsDraft = request.IsDraft;
                masterData.ISONumeric = request.ISONumeric;
                masterData.ISO2Code = request.ISO2Code;
                masterData.ISO3Code = request.ISO3Code;
                masterData.FlagURL = request.FlagURL;

                await repository.Update(masterData);

                history.CountryId = request.Id;
                history.TenantId = request.TenantId;
                history.MenuModuleId = request.MenuModuleId;
                history.ActionTypeId = request.ActionTypeId;
                history.LanguageId = request.LanguageId;
                history.CurrencyId = request.CurrencyId;
                history.ExportTypeId = request.ExportTypeId;
                history.ExportTo = request.ExportTo;
                history.SourceURL = request.SourceURL;
                history.DialCode = request.DialCode;
                history.Name = request.Name;
                history.IsDefault = request.IsDefault;
                history.IsDraft = request.IsDraft;
                history.ISONumeric = request.ISONumeric;
                history.ISO2Code = request.ISO2Code;
                history.ISO3Code = request.ISO3Code;
                history.FlagURL = request.FlagURL;
                history.Browser = request.Browser;
                history.Location = request.Location;
                history.DeviceIP = request.DeviceIP;
                history.LocationURL = request.LocationURL;
                history.DeviceName = request.DeviceName;
                history.Latitude = request.Latitude;
                history.Longitude = request.Longitude;
                history.ActionBy = request.ActionBy;
                history.ActionAt = DateTime.Now;

                await repository.Add(history);
                await repository.CommitChanges();
                await transaction.CommitAsync();


                response.Id = request.Id;
                response.CurrencyId = request.CurrencyId;
                response.DialCode = request.DialCode;
                response.ISONumeric = request.ISONumeric;
                response.ISO2Code = request.ISO2Code;
                response.ISO3Code = request.ISO3Code;
                response.FlagURL = request.FlagURL;
                response.Name = request.Name;
                response.MenuModuleId = request.MenuModuleId;
                response.TenantId = request.TenantId;
                response.StatusTypeId = request.StatusTypeId;
                response.LanguageId = request.LanguageId;
                response.IsDefault = request.IsDefault;
                response.IsDraft = request.IsDraft;
                response.ActionTypeId = request.ActionTypeId;
                response.ExportTypeId = request.ExportTypeId;
                response.ExportTo = request.ExportTo;
                response.SourceURL = request.SourceURL;
                response.Browser = request.Browser;
                response.Location = request.Location;
                response.DeviceIP = request.DeviceIP;
                response.LocationURL = request.LocationURL;
                response.DeviceName = request.DeviceName;
                response.Latitude = request.Latitude;
                response.Longitude = request.Longitude;
                response.ActionBy = request.ActionBy;


                //_requestResponse = new()
                //{
                //    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                //    IsSuccess = true,
                //    Message = ResponseMessage.UpdateSuccess,
                //    Data = request
                //};
            }

            else
            {
                //_requestResponse = new()
                //{
                //    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                //    IsSuccess = false,
                //    Message = ResponseMessage.RecordExists
                //};
            }

            return response;
        }

        catch(Exception ex)
        {
            //_requestResponse = new()
            //{
            //    StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
            //    IsSuccess = false,
            //    Message = ResponseMessage.WrongDataInput
            //};

            //return _requestResponse;
            throw new ApplicationException(ex.Message);
        }
    }
}
