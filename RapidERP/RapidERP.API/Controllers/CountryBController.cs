using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.CQRS.CountryModule.Query.GetAllQuery;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//public class CountryBController(IMessageBus bus, ILogger<CountryController> logger) : ControllerBase
public class CountryBController(ICountryBService service, ICountryLocalization localizationService, ILogger<CountryController> logger) : ControllerBase
{  
    [HttpGet("GetAll")]
    //[ProducesResponseType(typeof(GetAllCountryResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllCountryCommand(skip, take, pageSize);
        //var result = await bus.InvokeAsync<RequestResponse>(query);
        var result = await service.GetAll(skip, take, pageSize);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    //[ProducesResponseType(typeof(GetSingleCountryResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle(int id)
    {
        logger.LogInformation("GetSingle called with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new GetSingleCountryCommand(id));
        var result = await service.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    //[ProducesResponseType(typeof(GetHistoryCountryResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        //var query = new GetHistoryCountryCommand(skip, take, pageSize);
        var result = await service.GetHistory(skip, take, pageSize);
        return Ok(result);
    }

    [HttpGet("GetAllCountryLocalizations")]
    //[ProducesResponseType(typeof(CountryTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCountryLocalizations()
    {
        logger.LogInformation("Get All Country Localizations called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await localizationService.GetAll();
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(CountryPOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await service.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateCountryLocalization")]
    public async Task<IActionResult> CreateCountryLocalization(CountryLocalizationPOST localization)
    {
        logger.LogInformation("Create Country Localization called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateCountryLocalizationCommand(localization));
        var result = await localizationService.Create(localization);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<CountryPOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateBulkCountryCommand(masterPOSTs));
        var result = await service.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CountryPUT masterPUT)
    {
        logger.LogInformation("Update called");
        //var result = await bus.InvokeAsync<RequestResponse>(new UpdateCountryCommand(masterPUT));
        var result = await service.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("UpdateCountryLocalization")]
    public async Task<IActionResult> UpdateCountryLocalization(CountryLocalizationPUT localization)
    {
        logger.LogInformation("Update called");
        //var result = await bus.InvokeAsync<RequestResponse>(new UpdateCountryLocalizationCommand(localization));
        var result = await localizationService.Update(localization);
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new SoftDeleteCountryCommand(id));
        var result = await service.SoftDelete(id);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new DeleteCountryCommand(id));
        var result = await service.Delete(id);
        return Ok(result);
    }

    [HttpPut("DeleteCountryLocalization")]
    public async Task<IActionResult> DeleteCountryLocalization(int id)
    {
        logger.LogInformation("Delete Country Localization performed with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new DeleteCountryLocalizationCommand(id));
        var result = await localizationService.Delete(id);
        return Ok(result);
    }
}
