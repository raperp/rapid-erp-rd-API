using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryMasterCommands.CreateBulkCommand;

public record CreateBulkCountryCommand(List<CountryPOST> masterPOSTs);
