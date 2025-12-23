using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Application.Features.CountryFeatures.SoftDeleteCommand;

public class SoftDeleteCountryCommandHandler(IRepository repository)
{
    public async Task<SoftDeleteCountryCommandResponseModel> Handle(SoftDeleteCountryCommandRequestModel request)
    {
        await repository.SoftDelete<Country>(request.id);
        SoftDeleteCountryCommandResponseModel responseModel = new();
        responseModel.Message = "Country soft deleted successfully.";
        return responseModel;
    }
}
