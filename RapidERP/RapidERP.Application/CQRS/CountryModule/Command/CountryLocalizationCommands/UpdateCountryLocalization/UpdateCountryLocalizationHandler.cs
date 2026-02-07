using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryLocalizationCommands.UpdateCountryLocalization;

public class UpdateCountryLocalizationHandler(IRepository repository)
{
    public async Task<RequestResponse> Handle(UpdateCountryLocalizationCommand request)
    {
        RequestResponse requestResponse;

        try
        { 
            var isExists = await repository.IsExistsById<CountryLocalization>(request.localization.Id, request.localization.Name);
            var masterRecord = await repository.FindById<CountryLocalization>(request.localization.Id);

            if (masterRecord is not null)
            {
                request.localization.Name = (request.localization.Name is not null) ? request.localization.Name : masterRecord.Name;
                request.localization.CountryId = (request.localization.CountryId != 0) ? request.localization.CountryId : masterRecord.CountryId;
                request.localization.LanguageId = (request.localization.LanguageId != 0) ? request.localization.LanguageId : masterRecord.LanguageId;
            }

            if (isExists == false)
            {
                masterRecord.Name = request.localization.Name;
                masterRecord.CountryId = request.localization.CountryId;
                masterRecord.LanguageId = request.localization.LanguageId;

                await repository.Update(masterRecord);

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = request
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = $"{ResponseMessage.RecordExists} {request.localization.Name}"
                };
            }

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }
}
