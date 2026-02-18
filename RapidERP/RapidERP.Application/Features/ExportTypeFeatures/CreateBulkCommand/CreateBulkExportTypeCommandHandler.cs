using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ExportTypeFeatures.CreateBulkCommand;

public class CreateBulkExportTypeCommandHandler(IRepository repository)
{
    public async Task<CreateBulkExportTypeCommandResponseModel> Handle(CreateBulkExportTypeCommandRequestModel request)
    {
        CreateBulkExportTypeCommandResponseModel _response = new();

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExistsByName<ExportType>(item.Name);

                if (isExists == false)
                {
                    ExportType masterData = new();
                    //masterData.LanguageId = item.LanguageId;
                    masterData.Name = item.Name;
                    masterData.Description = item.Description;

                    await repository.Add(masterData);

                    ExportTypeHistory history = new();
                    history.ExportTypeId = masterData.Id;
                    //history.LanguageId = item.LanguageId;
                    history.Name = item.Name;
                    history.Description = item.Description;
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
