using RapidERP.Application.Interfaces.Country;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryExportCommands.Create;

public class CreateCountryExportHandler(ICountryExport service)
{
    public async Task<RequestResponse> Handle(CreateCountryExportCommand request)
    {
        var result = await service.Create(request.export);
        return result;
    }
}
