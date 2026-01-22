using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.MessageModuleDTOs;
using RapidERP.Application.Features.MessageModuleFeatures.CreateBulkCommand;
using RapidERP.Application.Features.MessageModuleFeatures.CreateSingleCommand;
using RapidERP.Application.Features.MessageModuleFeatures.DeleteCommand;
using RapidERP.Application.Features.MessageModuleFeatures.GetAllQuery;
using RapidERP.Application.Features.MessageModuleFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.MessageModuleFeatures.GetHistoryQuery;
using RapidERP.Application.Features.MessageModuleFeatures.GetSingleQuery;
using RapidERP.Application.Features.MessageModuleFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.MessageModuleFeatures.UpdateCommand;
using RapidERP.Domain.Entities.MessageModuleModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController(IMessageBus bus, ILogger<MessageController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllMessageModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllMessageModuleRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetAllMessageModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleMessageModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleMessageModuleRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleMessageModuleResponseModel>(new GetSingleMessageModuleRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistoryMessageModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}", skip, take);
        var query = new GetHistoryMessageModuleRequestModel(skip, take);
        var result = await bus.InvokeAsync<GetHistoryMessageModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(MessageModuleTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllMessageModuleTemplateDataResponseModel>(new GetAllMessageModuleTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(MessageModulePOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleMessageModuleCommandResponseModel>(new CreateSingleMessageModuleCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<MessageModulePOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkMessageModuleCommandResponseModel>(new CreateBulkMessageModuleCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(MessageModulePUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateMessageModuleCommandResponseModel>(new UpdateMessageModuleCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteMessageModuleCommandResponseModel>(new SoftDeleteMessageModuleCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteMessageModuleCommandResponseModel>(new DeleteMessageModuleCommandRequestModel(id));
        return Ok(result);
    }
}
