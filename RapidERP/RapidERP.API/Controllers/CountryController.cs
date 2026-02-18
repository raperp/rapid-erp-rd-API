using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces.Country;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//public class CountryController(IMessageBus bus, ILogger<CountryController> logger) : ControllerBase
public class CountryController(ICountry countryService, ICountryLocalization localizationService, ICountryExport exportService, ICountryActivity activityService, ICountryAudit auditService, ICountryCapture captureService, ICountryCurrency currencyService, ILogger<CountryController> logger) : ControllerBase
{  
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}", skip, take);
        //var query = new GetAllCountryCommand(skip, take);
        //var result = await bus.InvokeAsync<RequestResponse>(query);
        var result = await countryService.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        logger.LogInformation("GetSingle called with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new GetSingleCountryCommand(id));
        var result = await countryService.GetById(id);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CountryPOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await countryService.Create(masterPOST);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CountryPUT masterPUT)
    {
        logger.LogInformation("Update called");
        //var result = await bus.InvokeAsync<RequestResponse>(new UpdateCountryCommand(masterPUT));
        var result = await countryService.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("UpdateStatus")]
    public async Task<IActionResult> UpdateStatus(UpdateStatus updateStatus)
    {
        logger.LogInformation("Update Status action performed");
        //var result = await bus.InvokeAsync<RequestResponse>(new SoftDeleteCountryCommand(id));
        var result = await countryService.UpdateStatus(updateStatus);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new DeleteCountryCommand(id));
        var result = await countryService.Delete(id);
        return Ok(result);
    }

    [HttpPost("Import")]
    public async Task<IActionResult> Import(List<CountryImport> imports)
    {
        logger.LogInformation("Country import called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await countryService.Import(imports);
        return Ok(result);
    }

    [HttpGet("Lookup")]
    public async Task<IActionResult> Lookup()
    {
        logger.LogInformation("Country Lookup called");
        var result = await countryService.Lookup();
        return Ok(result);
    }

    [HttpGet("GetAllAudits")]
    public async Task<IActionResult> GetAllAudits()
    {
        logger.LogInformation("Get All Country Audits called");
        //var query = new GetAllCountryCommand(skip, take);
        //var result = await bus.InvokeAsync<RequestResponse>(query);
        var result = await auditService.GetAll();
        return Ok(result);
    }

    [HttpPost("CreateAudit")]
    public async Task<IActionResult> CreateAudit(CountryAuditDTO masterPOST)
    {
        logger.LogInformation("Create Country Audit called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await auditService.Create(masterPOST);
        return Ok(result);
    }

    [HttpDelete("DeleteAudit")]
    public async Task<IActionResult> DeleteAudit(int id)
    {
        logger.LogInformation("Delete Country Audit performed with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new DeleteCountryLocalizationCommand(id));
        var result = await auditService.Delete(id);
        return Ok(result);
    }

    [HttpGet("GetAllLocalizations")]
    public async Task<IActionResult> GetAllCountryLocalizations()
    {
        logger.LogInformation("Get All Country Localizations called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await localizationService.GetAll();
        return Ok(result);
    }

    [HttpPost("CreateLocalization")]
    public async Task<IActionResult> CreateLocalization(CountryLocalizationPOST localizationPOST)
    {
        logger.LogInformation("Create Country Localization called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await localizationService.Create(localizationPOST);
        return Ok(result);
    }

    [HttpDelete("DeleteCountryLocalization")]
    public async Task<IActionResult> DeleteCountryLocalization(int id)
    {
        logger.LogInformation("Delete Country Localization performed with id: {id}", id);
        //var result = await bus.InvokeAsync<RequestResponse>(new DeleteCountryLocalizationCommand(id));
        var result = await localizationService.Delete(id);
        return Ok(result);
    }

    [HttpGet("GetAllCurrencies")]
    public async Task<IActionResult> GetAllCurrencies()
    {
        logger.LogInformation("Get All Country Currency called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await currencyService.GetAll();
        return Ok(result);
    }

    [HttpPost("CreateCurrency")]
    public async Task<IActionResult> CreateCurrency(CountryCurrencyPOST currencyPOST)
    {
        logger.LogInformation("Create Country Currency called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await currencyService.Create(currencyPOST);
        return Ok(result);
    }

    [HttpDelete("DeleteCurrency")]
    public async Task<IActionResult> DeleteCurrency(int id)
    {
        logger.LogInformation("Delete Country Currency called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await currencyService.Delete(id);
        return Ok(result);
    }

    [HttpGet("GetAllExports")]
    public async Task<IActionResult> GetAllExports()
    {
        logger.LogInformation("Get All Country Exports called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await exportService.GetAll();
        return Ok(result);
    }

    [HttpPost("CreateExport")]
    public async Task<IActionResult> CreateExport(CountryExportDTO export)
    {
        logger.LogInformation("Create Country Export called");
        //var result = await bus.InvokeAsync<RequestResponse>(new CreateSingleCountryCommand(masterPOST));
        var result = await exportService.Create(export);
        return Ok(result);
    }

    [HttpDelete("DeleteExport")]
    public async Task<IActionResult> DeleteExport(int id)
    {
        logger.LogInformation("Delete Country Export called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await exportService.Delete(id);
        return Ok(result);
    }

    [HttpGet("GetAllCaptures")]
    public async Task<IActionResult> GetAllCaptures()
    {
        logger.LogInformation("Get All Country Captures called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await captureService.GetAll();
        return Ok(result);
    }

    [HttpPost("CreateCapture")]
    public async Task<IActionResult> CreateCapture(CountryCapturePOST captured)
    {
        logger.LogInformation("Create Country Capture called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await captureService.Create(captured);
        return Ok(result);
    }

    [HttpDelete("DeleteCapture")]
    public async Task<IActionResult> DeleteCapture(int id)
    {
        logger.LogInformation("Delete Country Capture called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await captureService.Delete(id);
        return Ok(result);
    }

    [HttpGet("GetAllActivities")]
    public async Task<IActionResult> GetAllActivities()
    {
        logger.LogInformation("Get All Country Activities called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await activityService.GetAll();
        return Ok(result);
    }

    [HttpPost("CreateActivities")]
    public async Task<IActionResult> CreateActivity(CountryActivityPOST masterPOST)
    {
        logger.LogInformation("Create Country Capture called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await activityService.Create(masterPOST);
        return Ok(result);
    }

    [HttpDelete("DeleteActivity")]
    public async Task<IActionResult> DeleteActivity(int id)
    {
        logger.LogInformation("Delete Country Activity called");
        //var result = await bus.InvokeAsync<RequestResponse>(new GetAllCountryLocalizationsCommand());
        var result = await activityService.Delete(id);
        return Ok(result);
    }

}
