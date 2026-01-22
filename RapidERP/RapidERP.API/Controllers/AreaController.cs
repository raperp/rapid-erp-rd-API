using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.AreaDTOs;
using RapidERP.Application.Features.AreaFeatures.CreateBulkCommand;
using RapidERP.Application.Features.AreaFeatures.CreateSingleCommand;
using RapidERP.Application.Features.AreaFeatures.DeleteCommand;
using RapidERP.Application.Features.AreaFeatures.GetAllQuery;
using RapidERP.Application.Features.AreaFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.AreaFeatures.GetHistoryQuery;
using RapidERP.Application.Features.AreaFeatures.GetSingleQuery;
using RapidERP.Application.Features.AreaFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.AreaFeatures.UpdateCommand;
using RapidERP.Domain.Entities.AreaModules;
using Wolverine;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController(IMessageBus bus, ILogger<AreaController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllAreaResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetAllAreaRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetAllAreaResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleAreaResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle([FromQuery] GetSingleAreaRequestModel request)
        {
            logger.LogInformation("GetSingle called with id: {id}", request.id);
            var result = await bus.InvokeAsync<GetSingleAreaResponseModel>(new GetSingleAreaRequestModel(request.id));
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryAreaResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryAreaRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetHistoryAreaResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetTempleteData")]
        [ProducesResponseType(typeof(AreaTemplate), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTempleteData()
        {
            int id = 0;
            logger.LogInformation("Get Templete Data called");
            var result = await bus.InvokeAsync<GetAllAreaTemplateDataResponseModel>(new GetAllAreaTemplateDataRequestModel());
            return Ok(result);

        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(AreaPOST masterPOST)
        {
            logger.LogInformation("CreateSingle called");
            var result = await bus.InvokeAsync<CreateSingleAreaCommandResponseModel>(new CreateSingleAreaCommandRequestModel(masterPOST));
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<AreaPOST> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called");
            var result = await bus.InvokeAsync<CreateBulkAreaCommandResponseModel>(new CreateBulkAreaCommandRequestModel(masterPOSTs));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AreaPUT masterPUT)
        {
            logger.LogInformation("Update called");
            var result = await bus.InvokeAsync<UpdateAreaCommandResponseModel>(new UpdateAreaCommandRequestModel(masterPUT));
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("Soft Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<SoftDeleteAreaCommandResponseModel>(new SoftDeleteAreaCommandRequestModel(id));
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<DeleteAreaCommandResponseModel>(new DeleteAreaCommandRequestModel(id));
            return Ok(result);
        }
    }
}
