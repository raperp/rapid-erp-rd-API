using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.ExportTypeDTOs;
using RapidERP.Application.Features.ExportTypeFeatures.CreateBulkCommand;
using RapidERP.Application.Features.ExportTypeFeatures.CreateSingleCommand;
using RapidERP.Application.Features.ExportTypeFeatures.DeleteCommand;
using RapidERP.Application.Features.ExportTypeFeatures.GetAllQuery;
using RapidERP.Application.Features.ExportTypeFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.ExportTypeFeatures.GetHistoryQuery;
using RapidERP.Application.Features.ExportTypeFeatures.GetSingleQuery;
using RapidERP.Application.Features.ExportTypeFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.ExportTypeFeatures.UpdateCommand;
using RapidERP.Domain.Entities.ExportTypeModels;
using Wolverine;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportTypeController(IMessageBus bus, ILogger<ExportTypeController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllExportTypeResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}", skip, take);
            var query = new GetAllExportTypeRequestModel(skip, take);
            var result = await bus.InvokeAsync<GetAllExportTypeResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleExportTypeResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle([FromQuery] GetSingleExportTypeRequestModel request)
        {
            logger.LogInformation("GetSingle called with id: {id}", request.id);
            var result = await bus.InvokeAsync<GetSingleExportTypeResponseModel>(new GetSingleExportTypeRequestModel(request.id));
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryExportTypeResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}", skip, take);
            var query = new GetHistoryExportTypeRequestModel(skip, take);
            var result = await bus.InvokeAsync<GetHistoryExportTypeResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetTempleteData")]
        [ProducesResponseType(typeof(ExportTypeTemplate), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTempleteData()
        {
            int id = 0;
            logger.LogInformation("Get Templete Data called");
            var result = await bus.InvokeAsync<GetAllExportTypeTemplateDataResponseModel>(new GetAllExportTypeTemplateDataRequestModel());
            return Ok(result);

        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(ExportTypePOST masterPOST)
        {
            logger.LogInformation("CreateSingle called");
            var result = await bus.InvokeAsync<CreateSingleExportTypeCommandResponseModel>(new CreateSingleExportTypeCommandRequestModel(masterPOST));
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<ExportTypePOST> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called");
            var result = await bus.InvokeAsync<CreateBulkExportTypeCommandResponseModel>(new CreateBulkExportTypeCommandRequestModel(masterPOSTs));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ExportTypePUT masterPUT)
        {
            logger.LogInformation("Update called");
            var result = await bus.InvokeAsync<UpdateExportTypeCommandResponseModel>(new UpdateExportTypeCommandRequestModel(masterPUT));
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("Soft Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<SoftDeleteExportTypeCommandResponseModel>(new SoftDeleteExportTypeCommandRequestModel(id));
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<DeleteExportTypeCommandResponseModel>(new DeleteExportTypeCommandRequestModel(id));
            return Ok(result);
        }
    }
}
