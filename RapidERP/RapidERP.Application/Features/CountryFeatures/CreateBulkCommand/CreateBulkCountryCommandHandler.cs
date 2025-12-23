using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Application.Features.CountryFeatures.CreateBulkCommand;

public class CreateBulkCountryCommandHandler(IRepository repository)
{
    public async Task<CreateBulkCountryCommandResponseModel> Handle(CreateBulkCountryCommandRequestModel request)
    {
        try
        {
            CreateBulkCountryCommandResponseModel responseModel = new();
            foreach (var masterPOST in request.masterPOSTs)
            {
                Country masterData = new();
                //await using var transaction = await context.Database.BeginTransactionAsync();
                await using var transaction = await repository.BeginTransactionAsync();
                //var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);
                var masterRecord = await repository.FindById(masterData);

                if (masterRecord is null)
                {

                    masterData.MenuModuleId = masterPOST.MenuModuleId;
                    masterData.TenantId = masterPOST.TenantId;
                    masterData.StatusTypeId = masterPOST.StatusTypeId;
                    masterData.LanguageId = masterPOST.LanguageId;
                    masterData.CurrencyId = masterPOST.CurrencyId;
                    masterData.DialCode = masterPOST.DialCode;
                    masterData.Name = masterPOST.Name;
                    masterData.IsDefault = masterPOST.IsDefault;
                    masterData.IsDraft = masterPOST.IsDraft;
                    masterData.ISONumeric = masterPOST.ISONumeric;
                    masterData.ISO2Code = masterPOST.ISO2Code;
                    masterData.ISO3Code = masterPOST.ISO3Code;
                    masterData.FlagURL = masterPOST.FlagURL;

                    await repository.Add(masterData);

                    CountryHistory history = new();
                    history.CountryId = masterData.Id;
                    history.CurrencyId = masterPOST.CurrencyId;
                    history.TenantId = masterPOST.TenantId;
                    history.MenuModuleId = masterPOST.MenuModuleId;
                    history.ActionTypeId = masterPOST.ActionTypeId;
                    history.LanguageId = masterPOST.LanguageId;
                    history.ExportTypeId = masterPOST.ExportTypeId;
                    history.ExportTo = masterPOST.ExportTo;
                    history.SourceURL = masterPOST.SourceURL;
                    history.DialCode = masterPOST.DialCode;
                    history.Name = masterPOST.Name;
                    history.IsDefault = masterPOST.IsDefault;
                    history.IsDraft = masterPOST.IsDraft;
                    history.ISONumeric = masterPOST.ISONumeric;
                    history.ISO2Code = masterPOST.ISO2Code;
                    history.ISO3Code = masterPOST.ISO3Code;
                    history.FlagURL = masterPOST.FlagURL;
                    history.Browser = masterPOST.Browser;
                    history.Location = masterPOST.Location;
                    history.DeviceIP = masterPOST.DeviceIP;
                    history.LocationURL = masterPOST.LocationURL;
                    history.DeviceName = masterPOST.DeviceName;
                    history.Latitude = masterPOST.Latitude;
                    history.Longitude = masterPOST.Longitude;
                    history.ActionBy = masterPOST.ActionBy;
                    history.ActionAt = DateTime.Now;

                    await repository.Add(history);
                    await repository.CommitChanges();
                    await transaction.CommitAsync();
                }

                responseModel = new()  
                {
                    MenuModuleId = masterPOST.MenuModuleId,
                    TenantId = masterPOST.TenantId,
                    StatusTypeId = masterPOST.StatusTypeId,
                    LanguageId = masterPOST.LanguageId,
                    CurrencyId = masterPOST.CurrencyId,
                    DialCode = masterPOST.DialCode,
                    Name = masterPOST.Name,
                    IsDefault = masterPOST.IsDefault,
                    IsDraft = masterPOST.IsDraft,
                    ISONumeric = masterPOST.ISONumeric,
                    ISO2Code = masterPOST.ISO2Code,
                    ISO3Code = masterPOST.ISO3Code,
                    FlagURL = masterPOST.FlagURL,
                };
                
            }
            return responseModel;
        }
        catch
        {
            //_requestResponse = new()
            //{
            //    StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
            //    IsSuccess = false,
            //    Message = ResponseMessage.WrongDataInput
            //};

            //return _requestResponse;
            throw new ApplicationException();
        }
    }
}
