using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.LanguageDTOs;
using RapidERP.Application.Features.LanguageFeatures.CreateBulkCommand;
using RapidERP.Application.Features.LanguageFeatures.CreateSingleCommand;
using RapidERP.Application.Features.LanguageFeatures.DeleteCommand;
using RapidERP.Application.Features.LanguageFeatures.GetAllQuery;
using RapidERP.Application.Features.LanguageFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.LanguageFeatures.GetHistoryQuery;
using RapidERP.Application.Features.LanguageFeatures.GetSingleLanguageQuery;
using RapidERP.Application.Features.LanguageFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.LanguageFeatures.UpdateCommand;
using RapidERP.Domain.Entities.LanguageModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageController(IMessageBus bus, ILogger<LanguageController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllLanguageResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}", skip, take);
        var query = new GetAllLanguageRequestModel(skip, take);
        var result = await bus.InvokeAsync<GetAllLanguageResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetLanguageResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleLanguageRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleLanguageResponseModel>(new GetSingleLanguageRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistoryLanguageResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}", skip, take);
        var query = new GetHistoryLanguageRequestModel(skip, take);
        var result = await bus.InvokeAsync<GetHistoryLanguageResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(LanguageTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllLanguageTemplateDataResponseModel>(new GetAllLanguageTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(LanguagePOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleLanguageCommandResponseModel>(new CreateSingleLanguageCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<LanguagePOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkLanguageCommandResponseModel>(new CreateBulkLanguageCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(LanguagePUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateLanguageCommandResponseModel>(new UpdateLanguageCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteLanguageCommandResponseModel>(new SoftDeleteLanguageCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteLanguageCommandResponseModel>(new DeleteLanguageCommandRequestModel(id));
        return Ok(result);
    }
}
