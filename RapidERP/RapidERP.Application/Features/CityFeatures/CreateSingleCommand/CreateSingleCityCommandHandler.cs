using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CityFeatures.CreateSingleCommand;

public class CreateSingleCityCommandHandler(IRepository repository)
{
    public async Task<CreateSingleCityCommandResponseModel> Handle(CreateSingleCityCommandRequestModel request)
    {
        CreateSingleCityCommandResponseModel _response; 

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<City>(request.masterPOST.Name);

            if (isExists == false)
            {
                City masterData = new();
                masterData.Name = request.masterPOST.Name;
                masterData.Code = request.masterPOST.Code;
                masterData.CountryId = request.masterPOST.CountryId;
                masterData.StateId = request.masterPOST.StateId;
                masterData.TenantId = request.masterPOST.TenantId;
                masterData.MenuModuleId = request.masterPOST.MenuModuleId;
                //masterData.LanguageId = request.masterPOST.LanguageId;
                masterData.StatusTypeId = request.masterPOST.StatusTypeId;
                masterData.IsDefault = request.masterPOST.IsDefault;
                masterData.IsDraft = request.masterPOST.IsDraft;

                await repository.Add(masterData);

                CityHistory history = new();
                history.CityId = masterData.Id;
                history.Name = request.masterPOST.Name;
                history.Code = request.masterPOST.Code;
                history.CountryId = request.masterPOST.CountryId;
                history.StateId = request.masterPOST.StateId;
                //history.TenantId = request.masterPOST.TenantId;
                //history.MenuModuleId = request.masterPOST.MenuModuleId;
                //history.LanguageId = request.masterPOST.LanguageId;
                history.ActionTypeId = request.masterPOST.ActionTypeId;
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
