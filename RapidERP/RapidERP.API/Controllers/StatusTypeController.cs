using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.StatusTypeDTOs;
using RapidERP.Application.Features.StatusTypeFeatures.CreateBulkCommand;
using RapidERP.Application.Features.StatusTypeFeatures.CreateSingleCommand;
using RapidERP.Application.Features.StatusTypeFeatures.DeleteCommand;
using RapidERP.Application.Features.StatusTypeFeatures.GetAllQuery;
using RapidERP.Application.Features.StatusTypeFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.StatusTypeFeatures.GetHistoryQuery;
using RapidERP.Application.Features.StatusTypeFeatures.GetSingleQuery;
using RapidERP.Application.Features.StatusTypeFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.StatusTypeFeatures.UpdateCommand;
using RapidERP.Domain.Entities.StatusTypeModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusTypeController(IMessageBus bus, ILogger<StatusTypeController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetStatusTypeResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}", skip, take);
        var query = new GetAllStatusTypeRequestModel(skip, take);
        var result = await bus.InvokeAsync<GetAllStatusTypeResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleStatusTypeResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleStatusTypeRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleStatusTypeResponseModel>(new GetSingleStatusTypeRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistoryStatusTypeResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}", skip, take);
        var query = new GetHistoryStatusTypeRequestModel(skip, take);
        var result = await bus.InvokeAsync<GetHistoryStatusTypeResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(StatusTypeTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllStatusTypeTemplateDataResponseModel>(new GetAllStatusTypeTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(StatusTypePOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleStatusTypeCommandResponseModel>(new CreateSingleStatusTypeCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<StatusTypePOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkStatusTypeCommandResponseModel>(new CreateBulkStatusTypeCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(StatusTypePUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateStatusTypeCommandResponseModel>(new UpdateStatusTypeCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteStatusTypeCommandResponseModel>(new SoftDeleteStatusTypeCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteStatusTypeCommandResponseModel>(new DeleteStatusTypeCommandRequestModel(id));
        return Ok(result);
    }
}
