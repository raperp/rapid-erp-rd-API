using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CalendarModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CalendarFeatures.UpdateCommand;

public class UpdateCalendarCommandHandler(IRepository repository)
{
    UpdateCalendarCommandResponseModel _response;

    public async Task<UpdateCalendarCommandResponseModel> Handle(UpdateCalendarCommandRequestModel request)
    {
        try
        { 
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<Calendar>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<Calendar>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.TenantId = (request.masterPUT.TenantId != 0) ? request.masterPUT.TenantId : masterRecord.TenantId;
                //request.masterPUT.MenuModuleId = (request.masterPUT.MenuModuleId != 0) ? request.masterPUT.MenuModuleId : masterRecord.MenuModuleId;
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId is not null) ? request.masterPUT.LanguageId : masterRecord.LanguageId;
                //request.masterPUT.StatusTypeId = (request.masterPUT.StatusTypeId is not null) ? request.masterPUT.StatusTypeId : masterRecord.StatusTypeId;
                request.masterPUT.Code = (request.masterPUT.Code is not null) ? request.masterPUT.Code : masterRecord.Code;
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;
                request.masterPUT.StartDate = (request.masterPUT.StartDate is not null) ? request.masterPUT.StartDate : masterRecord.StartDate;
                request.masterPUT.EndDate = (request.masterPUT.EndDate is not null) ? request.masterPUT.EndDate : masterRecord.EndDate;
                request.masterPUT.TotalMonth = (request.masterPUT.TotalMonth != 0) ? request.masterPUT.TotalMonth : masterRecord.TotalMonth;  
            }
             
            if (isExists == false)
            {
                masterRecord.TenantId = request.masterPUT.TenantId;
                //masterRecord.MenuModuleId = request.masterPUT.MenuModuleId;
                //masterRecord.LanguageId = request.masterPUT.LanguageId;
                //masterRecord.StatusTypeId = request.masterPUT.StatusTypeId;
                masterRecord.Code = request.masterPUT.Code;
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.StartDate = request.masterPUT.StartDate;
                masterRecord.EndDate = request.masterPUT.EndDate;
                masterRecord.TotalMonth = request.masterPUT.TotalMonth;
                //masterRecord.IsDefault = request.masterPUT.IsDefault;
                //masterRecord.IsDraft = request.masterPUT.IsDraft;
                 
                await repository.Update(masterRecord);

                CalendarHistory history = new();
                history.CalendarId = request.masterPUT.Id;
                //history.TenantId = request.masterPUT.TenantId;
                //history.MenuModuleId = request.masterPUT.MenuModuleId;
                //history.LanguageId = request.masterPUT.LanguageId;
                history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
                history.Code = request.masterPUT.Code;
                history.Name = request.masterPUT.Name;
                history.StartDate = request.masterPUT.StartDate;
                history.EndDate = request.masterPUT.EndDate;
                history.TotalMonth = request.masterPUT.TotalMonth;
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
