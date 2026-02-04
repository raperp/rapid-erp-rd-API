using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.CQRS.CountryModule.Command.CreateBulkCommand;
using RapidERP.Application.CQRS.CountryModule.Command.CreateCountryLocalization;
using RapidERP.Application.CQRS.CountryModule.Command.CreateSingleCommand;
using RapidERP.Application.CQRS.CountryModule.Command.DeleteCommand;
using RapidERP.Application.CQRS.CountryModule.Command.DeleteCountryLocalization;
using RapidERP.Application.CQRS.CountryModule.Command.SoftDeleteCommand;
using RapidERP.Application.CQRS.CountryModule.Command.UpdateCommand;
using RapidERP.Application.CQRS.CountryModule.Command.UpdateCountryLocalization;
using RapidERP.Application.CQRS.CountryModule.Query.GetAllCountryLocalizations;
using RapidERP.Application.CQRS.CountryModule.Query.GetAllQuery;
using RapidERP.Application.CQRS.CountryModule.Query.GetAllTemplateDataQuery;
using RapidERP.Application.CQRS.CountryModule.Query.GetHistoryQuery;
using RapidERP.Application.CQRS.CountryModule.Query.GetSingleQuery;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Domain.Utilities;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryBController(IMessageBus bus, ILogger<CountryController> logger) : ControllerBase
{  
    [HttpGet("GetAll")]
    //[ProducesResponseType(typeof(GetAllCountryResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllCountryCommand(skip, take, pageSize);
        var result = await bus.InvokeAsync<RequestResponse>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    //[ProducesResponseType(typeof(GetSingleCountryResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle(int id)
    {
        logger.LogInformation("GetSingle called with id: {id}", id);
        var result = await bus.InvokeAsync<RequestResponse>(new GetSingleCountryCommand(id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    //[ProducesResponseType(typeof(GetHistoryCountryResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetHistoryCountryCommand(skip, take, pageSize);
        var result = await bus.InvokeAsync<RequestResponse>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    //[ProducesResponseType(typeof(CountryTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryTemplateDataCommand());
        return Ok(result);

    }

    [HttpGet("GetAllCountryLocalizations")]
    //[ProducesResponseType(typeof(CountryTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCountryLocalizations()
    {
        logger.LogInformation("Get All Country Localizations called");
        var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(CountryPOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateCountryLocalization")]
    public async Task<IActionResult> CreateCountryLocalization(CountryLocalizationPOST localization)
    {
        logger.LogInformation("Create Country Localization called");
        var result = await bus.InvokeAsync<RequestResponse>(new CreateCountryLocalizationCommand(localization));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<CountryPOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<RequestResponse>(new CreateBulkCountryCommand(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CountryPUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<RequestResponse>(new UpdateCountryCommand(masterPUT));
        return Ok(result);
    }

    [HttpPut("UpdateCountryLocalization")]
    public async Task<IActionResult> UpdateCountryLocalization(CountryLocalizationPUT localization)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<RequestResponse>(new UpdateCountryLocalizationCommand(localization));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<RequestResponse>(new SoftDeleteCountryCommand(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<RequestResponse>(new DeleteCountryCommand(id));
        return Ok(result);
    }

    [HttpPut("DeleteCountryLocalization")]
    public async Task<IActionResult> DeleteCountryLocalization(int id)
    {
        logger.LogInformation("Delete Country Localization performed with id: {id}", id);
        var result = await bus.InvokeAsync<RequestResponse>(new DeleteCountryLocalizationCommand(id));
        return Ok(result);
    }
}
