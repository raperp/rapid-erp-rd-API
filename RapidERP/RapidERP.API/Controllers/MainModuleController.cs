using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.MainModuleDTOs;
using RapidERP.Application.Features.MainModuleFeatures.CreateBulkCommand;
using RapidERP.Application.Features.MainModuleFeatures.CreateSingleCommand;
using RapidERP.Application.Features.MainModuleFeatures.DeleteCommand;
using RapidERP.Application.Features.MainModuleFeatures.GetAllQuery;
using RapidERP.Application.Features.MainModuleFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.MainModuleFeatures.GetHistoryQuery;
using RapidERP.Application.Features.MainModuleFeatures.GetSingleQuery;
using RapidERP.Application.Features.MainModuleFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.MainModuleFeatures.UpdateCommand;
using RapidERP.Domain.Entities.MainModuleModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MainModuleController(IMessageBus bus, ILogger<MainModuleController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllMainModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllMainModuleRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetAllMainModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleMainModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleMainModuleRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleMainModuleResponseModel>(new GetSingleMainModuleRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistoryMainModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetHistoryMainModuleRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetHistoryMainModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(MainModuleTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllMainModuleTemplateDataResponseModel>(new GetAllMainModuleTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(MainModulePOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleMainModuleCommandResponseModel>(new CreateSingleMainModuleCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<MainModulePOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkMainModuleCommandResponseModel>(new CreateBulkMainModuleCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(MainModulePUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateMainModuleCommandResponseModel>(new UpdateMainModuleCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteMainModuleCommandResponseModel>(new SoftDeleteMainModuleCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteMainModuleCommandResponseModel>(new DeleteMainModuleCommandRequestModel(id));
        return Ok(result);
    }
}
