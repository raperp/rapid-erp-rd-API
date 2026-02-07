using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TenantFeatures.UpdateCommand;

public class UpdateTenantCommandHandler(IRepository repository) 
{
    UpdateTenantCommandResponseModel _response;

    public async Task<UpdateTenantCommandResponseModel> Handle(UpdateTenantCommandRequestModel request)
    {
        try
        { 
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<Tenant>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<Tenant>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            { 
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;               
                request.masterPUT.Contact = (request.masterPUT.Contact is not null) ? request.masterPUT.Contact : masterRecord.Contact;               
                request.masterPUT.Phone = (request.masterPUT.Phone is not null) ? request.masterPUT.Phone : masterRecord.Phone;               
                request.masterPUT.Mobile = (request.masterPUT.Mobile is not null) ? request.masterPUT.Mobile : masterRecord.Mobile;               
                request.masterPUT.Address = (request.masterPUT.Address is not null) ? request.masterPUT.Address : masterRecord.Address;               
                request.masterPUT.Email = (request.masterPUT.Email is not null) ? request.masterPUT.Email : masterRecord.Email;               
                request.masterPUT.Website = (request.masterPUT.Website is not null) ? request.masterPUT.Website : masterRecord.Website;               
                request.masterPUT.MenuModuleId = (request.masterPUT.MenuModuleId is not null) ? request.masterPUT.MenuModuleId : masterRecord.MenuModuleId;
                request.masterPUT.TenantId = (request.masterPUT.TenantId is not null) ? request.masterPUT.TenantId : masterRecord.TenantId;
                request.masterPUT.StatusTypeId = (request.masterPUT.StatusTypeId is not null) ? request.masterPUT.StatusTypeId : masterRecord.StatusTypeId;
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId is not null) ? request.masterPUT.LanguageId : masterRecord.LanguageId;                
                request.masterPUT.StateId = (request.masterPUT.StateId is not null) ? request.masterPUT.StateId : masterRecord.StateId;                
                request.masterPUT.CountryId = (request.masterPUT.CountryId is not null) ? request.masterPUT.CountryId : masterRecord.CountryId;                
            }

            if (isExists == false)
            {
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.Contact = request.masterPUT.Name;
                masterRecord.Phone = request.masterPUT.Name;
                masterRecord.Mobile = request.masterPUT.Name;
                masterRecord.Address = request.masterPUT.Name;
                masterRecord.Email = request.masterPUT.Name;
                masterRecord.Website = request.masterPUT.Name;
                masterRecord.MenuModuleId = request.masterPUT.MenuModuleId;
                masterRecord.TenantId = request.masterPUT.TenantId;
                masterRecord.StatusTypeId = request.masterPUT.StatusTypeId;
                //masterRecord.LanguageId = request.masterPUT.LanguageId; 
                masterRecord.StateId = request.masterPUT.StateId; 
                masterRecord.CountryId = request.masterPUT.CountryId; 
                
                await repository.Update(masterRecord);

                TenantHistory history = new();
                history.TenantId = request.masterPUT.Id;
                history.MenuModuleId = request.masterPUT.MenuModuleId;
                history.CountryId = request.masterPUT.CountryId;
                history.StateId = request.masterPUT.StateId;
                //history.LanguageId = request.masterPUT.LanguageId;
                history.CalendarId = request.masterPUT.CalendarId;
                history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
                history.Name = request.masterPUT.Name;
                history.Contact = request.masterPUT.Contact;
                history.Phone = request.masterPUT.Phone;
                history.Mobile = request.masterPUT.Mobile;
                history.Address = request.masterPUT.Address;
                history.Email = request.masterPUT.Email;
                history.Website = request.masterPUT.Website;
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
