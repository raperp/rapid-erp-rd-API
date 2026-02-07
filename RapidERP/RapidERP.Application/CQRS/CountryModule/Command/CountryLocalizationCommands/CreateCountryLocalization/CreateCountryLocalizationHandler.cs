using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryLocalizationCommands.CreateCountryLocalization;

public class CreateCountryLocalizationHandler(IRepository repository)
{
    public async Task<RequestResponse> Handle(CreateCountryLocalizationCommand request)
    {
        RequestResponse requestResponse;

        try
        {
            var isExists = await repository.IsExists<CountryLocalization>(request.localization.Name);

            if (isExists == false)
            {
                CountryLocalization masterData = new(); 
                masterData.Name = request.localization.Name;
                masterData.CountryId = request.localization.CountryId;
                masterData.LanguageId = request.localization.LanguageId;
                 
                await repository.Add(masterData);
                
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
