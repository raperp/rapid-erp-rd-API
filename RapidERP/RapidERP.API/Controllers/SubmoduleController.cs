using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.SubmoduleDTOs;
using RapidERP.Application.Features.SubModuleFeatures.CreateBulkCommand;
using RapidERP.Application.Features.SubModuleFeatures.CreateSingleCommand;
using RapidERP.Application.Features.SubModuleFeatures.DeleteCommand;
using RapidERP.Application.Features.SubModuleFeatures.GetAllQuery;
using RapidERP.Application.Features.SubModuleFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.SubModuleFeatures.GetHistoryQuery;
using RapidERP.Application.Features.SubModuleFeatures.GetSingleQuery;
using RapidERP.Application.Features.SubModuleFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.SubModuleFeatures.UpdateCommand;
using RapidERP.Domain.Entities.SubmoduleModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubmoduleController(IMessageBus bus, ILogger<SubmoduleController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllSubModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllSubModuleRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetAllSubModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleSubModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleSubModuleRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleSubModuleResponseModel>(new GetSingleSubModuleRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistorySubModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}", skip, take);
        var query = new GetHistorySubModuleRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetHistorySubModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(SubmoduleTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllSubModuleTemplateDataResponseModel>(new GetAllSubModuleTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(SubmodulePOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleSubModuleCommandResponseModel>(new CreateSingleSubModuleCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<SubmodulePOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkSubModuleCommandResponseModel>(new CreateBulkSubModuleCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(SubmodulePUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateSubModuleCommandResponseModel>(new UpdateSubModuleCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteSubModuleCommandResponseModel>(new SoftDeleteSubModuleCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteSubModuleCommandResponseModel>(new DeleteSubModuleCommandRequestModel(id));
        return Ok(result);
    }
}
