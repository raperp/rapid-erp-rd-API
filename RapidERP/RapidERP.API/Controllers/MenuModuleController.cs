using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.MenuModuleDTOs;
using RapidERP.Application.Features.MenuModuleFeatures.CreateBulkCommand;
using RapidERP.Application.Features.MenuModuleFeatures.CreateSingleCommand;
using RapidERP.Application.Features.MenuModuleFeatures.DeleteCommand;
using RapidERP.Application.Features.MenuModuleFeatures.GetAllQuery;
using RapidERP.Application.Features.MenuModuleFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.MenuModuleFeatures.GetHistoryQuery;
using RapidERP.Application.Features.MenuModuleFeatures.GetSingleQuery;
using RapidERP.Application.Features.MenuModuleFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.MenuModuleFeatures.UpdateCommand;
using RapidERP.Domain.Entities.MenuModuleModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuModuleController(IMessageBus bus, ILogger<MenuModuleController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllMenuModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllMenuModuleRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetAllMenuModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleMenuModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleMenuModuleRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleMenuModuleResponseModel>(new GetSingleMenuModuleRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistoryMenuModuleResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetHistoryMenuModuleRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetHistoryMenuModuleResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(MenuModuleTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllMenuModuleTemplateDataResponseModel>(new GetAllMenuModuleTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(MenuModulePOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleMenuModuleCommandResponseModel>(new CreateSingleMenuModuleCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<MenuModulePOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkMenuModuleCommandResponseModel>(new CreateBulkMenuModuleCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(MenuModulePUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateMenuModuleCommandResponseModel>(new UpdateMenuModuleCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteMenuModuleCommandResponseModel>(new SoftDeleteMenuModuleCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteMenuModuleCommandResponseModel>(new DeleteMenuModuleCommandRequestModel(id));
        return Ok(result);
    }
}
