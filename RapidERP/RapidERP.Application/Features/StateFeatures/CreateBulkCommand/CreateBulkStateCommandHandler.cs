using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StateFeatures.CreateBulkCommand;

public class CreateBulkStateCommandHandler(IRepository repository)
{
    public async Task<CreateBulkStateCommandResponseModel> Handle(CreateBulkStateCommandRequestModel request)
    {
        CreateBulkStateCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<State>(item.Name);

                if (isExists == false)
                {
                    State masterData = new();
                    masterData.MenuModuleId = item.MenuModuleId;
                    masterData.CountryId = item.CountryId;
                    masterData.StatusTypeId = item.StatusTypeId;
                    //masterData.LanguageId = item.LanguageId;
                    masterData.Code = item.Code;
                    masterData.Name = item.Name;
                    masterData.IsDefault = item.IsDefault;
                    masterData.IsDraft = item.IsDraft;

                    await repository.Add(masterData);

                    StateHistory history = new();
                    //history.StateId = masterData.Id;
                    //history.MenuModuleId = item.MenuModuleId;
                    history.CountryId = item.CountryId;
                    //history.LanguageId = item.LanguageId;
                    history.ActionTypeId = item.ActionTypeId;
                    //history.ExportTypeId = item.ExportTypeId;
                    //history.ExportTo = item.ExportTo;
                    //history.SourceURL = item.SourceURL;
                    history.Code = item.Code;
                    history.Name = item.Name;
                    history.IsDefault = item.IsDefault;
                    history.IsDraft = item.IsDraft;
                    //history.Browser = item.Browser;
                    //history.Location = item.Location;
                    //history.DeviceIP = item.DeviceIP;
                    //history.LocationURL = item.LocationURL;
                    //history.DeviceName = item.DeviceName;
                    //history.Latitude = item.Latitude;
                    //history.Longitude = item.Longitude;
                    //history.ActionBy = item.ActionBy;
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
