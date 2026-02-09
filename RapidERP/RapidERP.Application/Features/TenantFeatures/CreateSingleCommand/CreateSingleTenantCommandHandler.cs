using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TenantFeatures.CreateSingleCommand;

public class CreateSingleTenantCommandHandler(IRepository repository)
{
    public async Task<CreateSingleTenantCommandResponseModel> Handle(CreateSingleTenantCommandRequestModel request)
    {
        CreateSingleTenantCommandResponseModel _response; 

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<Tenant>(request.masterPOST.Name);

            if (isExists == false)
            {
                Tenant masterData = new();
                //masterData.MenuModuleId = request.masterPOST.MenuModuleId;
                masterData.CountryId = request.masterPOST.CountryId;
                masterData.StateId = request.masterPOST.StateId;
                //masterData.StatusTypeId = request.masterPOST.StatusTypeId;
                //masterData.LanguageId = request.masterPOST.LanguageId;
                masterData.Name = request.masterPOST.Name;
                masterData.Contact = request.masterPOST.Contact;
                masterData.Phone = request.masterPOST.Phone;
                masterData.Mobile = request.masterPOST.Mobile;
                masterData.Address = request.masterPOST.Address;
                masterData.Email = request.masterPOST.Email;
                masterData.Website = request.masterPOST.Website;

                await repository.Add(masterData);

                TenantHistory history = new();
                history.TenantId = masterData.Id;
                //history.MenuModuleId = request.masterPOST.MenuModuleId;
                history.CountryId = request.masterPOST.CountryId;
                history.StateId = request.masterPOST.StateId;
                //history.LanguageId = request.masterPOST.LanguageId;
                history.CalendarId = request.masterPOST.CalendarId;
                history.ActionTypeId = request.masterPOST.ActionTypeId;
                //history.ExportTypeId = request.masterPOST.ExportTypeId;
                //history.ExportTo = request.masterPOST.ExportTo;
                //history.SourceURL = request.masterPOST.SourceURL;
                history.Name = request.masterPOST.Name;
                history.Contact = request.masterPOST.Contact;
                history.Phone = request.masterPOST.Phone;
                history.Mobile = request.masterPOST.Mobile;
                history.Address = request.masterPOST.Address;
                history.Email = request.masterPOST.Email;
                history.Website = request.masterPOST.Website;
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
