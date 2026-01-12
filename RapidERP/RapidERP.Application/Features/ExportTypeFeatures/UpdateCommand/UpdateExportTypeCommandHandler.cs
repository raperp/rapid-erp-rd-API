using RapidERP.Application.Features.ExportTypeFeatures.UpdateCommand;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ExportTypeFeatures.UpdateCommand;

public class UpdateExportTypeCommandHandler(IRepository repository)
{
    UpdateExportTypeCommandResponseModel _response;

    public async Task<UpdateExportTypeCommandResponseModel> Handle(UpdateExportTypeCommandRequestModel request)
    {
        try
        {
            //ExportType masterData = new();
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<ExportType>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<ExportType>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;
                request.masterPUT.Description = (request.masterPUT.Description is not null) ? request.masterPUT.Description : masterRecord.Description;
                request.masterPUT.LanguageId = (request.masterPUT.LanguageId != 0) ? request.masterPUT.LanguageId : masterRecord.LanguageId;
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

                masterRecord.Name = request.masterPUT.Name;
                masterRecord.Description = request.masterPUT.Description;
                masterRecord.LanguageId = request.masterPUT.LanguageId;
                 
                await repository.Update(masterRecord);

                ExportTypeHistory history = new();
                history.ExportTypeId = request.masterPUT.Id;
                history.LanguageId = request.masterPUT.LanguageId;
                history.Name = request.masterPUT.Name;
                history.Description = request.masterPUT.Description;
                history.Browser = request.masterPUT.Browser;
                history.Location = request.masterPUT.Location;
                history.DeviceIP = request.masterPUT.DeviceIP;
                history.LocationURL = request.masterPUT.LocationURL;
                history.DeviceName = request.masterPUT.DeviceName;
                history.Latitude = request.masterPUT.Latitude;
                history.Longitude = request.masterPUT.Longitude;
                history.ActionBy = request.masterPUT.ActionBy;
                history.ActionAt = DateTime.Now;

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
