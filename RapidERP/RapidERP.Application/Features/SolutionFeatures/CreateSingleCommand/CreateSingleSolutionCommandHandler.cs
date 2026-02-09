using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SolutionModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SolutionFeatures.CreateSingleCommand;

public class CreateSingleSolutionCommandHandler(IRepository repository)
{
    public async Task<CreateSingleSolutionCommandResponseModel> Handle(CreateSingleSolutionCommandRequestModel request)
    {
        CreateSingleSolutionCommandResponseModel _response; 

        try
        {
            using var transaction = repository.BeginTransaction();
            var isExists = await repository.IsExists<Solution>(request.masterPOST.Name);

            if (isExists == false)
            {
                Solution masterData = new();
                masterData.TenantId = request.masterPOST.TenantId;
                //masterData.MenuModuleId = request.masterPOST.MenuModuleId;
                //masterData.LanguageId = request.masterPOST.LanguageId;
                //masterData.StatusTypeId = request.masterPOST.StatusTypeId;
                masterData.Code = request.masterPOST.Code;
                masterData.Name = request.masterPOST.Name;
                masterData.Icon = request.masterPOST.Icon;
                masterData.Description = request.masterPOST.Description;

                await repository.Add(masterData);

                SolutionHistory history = new();
                history.SolutionId = masterData.Id;
                //history.TenantId = request.masterPOST.TenantId;
                //history.MenuModuleId = request.masterPOST.MenuModuleId;
                //history.LanguageId = request.masterPOST.LanguageId;
                history.ActionTypeId = request.masterPOST.ActionTypeId;
                //history.ExportTypeId = request.masterPOST.ExportTypeId;
                //history.ExportTo = request.masterPOST.ExportTo;
                //history.SourceURL = request.masterPOST.SourceURL;
                history.Code = request.masterPOST.Code;
                history.Name = request.masterPOST.Name;
                history.Icon = request.masterPOST.Icon;
                history.Description = request.masterPOST.Description;
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
