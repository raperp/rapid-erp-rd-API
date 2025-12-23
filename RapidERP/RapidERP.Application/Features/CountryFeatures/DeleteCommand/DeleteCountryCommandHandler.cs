using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Application.Features.CountryFeatures.DeleteCommand;

public class DeleteCountryCommandHandler(IRepository repository)
{
    public async Task<DeleteCountryCommandResponseModel> Handle(DeleteCountryCommandRequestModel request)
    {
        var histories = repository.Set<CountryHistory>().Where(c => c.CountryId == request.id).ToList();

        foreach (var item in histories)
        {
            await repository.DeleteQueryable(item);
        }

        await repository.Delete<Country>(request.id);

        DeleteCountryCommandResponseModel response = new();
        response.Message = "Country deleted successfully.";

        return response;
    }
}
