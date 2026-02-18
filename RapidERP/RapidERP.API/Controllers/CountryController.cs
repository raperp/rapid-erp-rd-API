using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces.Country;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//public class CountryController(IMessageBus bus, ILogger<CountryController> logger) : ControllerBase
//public class CountryController(ICountry service, ICountryLocalization localizationService, ICountryExport exportService, ICountryActivity activityService, ICountryAudit auditService, ICountryCapture captureService, ICountryCurrency currencyService, ILogger<CountryController> logger) : ControllerBase
public class CountryController(CountryServiceDTO serviceDTO, ILogger<CountryController> logger) : ControllerBase
{  
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}", skip, take);
        //var query = new GetAllCountryCommand(skip, take);
        //var result = await bus.InvokeAsync<RequestResponse>(query);
        var result = await serviceDTO.countryService.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetAllAudits")]
    public async Task<IActionResult> GetAllAudits()
    {
        //logger.LogInformation("GetAll called with skip: {skip}, take: {take}", skip, take);
        //var query = new GetAllCountryCommand(skip, take);
        //var result = await bus.InvokeAsync<RequestResponse>(query);
        var result = await serviceDTO.auditService.GetAll();
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        logger.LogInformation("GetSingle called with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new GetSingleCountryCommand(id));
        var result = await serviceDTO.countryService.GetById(id);
        return Ok(result);
    }

    [HttpGet("Lookup")]
    public async Task<IActionResult> Lookup()
    {
        logger.LogInformation("Lookup called");
        var result = await serviceDTO.countryService.Lookup();
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CountryPOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await serviceDTO.countryService.Create(masterPOST);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CountryPUT masterPUT)
    {
        logger.LogInformation("Update called");
        //var result = await bus.InvokeAsync<RequestResponse>(new UpdateCountryCommand(masterPUT));
        var result = await serviceDTO.countryService.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("UpdateStatus")]
    public async Task<IActionResult> UpdateStatus(UpdateStatus updateStatus)
    {
        logger.LogInformation("Update Status action performed");
        //var result = await bus.InvokeAsync<RequestResponse>(new SoftDeleteCountryCommand(id));
        var result = await serviceDTO.countryService.UpdateStatus(updateStatus);
        return Ok(result);
    }

    [HttpPost("CreateAudit")]
    public async Task<IActionResult> CreateAudit(CountryAuditDTO masterPOST)
    {
        logger.LogInformation("Create Audit called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await serviceDTO.auditService.Create(masterPOST);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new DeleteCountryCommand(id));
        var result = await serviceDTO.countryService.Delete(id);
        return Ok(result);
    }

    [HttpGet("GetAllLocalizations")]
    public async Task<IActionResult> GetAllCountryLocalizations()
    {
        logger.LogInformation("Get All Country Localizations called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await serviceDTO.localizationService.GetAll();
        return Ok(result);
    }

    [HttpPost("CreateLocalization")]
    public async Task<IActionResult> CreateLocalization(CountryLocalizationPOST localizationPOST)
    {
        logger.LogInformation("Create Localization called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await serviceDTO.localizationService.Create(localizationPOST);
        return Ok(result);
    }

    [HttpDelete("DeleteCountryLocalization")]
    public async Task<IActionResult> DeleteCountryLocalization(int id)
    {
        logger.LogInformation("Delete Country Localization performed with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new DeleteCountryLocalizationCommand(id));
        var result = await serviceDTO.localizationService.Delete(id);
        return Ok(result);
    }

    [HttpPost("CreateCurrency")]
    public async Task<IActionResult> CreateCurrency(CountryCurrencyPOST currencyPOST)
    {
        logger.LogInformation("Create Currency called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await serviceDTO.currencyService.Create(currencyPOST);
        return Ok(result);
    }

    [HttpDelete("DeleteCurrency")]
    public async Task<IActionResult> DeleteCurrency(int id)
    {
        logger.LogInformation("Update Currency called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await serviceDTO.currencyService.Delete(id);
        return Ok(result);
    }

    [HttpPost("CreateExport")]
    public async Task<IActionResult> CreateExport(CountryExportDTO export)
    {
        logger.LogInformation("CreateSingle called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await serviceDTO.exportService.Create(export);
        return Ok(result);
    }

    [HttpPost("CreateCountryCapture")]
    public async Task<IActionResult> CreateCountryCapture(CountryCapturePOST captured)
    {
        logger.LogInformation("Create captured called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await serviceDTO.captureService.Create(captured);
        return Ok(result);
    }

    [HttpDelete("DeleteCountryCapture")]
    public async Task<IActionResult> DeleteCountryCapture(int id)
    {
        logger.LogInformation("Delete Country Capture called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await serviceDTO.captureService.Delete(id);
        return Ok(result);
    }

    [HttpPost("Import")]
    public async Task<IActionResult> Import(List<CountryImport> imports)
    {
        logger.LogInformation("Create import called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await serviceDTO.countryService.Import(imports);
        return Ok(result);
    }   
}
