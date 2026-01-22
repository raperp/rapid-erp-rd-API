using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.SolutionDTOs;
using RapidERP.Application.Features.SolutionFeatures.CreateBulkCommand;
using RapidERP.Application.Features.SolutionFeatures.CreateSingleCommand;
using RapidERP.Application.Features.SolutionFeatures.DeleteCommand;
using RapidERP.Application.Features.SolutionFeatures.GetAllQuery;
using RapidERP.Application.Features.SolutionFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.SolutionFeatures.GetHistoryQuery;
using RapidERP.Application.Features.SolutionFeatures.GetSingleQuery;
using RapidERP.Application.Features.SolutionFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.SolutionFeatures.UpdateCommand;
using RapidERP.Domain.Entities.SolutionModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SolutionController(IMessageBus bus, ILogger<SolutionController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllSolutionResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllSolutionRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetAllSolutionResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleSolutionResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleSolutionRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleSolutionResponseModel>(new GetSingleSolutionRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistorySolutionResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetHistorySolutionRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetHistorySolutionResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(SolutionTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllSolutionTemplateDataResponseModel>(new GetAllSolutionTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(SolutionPOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleSolutionCommandResponseModel>(new CreateSingleSolutionCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<SolutionPOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkSolutionCommandResponseModel>(new CreateBulkSolutionCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(SolutionPUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateSolutionCommandResponseModel>(new UpdateSolutionCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteSolutionCommandResponseModel>(new SoftDeleteSolutionCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteSolutionCommandResponseModel>(new DeleteSolutionCommandRequestModel(id));
        return Ok(result);
    }
}
