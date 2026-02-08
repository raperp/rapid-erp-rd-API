using RapidERP.Application.Features.TenantFeatures.CreateBulkCommand;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TenantFeatures.CreateBulkCommand;

public class CreateBulkTenantCommandHandler(IRepository repository)
{
    public async Task<CreateBulkTenantCommandResponseModel> Handle(CreateBulkTenantCommandRequestModel request)
    {
        CreateBulkTenantCommandResponseModel _response = new(); 

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<Tenant>(item.Name);

                if (isExists == false)
                {
                    Tenant masterData = new();
                    masterData.MenuModuleId = item.MenuModuleId;
                    masterData.CountryId = item.CountryId;
                    masterData.StateId = item.StateId;
                    masterData.StatusTypeId = item.StatusTypeId;
                    //masterData.LanguageId = item.LanguageId;
                    masterData.Name = item.Name;
                    masterData.Contact = item.Contact;
                    masterData.Phone = item.Phone;
                    masterData.Mobile = item.Mobile;
                    masterData.Address = item.Address;
                    masterData.Email = item.Email;
                    masterData.Website = item.Website;

                    await repository.Add(masterData);

                    TenantHistory history = new();
                    //history.TenantId = masterData.Id;
                    //history.MenuModuleId = item.MenuModuleId;
                    history.CountryId = item.CountryId;
                    history.StateId = item.StateId;
                    //history.LanguageId = item.LanguageId;
                    history.CalendarId = item.CalendarId;
                    history.ActionTypeId = item.ActionTypeId;
                    //history.ExportTypeId = item.ExportTypeId;
                    //history.ExportTo = item.ExportTo;
                    //history.SourceURL = item.SourceURL;
                    history.Name = item.Name;
                    history.Contact = item.Contact;
                    history.Phone = item.Phone;
                    history.Mobile = item.Mobile;
                    history.Address = item.Address;
                    history.Email = item.Email;
                    history.Website = item.Website;
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
