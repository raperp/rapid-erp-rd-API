using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.ActionTypeDTOs;
using RapidERP.Application.Features.ActionTypeFeatures.CreateBulkCommand;
using RapidERP.Application.Features.ActionTypeFeatures.CreateSingleCommand;
using RapidERP.Application.Features.ActionTypeFeatures.DeleteCommand;
using RapidERP.Application.Features.ActionTypeFeatures.GetAllQuery;
using RapidERP.Application.Features.ActionTypeFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.ActionTypeFeatures.GetHistoryQuery;
using RapidERP.Application.Features.ActionTypeFeatures.GetSingleQuery;
using RapidERP.Application.Features.ActionTypeFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.ActionTypeFeatures.UpdateCommand;
using RapidERP.Domain.Entities.ActionTypeModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActionTypeController(IMessageBus bus, ILogger<ActionTypeController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllActionTypeResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}", skip, take);
        var query = new GetAllActionTypeRequestModel(skip, take);
        var result = await bus.InvokeAsync<GetAllActionTypeResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleActionTypeResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleActionTypeRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleActionTypeResponseModel>(new GetSingleActionTypeRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistoryActionTypeResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}", skip, take);
        var query = new GetHistoryActionTypeRequestModel(skip, take);
        var result = await bus.InvokeAsync<GetHistoryActionTypeResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(ActionTypeTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllActionTypeTemplateDataResponseModel>(new GetAllActionTypeTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(ActionTypePOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleActionTypeCommandResponseModel>(new CreateSingleActionTypeCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<ActionTypePOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkActionTypeCommandResponseModel>(new CreateBulkActionTypeCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(ActionTypePUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateActionTypeCommandResponseModel>(new UpdateActionTypeCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteActionTypeCommandResponseModel>(new SoftDeleteActionTypeCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteActionTypeCommandResponseModel>(new DeleteActionTypeCommandRequestModel(id));
        return Ok(result);
    }
}
