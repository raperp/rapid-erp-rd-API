using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.StateDTOs;
using RapidERP.Application.Features.StateFeatures.CreateBulkCommand;
using RapidERP.Application.Features.StateFeatures.CreateSingleCommand;
using RapidERP.Application.Features.StateFeatures.DeleteCommand;
using RapidERP.Application.Features.StateFeatures.GetAllQuery;
using RapidERP.Application.Features.StateFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.StateFeatures.GetHistoryQuery;
using RapidERP.Application.Features.StateFeatures.GetSingleQuery;
using RapidERP.Application.Features.StateFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.StateFeatures.UpdateCommand;
using RapidERP.Domain.Entities.SateModules;
using Wolverine;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController(IMessageBus bus, ILogger<StateController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllStateResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetAllStateRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetAllStateResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleStateResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle([FromQuery] GetSingleStateRequestModel request)
        {
            logger.LogInformation("GetSingle called with id: {id}", request.id);
            var result = await bus.InvokeAsync<GetSingleStateResponseModel>(new GetSingleStateRequestModel(request.id));
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryStateResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryStateRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetHistoryStateResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetTempleteData")]
        [ProducesResponseType(typeof(StateTemplate), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTempleteData()
        {
            int id = 0;
            logger.LogInformation("Get Templete Data called");
            var result = await bus.InvokeAsync<GetAllStateTemplateDataResponseModel>(new GetAllStateTemplateDataRequestModel());
            return Ok(result);

        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(StatePOST masterPOST)
        {
            logger.LogInformation("CreateSingle called");
            var result = await bus.InvokeAsync<CreateSingleStateCommandResponseModel>(new CreateSingleStateCommandRequestModel(masterPOST));
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<StatePOST> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called");
            var result = await bus.InvokeAsync<CreateBulkStateCommandResponseModel>(new CreateBulkStateCommandRequestModel(masterPOSTs));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(StatePUT masterPUT)
        {
            logger.LogInformation("Update called");
            var result = await bus.InvokeAsync<UpdateStateCommandResponseModel>(new UpdateStateCommandRequestModel(masterPUT));
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("Soft Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<SoftDeleteStateCommandResponseModel>(new SoftDeleteStateCommandRequestModel(id));
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<DeleteStateCommandResponseModel>(new DeleteStateCommandRequestModel(id));
            return Ok(result);
        }
    }
}
