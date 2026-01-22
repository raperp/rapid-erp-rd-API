using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CityFeatures.CreateBulkCommand;

public class CreateBulkCityCommandHandler(IRepository repository)
{
    public async Task<CreateBulkCityCommandResponseModel> Handle(CreateBulkCityCommandRequestModel request)
    {
        CreateBulkCityCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<City>(item.Name);

                if (isExists == false)
                {
                    City masterData = new();
                    masterData.Name = item.Name;
                    masterData.Code = item.Code;
                    masterData.CountryId = item.CountryId;
                    masterData.StateId = item.StateId;
                    masterData.TenantId = item.TenantId;
                    masterData.MenuModuleId = item.MenuModuleId;
                    masterData.LanguageId = item.LanguageId;
                    masterData.StatusTypeId = item.StatusTypeId;
                    masterData.IsDefault = item.IsDefault;
                    masterData.IsDraft = item.IsDraft;

                    await repository.Add(masterData);

                    CityHistory history = new();
                    history.CityId = masterData.Id;
                    history.Name = item.Name;
                    history.Code = item.Code;
                    history.CountryId = item.CountryId;
                    history.StateId = item.StateId;
                    history.TenantId = item.TenantId;
                    history.MenuModuleId = item.MenuModuleId;
                    history.LanguageId = item.LanguageId;
                    history.ActionTypeId = item.ActionTypeId;
                    history.ExportTypeId = item.ExportTypeId;
                    history.ExportTo = item.ExportTo;
                    history.SourceURL = item.SourceURL;
                    history.IsDefault = item.IsDefault;
                    history.IsDraft = item.IsDraft;
                    history.Browser = item.Browser;
                    history.Location = item.Location;
                    history.DeviceIP = item.DeviceIP;
                    history.LocationURL = item.LocationURL;
                    history.DeviceName = item.DeviceName;
                    history.Latitude = item.Latitude;
                    history.Longitude = item.Longitude;
                    history.ActionBy = item.ActionBy;
                    history.ActionAt = DateTime.Now;

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
                        Message = $"{ResponseMessage.RecordExists} {item.Name}"
                    };
                }
            }

            return _response;
        }

        catch
        {
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return _response;
        }
    }
}
