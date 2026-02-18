using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SolutionModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SolutionFeatures.UpdateCommand;

public class UpdateSolutionCommandHandler(IRepository repository)
{
    UpdateSolutionCommandResponseModel _response;

    public async Task<UpdateSolutionCommandResponseModel> Handle(UpdateSolutionCommandRequestModel request)
    {
        try
        { 
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsByIdName<Solution>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<Solution>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            { 
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;                 
                request.masterPUT.Code = (request.masterPUT.Code is not null) ? request.masterPUT.Code : masterRecord.Code;                 
                request.masterPUT.Icon = (request.masterPUT.Icon is not null) ? request.masterPUT.Icon : masterRecord.Icon;                 
                request.masterPUT.Description = (request.masterPUT.Description is not null) ? request.masterPUT.Description : masterRecord.Description;                 
                //request.masterPUT.MenuModuleId = (request.masterPUT.MenuModuleId is not null) ? request.masterPUT.MenuModuleId : masterRecord.MenuModuleId;
                request.masterPUT.TenantId = (request.masterPUT.TenantId is not null) ? request.masterPUT.TenantId : masterRecord.TenantId;
                //request.masterPUT.StatusTypeId = (request.masterPUT.StatusTypeId is not null) ? request.masterPUT.StatusTypeId : masterRecord.StatusTypeId;
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId is not null) ? request.masterPUT.LanguageId : masterRecord.LanguageId;                
            }

            if (isExists == false)
            {
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.Code = request.masterPUT.Code;
                masterRecord.Icon = request.masterPUT.Icon;
                masterRecord.Description = request.masterPUT.Description;
                //masterRecord.MenuModuleId = request.masterPUT.MenuModuleId;
                masterRecord.TenantId = request.masterPUT.TenantId;
                //masterRecord.StatusTypeId = request.masterPUT.StatusTypeId;
                //masterRecord.LanguageId = request.masterPUT.LanguageId;                
                
                //masterRecord.IsDefault = request.masterPUT.IsDefault;
                //masterRecord.IsDraft = request.masterPUT.IsDraft;
                
                await repository.Update(masterRecord);

                SolutionHistory history = new();
                history.SolutionId = request.masterPUT.Id;
                //history.TenantId = request.masterPUT.TenantId;
                //history.MenuModuleId = request.masterPUT.MenuModuleId;
                //history.LanguageId = request.masterPUT.LanguageId;
                history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
                history.Code = request.masterPUT.Code;
                history.Name = request.masterPUT.Name;
                history.Icon = request.masterPUT.Icon;
                history.Description = request.masterPUT.Description;
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
