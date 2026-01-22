using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CurrencyDTOs;
using RapidERP.Application.Features.CurrencyFeatures.CreateBulkCommand;
using RapidERP.Application.Features.CurrencyFeatures.CreateSingleCommand;
using RapidERP.Application.Features.CurrencyFeatures.DeleteCommand;
using RapidERP.Application.Features.CurrencyFeatures.GetAllQuery;
using RapidERP.Application.Features.CurrencyFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.CurrencyFeatures.GetHistoryQuery;
using RapidERP.Application.Features.CurrencyFeatures.GetSingleQuery;
using RapidERP.Application.Features.CurrencyFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.CurrencyFeatures.UpdateCommand;
using RapidERP.Domain.Entities.CurrencyModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrencyController(IMessageBus bus, ILogger<CurrencyController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllCurrencyResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllCurrencyRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetAllCurrencyResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleCurrencyResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleCurrencyRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleCurrencyResponseModel>(new GetSingleCurrencyRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistoryCurrencyResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetHistoryCurrencyRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetHistoryCurrencyResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(CurrencyTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllCurrencyTemplateDataResponseModel>(new GetAllCurrencyTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(CurrencyPOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleCurrencyCommandResponseModel>(new CreateSingleCurrencyCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<CurrencyPOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkCurrencyCommandResponseModel>(new CreateBulkCurrencyCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CurrencyPUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateCurrencyCommandResponseModel>(new UpdateCurrencyCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteCurrencyCommandResponseModel>(new SoftDeleteCurrencyCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteCurrencyCommandResponseModel>(new DeleteCurrencyCommandRequestModel(id));
        return Ok(result);
    }
}
