using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.TextModuleDTOs;
using RapidERP.Application.Features.TextModuleFeatures.CreateBulkCommand;
using RapidERP.Application.Features.TextModuleFeatures.CreateSingleCommand;
using RapidERP.Application.Features.TextModuleFeatures.DeleteCommand;
using RapidERP.Application.Features.TextModuleFeatures.GetAllQuery;
using RapidERP.Application.Features.TextModuleFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.TextModuleFeatures.GetHistoryQuery;
using RapidERP.Application.Features.TextModuleFeatures.GetSingleQuery;
using RapidERP.Application.Features.TextModuleFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.TextModuleFeatures.UpdateCommand;
using RapidERP.Domain.Entities.TextModuleModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TextModuleController(IMessageBus bus, ILogger<TextModuleController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllTextModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllTextModuleRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetAllTextModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleTextModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleTextModuleRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleTextModuleResponseModel>(new GetSingleTextModuleRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistoryTextModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetHistoryTextModuleRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetHistoryTextModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(TextModuleTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllTextModuleTemplateDataResponseModel>(new GetAllTextModuleTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(TextModulePOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleTextModuleCommandResponseModel>(new CreateSingleTextModuleCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<TextModulePOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkTextModuleCommandResponseModel>(new CreateBulkTextModuleCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(TextModulePUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateTextModuleCommandResponseModel>(new UpdateTextModuleCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteTextModuleCommandResponseModel>(new SoftDeleteTextModuleCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteTextModuleCommandResponseModel>(new DeleteTextModuleCommandRequestModel(id));
        return Ok(result);
    }
}
