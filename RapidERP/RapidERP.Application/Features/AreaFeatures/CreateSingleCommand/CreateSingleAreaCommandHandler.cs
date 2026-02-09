using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.AreaFeatures.CreateSingleCommand;

public record CreateSingleAreaCommandHandler(IRepository repository)
{
    public async Task<CreateSingleAreaCommandResponseModel> Handle(CreateSingleAreaCommandRequestModel request)
    {
        CreateSingleAreaCommandResponseModel _response;

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<Area>(request.masterPOST.Name);

            if (isExists == false)
            {
                Area masterData = new();
                masterData.Name = request.masterPOST.Name;
                masterData.Code = request.masterPOST.Code;
                masterData.CountryId = request.masterPOST.CountryId;
                masterData.StateId = request.masterPOST.StateId;
                masterData.CityId = request.masterPOST.CityId;
                //masterData.StatusTypeId = request.masterPOST.StatusTypeId;
                masterData.TenantId = request.masterPOST.TenantId;
                //masterData.MenuModuleId = request.masterPOST.MenuModuleId;
                //masterData.LanguageId = request.masterPOST.LanguageId;
                masterData.IsDefault = request.masterPOST.IsDefault;
                masterData.IsDraft = request.masterPOST.IsDraft;

                await repository.Add(masterData);

                AreaHistory history = new();
                history.AreaId = masterData.Id;
                history.Name = request.masterPOST.Name;
                history.Code = request.masterPOST.Code;
                history.CountryId = request.masterPOST.CountryId;
                history.StateId = request.masterPOST.StateId;
                history.CityId = request.masterPOST.CityId;
                //history.TenantId = request.masterPOST.TenantId;
                //history.ActionTypeId = request.masterPOST.ActionTypeId;
                //history.MenuModuleId = request.masterPOST.MenuModuleId;
                //history.LanguageId = request.masterPOST.LanguageId;
                //history.ExportTypeId = request.masterPOST.ExportTypeId;
                //history.ExportTo = request.masterPOST.ExportTo;
                //history.SourceURL = request.masterPOST.SourceURL;
                history.IsDefault = request.masterPOST.IsDefault;
                history.IsDraft = request.masterPOST.IsDraft;
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
                    Message = $"{ResponseMessage.RecordExists} {request.masterPOST.Name}"
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
