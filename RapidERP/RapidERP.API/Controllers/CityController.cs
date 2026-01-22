using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CityDTOs;
using RapidERP.Application.Features.CityFeatures.CreateBulkCommand;
using RapidERP.Application.Features.CityFeatures.CreateSingleCommand;
using RapidERP.Application.Features.CityFeatures.DeleteCommand;
using RapidERP.Application.Features.CityFeatures.GetAllQuery;
using RapidERP.Application.Features.CityFeatures.GetAllTemplateDataQuery;
using RapidERP.Application.Features.CityFeatures.GetHistoryQuery;
using RapidERP.Application.Features.CityFeatures.GetSingleQuery;
using RapidERP.Application.Features.CityFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.CityFeatures.UpdateCommand;
using RapidERP.Domain.Entities.CityModels;
using Wolverine;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(IMessageBus bus, ILogger<CityController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllCityResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetAllCityRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetAllCityResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleCityResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle([FromQuery] GetSingleCityRequestModel request)
        {
            logger.LogInformation("GetSingle called with id: {id}", request.id);
            var result = await bus.InvokeAsync<GetSingleCityResponseModel>(new GetSingleCityRequestModel(request.id));
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryCityResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryCityRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetHistoryCityResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetTempleteData")]
        [ProducesResponseType(typeof(CityTemplate), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTempleteData()
        {
            int id = 0;
            logger.LogInformation("Get Templete Data called");
            var result = await bus.InvokeAsync<GetAllCityTemplateDataResponseModel>(new GetAllCityTemplateDataRequestModel());
            return Ok(result);

        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(CityPOST masterPOST)
        {
            logger.LogInformation("CreateSingle called");
            var result = await bus.InvokeAsync<CreateSingleCityCommandResponseModel>(new CreateSingleCityCommandRequestModel(masterPOST));
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<CityPOST> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called");
            var result = await bus.InvokeAsync<CreateBulkCityCommandResponseModel>(new CreateBulkCityCommandRequestModel(masterPOSTs));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CityPUT masterPUT)
        {
            logger.LogInformation("Update called");
            var result = await bus.InvokeAsync<UpdateCityCommandResponseModel>(new UpdateCityCommandRequestModel(masterPUT));
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("Soft Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<SoftDeleteCityCommandResponseModel>(new SoftDeleteCityCommandRequestModel(id));
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<DeleteCityCommandResponseModel>(new DeleteCityCommandRequestModel(id));
            return Ok(result);
        }
    }
}
