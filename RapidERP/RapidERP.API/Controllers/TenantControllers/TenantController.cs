using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.TenantDTOs.TenantDTOs;
using RapidERP.Application.Features.TenantFeatures.CreateBulkCommand;
using RapidERP.Application.Features.TenantFeatures.CreateSingleCommand;
using RapidERP.Application.Features.TenantFeatures.DeleteCommand;
using RapidERP.Application.Features.TenantFeatures.GetAllQuery;
using RapidERP.Application.Features.TenantFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.TenantFeatures.GetHistoryQuery;
using RapidERP.Application.Features.TenantFeatures.GetSingleQuery;
using RapidERP.Application.Features.TenantFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.TenantFeatures.UpdateCommand;
using RapidERP.Domain.Entities.TenantModels;
using Wolverine;

namespace RapidERP.API.Controllers.TenantControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController(IMessageBus bus, ILogger<TenantController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllTenantResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("Getting all tenants with skip: {Skip}, take: {Take}, pageSize: {PageSize}", skip, take, pageSize);
            var query = new GetAllTenantRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetAllTenantResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleTenantResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle(int id)
        {
            logger.LogInformation("GetSingle called with id: {id}", id);
            var result = await bus.InvokeAsync<GetSingleTenantResponseModel>(new GetSingleTenantRequestModel(id));
            return Ok(result); 
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryTenantResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryTenantRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetHistoryTenantResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetTempleteData")]
        [ProducesResponseType(typeof(TenantTemplate), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTempleteData()
        {
            int id = 0;
            logger.LogInformation("Get Templete Data called");
            var result = await bus.InvokeAsync<GetAllTenantTemplateDataResponseModel>(new GetAllTenantTemplateDataRequestModel());
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(TenantPOST masterPOST)
        {
            logger.LogInformation("CreateSingle called");
            var result = await bus.InvokeAsync<CreateSingleTenantCommandResponseModel>(new CreateSingleTenantCommandRequestModel(masterPOST));
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<TenantPOST> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called");
            var result = await bus.InvokeAsync<CreateBulkTenantCommandResponseModel>(new CreateBulkTenantCommandRequestModel(masterPOSTs));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(TenantPUT masterPUT)
        {
            logger.LogInformation("Update called");
            var result = await bus.InvokeAsync<UpdateTenantCommandResponseModel>(new UpdateTenantCommandRequestModel(masterPUT));
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("Soft Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<SoftDeleteTenantCommandResponseModel>(new SoftDeleteTenantCommandRequestModel(id));
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<DeleteTenantCommandResponseModel>(new DeleteTenantCommandRequestModel(id));
            return Ok(result);
        }
    }
}
