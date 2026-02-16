using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StateFeatures.UpdateCommand;

public class UpdateStateCommandHandler(IRepository repository)
{
    UpdateStateCommandResponseModel _response;

    public async Task<UpdateStateCommandResponseModel> Handle(UpdateStateCommandRequestModel request)
    {
        try
        { 
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<State>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<State>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            { 
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;    
                request.masterPUT.Code = (request.masterPUT.Code is not null) ? request.masterPUT.Code : masterRecord.Code;    
                //request.masterPUT.MenuModuleId = (request.masterPUT.MenuModuleId is not null) ? request.masterPUT.MenuModuleId : masterRecord.MenuModuleId;
                //request.masterPUT.StatusTypeId = (request.masterPUT.StatusTypeId is not null) ? request.masterPUT.StatusTypeId : masterRecord.StatusTypeId;
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId is not null) ? request.masterPUT.LanguageId : masterRecord.LanguageId;          
                request.masterPUT.CountryId = (request.masterPUT.CountryId != 0) ? request.masterPUT.CountryId : masterRecord.CountryId;          
            }

            if (isExists == false)
            {
                //masterRecord.MenuModuleId = request.masterPUT.MenuModuleId;
                masterRecord.CountryId = request.masterPUT.CountryId;
                //masterRecord.StatusTypeId = request.masterPUT.StatusTypeId;
                //masterRecord.LanguageId = request.masterPUT.LanguageId; 
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.Code = request.masterPUT.Code;
                masterRecord.IsDefault = request.masterPUT.IsDefault;
                //masterRecord.IsDraft = request.masterPUT.IsDraft;
                 
                await repository.Update(masterRecord);

                StateHistory history = new();
                history.StateId = request.masterPUT.Id;
                //history.MenuModuleId = request.masterPUT.MenuModuleId;
                history.CountryId = request.masterPUT.CountryId;
                //history.LanguageId = request.masterPUT.LanguageId;
                //history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
                history.Code = request.masterPUT.Code;
                history.Name = request.masterPUT.Name;
                history.IsDefault = request.masterPUT.IsDefault;
                //history.IsDraft = request.masterPUT.IsDraft;
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
