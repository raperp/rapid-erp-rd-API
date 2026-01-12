using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StatusTypeFeatures.UpdateCommand;

public class UpdateStatusTypeCommandHandler(IRepository repository)
{
    UpdateStatusTypeCommandResponseModel _response;

    public async Task<UpdateStatusTypeCommandResponseModel> Handle(UpdateStatusTypeCommandRequestModel request)
    {
        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<StatusType>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<StatusType>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;
                request.masterPUT.LanguageId = (request.masterPUT.LanguageId is not null) ? request.masterPUT.LanguageId : masterRecord.LanguageId;
                request.masterPUT.Description = (request.masterPUT.Description is not null) ? request.masterPUT.Description : masterRecord.Description;               
            }

            if (isExists == false)
            {
                masterRecord.LanguageId = request.masterPUT.LanguageId;                
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.Description = request.masterPUT.Description;
                
                await repository.Update(masterRecord);

                StatusTypeHistory history = new();
                history.StatusTypeId = request.masterPUT.Id;
                history.LanguageId = request.masterPUT.LanguageId;
                history.ActionTypeId = request.masterPUT.ActionTypeId;
                history.ExportTypeId = request.masterPUT.ExportTypeId;
                history.ExportTo = request.masterPUT.ExportTo;
                history.SourceURL = request.masterPUT.SourceURL;
                history.Name = request.masterPUT.Name;
                history.Description = request.masterPUT.Description;
                history.Browser = request.masterPUT.Browser;
                history.Location = request.masterPUT.Location;
                history.DeviceIP = request.masterPUT.DeviceIP;
                history.LocationURL = request.masterPUT.LocationURL;
                history.DeviceName = request.masterPUT.DeviceName;
                history.Latitude = request.masterPUT.Latitude;
                history.Longitude = request.masterPUT.Longitude;
                history.ActionBy = request.masterPUT.ActionBy;
                history.ActionAt = DateTime.Now;

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
