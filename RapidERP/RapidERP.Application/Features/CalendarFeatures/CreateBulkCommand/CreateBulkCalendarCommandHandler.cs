using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CalendarModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CalendarFeatures.CreateBulkCommand;

public class CreateBulkCalendarCommandHandler(IRepository repository)
{
    public async Task<CreateBulkCalendarCommandResponseModel> Handle(CreateBulkCalendarCommandRequestModel request)
    {
        CreateBulkCalendarCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<Calendar>(item.Name);

                if (isExists == false)
                {
                    Calendar masterData = new();
                    masterData.TenantId = item.TenantId;
                    masterData.MenuModuleId = item.MenuModuleId;
                    //masterData.LanguageId = item.LanguageId;
                    masterData.StatusTypeId = item.StatusTypeId;
                    masterData.Code = item.Code;
                    masterData.Name = item.Name;
                    masterData.StartDate = item.StartDate;
                    masterData.EndDate = item.EndDate;
                    masterData.TotalMonth = item.TotalMonth;

                    await repository.Add(masterData);

                    CalendarHistory history = new();
                    history.CalendarId = masterData.Id;
                    //history.TenantId = item.TenantId;
                    //history.MenuModuleId = item.MenuModuleId;
                    //history.LanguageId = item.LanguageId;
                    history.ActionTypeId = item.ActionTypeId;
                    //history.ExportTypeId = item.ExportTypeId;
                    //history.ExportTo = item.ExportTo;
                    //history.SourceURL = item.SourceURL;
                    history.Code = item.Code;
                    history.Name = item.Name;
                    history.StartDate = item.StartDate;
                    history.EndDate = item.EndDate;
                    history.TotalMonth = item.TotalMonth;
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
