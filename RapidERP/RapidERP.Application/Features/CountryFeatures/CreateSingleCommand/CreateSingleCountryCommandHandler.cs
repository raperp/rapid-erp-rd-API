using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.CreateSingleCommand;

public class CreateSingleCountryCommandHandler(IRepository repository)
{
    public async Task<CreateSingleCountryCommandResponseModel> Handle(CreateSingleCountryCommandRequestModel request)
    {
        CreateSingleCountryCommandResponseModel _response;

        try
        {
            Country masterData = new();
            //await using var transaction = await context.Database.BeginTransactionAsync();
            await using var transaction = await repository.BeginTransactionAsync();
            //var isExists = await context.Countries.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);
            var masterRecord = await repository.FindById(masterData);

            if (masterRecord is null)
            {
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

                await repository.Add(masterData);

                CountryHistory history = new();
                history.CountryId = masterData.Id;
                history.CurrencyId = request.CurrencyId;
                history.TenantId = request.TenantId;
                history.MenuModuleId = request.MenuModuleId;
                history.ActionTypeId = request.ActionTypeId;
                history.LanguageId = request.LanguageId;
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
                await transaction.CommitAsync(); /////commit transaction not accessable from repository

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
                    Message = $"{ResponseMessage.RecordExists} {request.Name}"
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
