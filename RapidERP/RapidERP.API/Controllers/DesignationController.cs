using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.DesignationDTOs;
using RapidERP.Application.Features.DesignationFeatures.CreateBulkCommand;
using RapidERP.Application.Features.DesignationFeatures.CreateSingleCommand;
using RapidERP.Application.Features.DesignationFeatures.DeleteCommand;
using RapidERP.Application.Features.DesignationFeatures.GetAllQuery;
using RapidERP.Application.Features.DesignationFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.DesignationFeatures.GetHistoryQuery;
using RapidERP.Application.Features.DesignationFeatures.GetSingleQuery;
using RapidERP.Application.Features.DesignationFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.DesignationFeatures.UpdateCommand;
using RapidERP.Domain.Entities.DesignationModels;
using Wolverine;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController(IMessageBus bus, ILogger<DesignationController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllDesignationResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetAllDesignationRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetAllDesignationResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleDesignationResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle([FromQuery] GetSingleDesignationRequestModel request)
        {
            logger.LogInformation("GetSingle called with id: {id}", request.id);
            var result = await bus.InvokeAsync<GetSingleDesignationResponseModel>(new GetSingleDesignationRequestModel(request.id));
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryDesignationResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryDesignationRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetHistoryDesignationResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetTempleteData")]
        [ProducesResponseType(typeof(DesignationTemplate), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTempleteData()
        {
            int id = 0;
            logger.LogInformation("Get Templete Data called");
            var result = await bus.InvokeAsync<GetAllDesignationTemplateDataResponseModel>(new GetAllDesignationTemplateDataRequestModel());
            return Ok(result);

        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(DesignationPOST masterPOST)
        {
            logger.LogInformation("CreateSingle called");
            var result = await bus.InvokeAsync<CreateSingleDesignationCommandResponseModel>(new CreateSingleDesignationCommandRequestModel(masterPOST));
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<DesignationPOST> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called");
            var result = await bus.InvokeAsync<CreateBulkDesignationCommandResponseModel>(new CreateBulkDesignationCommandRequestModel(masterPOSTs));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(DesignationPUT masterPUT)
        {
            logger.LogInformation("Update called");
            var result = await bus.InvokeAsync<UpdateDesignationCommandResponseModel>(new UpdateDesignationCommandRequestModel(masterPUT));
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("Soft Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<SoftDeleteDesignationCommandResponseModel>(new SoftDeleteDesignationCommandRequestModel(id));
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<DeleteDesignationCommandResponseModel>(new DeleteDesignationCommandRequestModel(id));
            return Ok(result);
        }
    }
}
