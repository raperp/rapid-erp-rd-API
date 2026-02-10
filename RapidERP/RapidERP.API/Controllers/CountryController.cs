using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//public class CountryController(IMessageBus bus, ILogger<CountryController> logger) : ControllerBase
public class CountryController(ICountryService service, ICountryLocalization localizationService, ICountryExport exportService, ILogger<CountryController> logger) : ControllerBase
{  
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}", skip, take);
        //var query = new GetAllCountryCommand(skip, take);
        //var result = await bus.InvokeAsync<RequestResponse>(query);
        var result = await service.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        logger.LogInformation("GetSingle called with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new GetSingleCountryCommand(id));
        var result = await service.GetById(id);
        return Ok(result);
    }

    [HttpGet("Lookup")]
    public async Task<IActionResult> Lookup()
    {
        logger.LogInformation("Lookup called");
        var result = await service.Lookup();
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CountryPOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await service.Create(masterPOST);
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

    [HttpPut("UpdateStatus")]
    public async Task<IActionResult> UpdateStatus(UpdateStatus updateStatus)
    {
        logger.LogInformation("Update Status action performed");
        //var result = await bus.InvokeAsync<RequestResponse>(new SoftDeleteCountryCommand(id));
        var result = await service.UpdateStatus(updateStatus);
        return Ok(result);
    }

    [HttpPut("Restore")]
    public async Task<IActionResult> Restore(int id)
    {
        logger.LogInformation("Restore performed");
        //var result = await bus.InvokeAsync<RequestResponse>(new SoftDeleteCountryCommand(id));
        var result = await service.Restore(id);
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

    [HttpGet("GetAllCountryLocalizations")]
    public async Task<IActionResult> GetAllCountryLocalizations()
    {
        logger.LogInformation("Get All Country Localizations called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await localizationService.GetAll();
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

    [HttpPost("CreateExport")]
    public async Task<IActionResult> CreateExport(CountryExportDTO export)
    {
        logger.LogInformation("CreateSingle called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await exportService.Create(export);
        return Ok(result);
    }
}
