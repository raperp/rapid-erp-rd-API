using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.KitchenDTOs;
using RapidERP.Application.Features.KitchenFeatures.CreateBulkCommand;
using RapidERP.Application.Features.KitchenFeatures.CreateSingleCommand;
using RapidERP.Application.Features.KitchenFeatures.DeleteCommand;
using RapidERP.Application.Features.KitchenFeatures.GetAllQuery;
using RapidERP.Application.Features.KitchenFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.KitchenFeatures.GetHistoryQuery;
using RapidERP.Application.Features.KitchenFeatures.GetSingleQuery;
using RapidERP.Application.Features.KitchenFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.KitchenFeatures.UpdateCommand;
using RapidERP.Domain.Entities.KitchenModels;
using Wolverine;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenController(IMessageBus bus, ILogger<KitchenController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetKitchenResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetAllKitchenRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetAllKitchenResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleKitchenResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle([FromQuery] GetSingleKitchenRequestModel request)
        {
            logger.LogInformation("GetSingle called with id: {id}", request.id);
            var result = await bus.InvokeAsync<GetSingleKitchenResponseModel>(new GetSingleKitchenRequestModel(request.id));
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryKitchenResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryKitchenRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetHistoryKitchenResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetTempleteData")]
        [ProducesResponseType(typeof(KitchenTemplate), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTempleteData()
        {
            int id = 0;
            logger.LogInformation("Get Templete Data called");
            var result = await bus.InvokeAsync<GetAllKitchenTemplateDataResponseModel>(new GetAllKitchenTemplateDataRequestModel());
            return Ok(result);

        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(KitchenPOST masterPOST)
        {
            logger.LogInformation("CreateSingle called");
            var result = await bus.InvokeAsync<CreateSingleKitchenCommandResponseModel>(new CreateSingleKitchenCommandRequestModel(masterPOST));
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<KitchenPOST> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called");
            var result = await bus.InvokeAsync<CreateBulkKitchenCommandResponseModel>(new CreateBulkKitchenCommandRequestModel(masterPOSTs));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(KitchenPUT masterPUT)
        {
            logger.LogInformation("Update called");
            var result = await bus.InvokeAsync<UpdateKitchenCommandResponseModel>(new UpdateKitchenCommandRequestModel(masterPUT));
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("Soft Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<SoftDeleteKitchenCommandResponseModel>(new SoftDeleteKitchenCommandRequestModel(id));
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<DeleteKitchenCommandResponseModel>(new DeleteKitchenCommandRequestModel(id));
            return Ok(result);
        }
    }
}
