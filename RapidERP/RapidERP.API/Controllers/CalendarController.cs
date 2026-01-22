using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CalendarDTOs;
using RapidERP.Application.Features.CalendarFeatures.CreateBulkCommand;
using RapidERP.Application.Features.CalendarFeatures.CreateSingleCommand;
using RapidERP.Application.Features.CalendarFeatures.DeleteCommand;
using RapidERP.Application.Features.CalendarFeatures.GetAllQuery;
using RapidERP.Application.Features.CalendarFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.CalendarFeatures.GetHistoryQuery;
using RapidERP.Application.Features.CalendarFeatures.GetSingleQuery;
using RapidERP.Application.Features.CalendarFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.CalendarFeatures.UpdateCommand;
using RapidERP.Domain.Entities.CalendarModels;
using Wolverine;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalendarController(IMessageBus bus, ILogger<CalendarController> logger) : ControllerBase
{
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(GetAllCalendarResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetAllCalendarRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetAllCalendarResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    [ProducesResponseType(typeof(GetSingleCalendarResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSingle([FromQuery] GetSingleCalendarRequestModel request)
    {
        logger.LogInformation("GetSingle called with id: {id}", request.id);
        var result = await bus.InvokeAsync<GetSingleCalendarResponseModel>(new GetSingleCalendarRequestModel(request.id));
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    [ProducesResponseType(typeof(GetHistoryCalendarResponseDTOModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
        var query = new GetHistoryCalendarRequestModel(skip, take, pageSize);
        var result = await bus.InvokeAsync<GetHistoryCalendarResponseModel>(query);
        return Ok(result);
    }

    [HttpGet("GetTempleteData")]
    [ProducesResponseType(typeof(CalendarTemplate), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTempleteData()
    {
        int id = 0;
        logger.LogInformation("Get Templete Data called");
        var result = await bus.InvokeAsync<GetAllCalendarTemplateDataResponseModel>(new GetAllCalendarTemplateDataRequestModel());
        return Ok(result);

    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(CalendarPOST masterPOST)
    {
        logger.LogInformation("CreateSingle called");
        var result = await bus.InvokeAsync<CreateSingleCalendarCommandResponseModel>(new CreateSingleCalendarCommandRequestModel(masterPOST));
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<CalendarPOST> masterPOSTs)
    {
        logger.LogInformation("CreateBulk called");
        var result = await bus.InvokeAsync<CreateBulkCalendarCommandResponseModel>(new CreateBulkCalendarCommandRequestModel(masterPOSTs));
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CalendarPUT masterPUT)
    {
        logger.LogInformation("Update called");
        var result = await bus.InvokeAsync<UpdateCalendarCommandResponseModel>(new UpdateCalendarCommandRequestModel(masterPUT));
        return Ok(result);
    }

    [HttpPut("SoftDelete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        logger.LogInformation("Soft Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<SoftDeleteCalendarCommandResponseModel>(new SoftDeleteCalendarCommandRequestModel(id));
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        logger.LogInformation("Delete action performed with id: {id}", id);
        var result = await bus.InvokeAsync<DeleteCalendarCommandResponseModel>(new DeleteCalendarCommandRequestModel(id));
        return Ok(result);
    }
}
