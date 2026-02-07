using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Features.CountryFeatures.CreateBulkCommand;
using RapidERP.Application.Features.CountryFeatures.CreateSingleCommand;
using RapidERP.Application.Features.CountryFeatures.DeleteCommand;
using RapidERP.Application.Features.CountryFeatures.GetAllQuery;
using RapidERP.Application.Features.CountryFeatures.GetHistoryQuery;
using RapidERP.Application.Features.CountryFeatures.GetSingleCountryQuery;
using RapidERP.Application.Features.CountryFeatures.SoftDeleteCommand;
using RapidERP.Application.Features.CountryFeatures.UpdateCommand;
using Wolverine;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(IMessageBus bus, ILogger<CountryController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(GetAllCountryResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetAllCountryRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetAllCountryResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleCountryResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle([FromQuery] GetSingleCountryRequestModel request)
        {
            logger.LogInformation("GetSingle called with id: {id}", request.id);
            var result = await bus.InvokeAsync<GetSingleCountryResponseModel>(new GetSingleCountryRequestModel(request.id));
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryCountryResponseDTOModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryCountryRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetHistoryCountryResponseModel>(query);
            return Ok(result);
        }
         
        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(CountryPOST masterPOST)
        {
            logger.LogInformation("CreateSingle called");
            var result = await bus.InvokeAsync<CreateSingleCountryCommandResponseModel>(new CreateSingleCountryCommandRequestModel(masterPOST));
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<CreateSingleCountryCommandRequestModel> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called");
            var result = await bus.InvokeAsync<CreateBulkCountryCommandResponseModel>(new CreateBulkCountryCommandRequestModel(masterPOSTs));
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CountryPUT masterPUT)
        {
            logger.LogInformation("Update called");
            var result = await bus.InvokeAsync<UpdateCountryCommandResponseModel>(new UpdateCountryCommandRequestModel(masterPUT));
            return Ok(result);
        }

        [HttpPut("SoftDelete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("Soft Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<SoftDeleteCountryCommandResponseModel>(new SoftDeleteCountryCommandRequestModel(id));
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete action performed with id: {id}", id);
            var result = await bus.InvokeAsync<DeleteCountryCommandResponseModel>(new DeleteCountryCommandRequestModel(id));
            return Ok(result);
        }
    }
}