using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.DepartmentDTOs;
using RapidERP.Application.Features.DepartmentFeatures.CreateBulkCommand;
using RapidERP.Application.Features.DepartmentFeatures.CreateSingleCommand;
using RapidERP.Application.Features.DepartmentFeatures.DeleteCommand;
using RapidERP.Application.Features.DepartmentFeatures.GetAllQuery;
using RapidERP.Application.Features.DepartmentFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.DepartmentFeatures.GetHistoryQuery;
using RapidERP.Application.Features.DepartmentFeatures.GetSingleQuery;
using RapidERP.Application.Features.DepartmentFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.DepartmentFeatures.UpdateCommand;
using RapidERP.Domain.Entities.DepartmentModels;
using Wolverine;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IMessageBus bus, ILogger<DepartmentController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllDepartmentResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetAllDepartmentRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetAllDepartmentResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleDepartmentResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle([FromQuery] GetSingleDepartmentRequestModel request)
        {
            logger.LogInformation("GetSingle called with id: {id}", request.id);
            var result = await bus.InvokeAsync<GetSingleDepartmentResponseModel>(new GetSingleDepartmentRequestModel(request.id));
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryDepartmentResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryDepartmentRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetHistoryDepartmentResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetTempleteData")]
        [ProducesResponseType(typeof(DepartmentTemplate), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTempleteData()
        {
            int id = 0;
            logger.LogInformation("Get Templete Data called");
            var result = await bus.InvokeAsync<GetAllDepartmentTemplateDataResponseModel>(new GetAllDepartmentTemplateDataRequestModel());
            return Ok(result);

        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(DepartmentPOST masterPOST)
        {
            logger.LogInformation("CreateSingle called");
            var result = await bus.InvokeAsync<CreateSingleDepartmentCommandResponseModel>(new CreateSingleDepartmentCommandRequestModel(masterPOST));
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<DepartmentPOST> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called");
            var result = await bus.InvokeAsync<CreateBulkDepartmentCommandResponseModel>(new CreateBulkDepartmentCommandRequestModel(masterPOSTs));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(DepartmentPUT masterPUT)
        {
            logger.LogInformation("Update called");
            var result = await bus.InvokeAsync<UpdateDepartmentCommandResponseModel>(new UpdateDepartmentCommandRequestModel(masterPUT));
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("Soft Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<SoftDeleteDepartmentCommandResponseModel>(new SoftDeleteDepartmentCommandRequestModel(id));
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<DeleteDepartmentCommandResponseModel>(new DeleteDepartmentCommandRequestModel(id));
            return Ok(result);
        }
    }
}
