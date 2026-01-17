using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SolutionModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SolutionFeatures.CreateBulkCommand;

public class CreateBulkSolutionCommandHandler(IRepository repository)
{
    public async Task<CreateBulkSolutionCommandResponseModel> Handle(CreateBulkSolutionCommandRequestModel request)
    {
        CreateBulkSolutionCommandResponseModel _response = new();

        try
        {
            foreach (var item in request.masterPOSTs)
            {
                using var transaction = repository.BeginTransaction();
                var isExists = await repository.IsExists<Solution>(item.Name);

                if (isExists == false)
                {
                    Solution masterData = new();
                    masterData.TenantId = item.TenantId;
                    masterData.MenuModuleId = item.MenuModuleId;
                    masterData.LanguageId = item.LanguageId;
                    masterData.StatusTypeId = item.StatusTypeId;
                    masterData.Code = item.Code;
                    masterData.Name = item.Name;
                    masterData.Icon = item.Icon;
                    masterData.Description = item.Description;

                    await repository.Add(masterData);

                    SolutionHistory history = new();
                    history.SolutionId = masterData.Id;
                    history.TenantId = item.TenantId;
                    history.MenuModuleId = item.MenuModuleId;
                    history.LanguageId = item.LanguageId;
                    history.ActionTypeId = item.ActionTypeId;
                    history.ExportTypeId = item.ExportTypeId;
                    history.ExportTo = item.ExportTo;
                    history.SourceURL = item.SourceURL;
                    history.Code = item.Code;
                    history.Name = item.Name;
                    history.Icon = item.Icon;
                    history.Description = item.Description;
                    history.Browser = item.Browser;
                    history.Location = item.Location;
                    history.DeviceIP = item.DeviceIP;
                    history.LocationURL = item.LocationURL;
                    history.DeviceName = item.DeviceName;
                    history.Latitude = item.Latitude;
                    history.Longitude = item.Longitude;
                    history.ActionBy = item.ActionBy;
                    history.ActionAt = DateTime.Now;

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
