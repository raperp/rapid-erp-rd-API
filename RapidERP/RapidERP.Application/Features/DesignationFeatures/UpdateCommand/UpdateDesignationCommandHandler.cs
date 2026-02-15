using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DesignationModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DesignationFeatures.UpdateCommand;

public class UpdateDesignationCommandHandler(IRepository repository)
{
    UpdateDesignationCommandResponseModel _response;

    public async Task<UpdateDesignationCommandResponseModel> Handle(UpdateDesignationCommandRequestModel request)
    {
        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExistsById<Designation>(request.masterPUT.Id, request.masterPUT.Name);
            var masterRecord = await repository.FindById<Designation>(request.masterPUT.Id);

            //Loading current data to parameters
            if (masterRecord is not null)
            {
                request.masterPUT.DepartmentId = (request.masterPUT.DepartmentId != 0) ? request.masterPUT.DepartmentId : masterRecord.DepartmentId;
                request.masterPUT.Description = (request.masterPUT.Description is not null) ? request.masterPUT.Description : masterRecord.Description;
                request.masterPUT.Name = (request.masterPUT.Name is not null) ? request.masterPUT.Name : masterRecord.Name;
                request.masterPUT.TenantId = (request.masterPUT.TenantId is not null) ? request.masterPUT.TenantId : masterRecord.TenantId;
                //request.masterPUT.MenuModuleId = (request.masterPUT.MenuModuleId is not null) ? request.masterPUT.MenuModuleId : masterRecord.MenuModuleId;
                //request.masterPUT.LanguageId = (request.masterPUT.LanguageId is not null) ? request.masterPUT.LanguageId : masterRecord.LanguageId;
                //request.masterPUT.StatusTypeId = (request.masterPUT.StatusTypeId is not null) ? request.masterPUT.StatusTypeId : masterRecord.StatusTypeId;               
            }

            if (isExists == false)
            {
                masterRecord.Name = request.masterPUT.Name;
                masterRecord.Description = request.masterPUT.Description;
                masterRecord.DepartmentId = request.masterPUT.DepartmentId;
                //masterRecord.StatusTypeId = request.masterPUT.StatusTypeId;
                //masterRecord.MenuModuleId = request.masterPUT.MenuModuleId;
                masterRecord.TenantId = request.masterPUT.TenantId;
                //masterRecord.LanguageId = request.masterPUT.LanguageId;
                masterRecord.IsDefault = request.masterPUT.IsDefault;
                masterRecord.IsDraft = request.masterPUT.IsDraft;

                await repository.Update(masterRecord);

                DesignationHistory history = new();
                history.DesignationId = request.masterPUT.Id;
                history.Name = request.masterPUT.Name;
                history.Description = request.masterPUT.Description;
                history.DepartmentId = request.masterPUT.DepartmentId;
                //history.TenantId = request.masterPUT.TenantId;
                //history.MenuModuleId = request.masterPUT.MenuModuleId;
                //history.ActionTypeId = request.masterPUT.ActionTypeId;
                //history.LanguageId = request.masterPUT.LanguageId;
                //history.ExportTypeId = request.masterPUT.ExportTypeId;
                //history.ExportTo = request.masterPUT.ExportTo;
                //history.SourceURL = request.masterPUT.SourceURL;
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
