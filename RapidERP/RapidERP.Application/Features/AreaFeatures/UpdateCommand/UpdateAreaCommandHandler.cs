using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.AreaFeatures.UpdateCommand;

public class UpdateAreaCommandHandler(IRepository repository)
{
    UpdateAreaCommandResponseModel _response;

    public async Task<UpdateAreaCommandResponseModel> Handle(UpdateAreaCommandRequestModel request)
    {
        try
        { 
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByIdName<Area>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<Area>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;
                request.masterPUT.Code = (request.masterPUT.Code is not null) ? request.masterPUT.Code : masterRecord.Code;
                //request.masterPUT.MenuModuleId = (request.masterPUT.MenuModuleId is not null) ? request.masterPUT.MenuModuleId : masterRecord.MenuModuleId;
                request.masterPUT.TenantId = (request.masterPUT.TenantId is not null) ? request.masterPUT.TenantId : masterRecord.TenantId;
                //request.masterPUT.StatusTypeId = (request.masterPUT.StatusTypeId is not null) ? request.masterPUT.StatusTypeId : masterRecord.StatusTypeId;
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId is not null) ? request.masterPUT.LanguageId : masterRecord.LanguageId;
                request.masterPUT.CountryId = (request.masterPUT.CountryId != 0) ? request.masterPUT.CountryId : masterRecord.CountryId;
                request.masterPUT.CityId = (request.masterPUT.CityId != 0) ? request.masterPUT.CityId : masterRecord.CityId;
                request.masterPUT.StateId = (request.masterPUT.StateId != 0) ? request.masterPUT.StateId : masterRecord.StateId;
            }

            if (isExists == false)
            {
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.Code = request.masterPUT.Code;
                masterRecord.CountryId = request.masterPUT.CountryId;
                masterRecord.StateId = request.masterPUT.StateId;
                masterRecord.CityId = request.masterPUT.CityId;
                //masterRecord.StatusTypeId = request.masterPUT.StatusTypeId;
                masterRecord.TenantId = request.masterPUT.TenantId;
                //masterRecord.MenuModuleId = request.masterPUT.MenuModuleId;
                //masterRecord.LanguageId = request.masterPUT.LanguageId;
                masterRecord.IsDefault = request.masterPUT.IsDefault;
                //masterRecord.IsDraft = request.masterPUT.IsDraft;

                await repository.Update(masterRecord);

                AreaHistory history = new();
                history.AreaId = request.masterPUT.Id;
                history.Name = request.masterPUT.Name;
                history.Code = request.masterPUT.Code;
                history.CountryId = request.masterPUT.CountryId;
                history.StateId = request.masterPUT.StateId;
                history.CityId = request.masterPUT.CityId;
                //history.TenantId = request.masterPUT.TenantId;
                //history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.MenuModuleId = request.masterPUT.MenuModuleId;
                //history.LanguageId = request.masterPUT.LanguageId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
                history.IsDefault = request.masterPUT.IsDefault;
                //history.IsDraft = request.masterPUT.IsDraft;
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
