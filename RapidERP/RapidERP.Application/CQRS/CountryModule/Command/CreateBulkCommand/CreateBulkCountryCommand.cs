using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.CountryModule.Command.CreateBulkCommand;

public record CreateBulkCountryCommand(List<CountryPOST> masterPOSTs);
