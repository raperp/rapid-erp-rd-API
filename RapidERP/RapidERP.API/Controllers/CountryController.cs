using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;
using RapidERP.Application.Features.CountryFeatures.CountryTemplate;
using RapidERP.Application.Features.CountryFeatures.CreateBulkCommand;
using RapidERP.Application.Features.CountryFeatures.CreateSingleCommand;
using RapidERP.Application.Features.CountryFeatures.DeleteCommand;
using RapidERP.Application.Features.CountryFeatures.GetAllQuery;
using RapidERP.Application.Features.CountryFeatures.GetHistoryQuery;
using RapidERP.Application.Features.CountryFeatures.GetSingleCountry;
using RapidERP.Application.Features.CountryFeatures.GetSingleQuery;
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
        [ProducesResponseType(typeof(GetAllCountryResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetAllCountryRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetAllCountryResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        [ProducesResponseType(typeof(GetSingleCountryResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle(int id)
        {
            logger.LogInformation("GetSingle called with id: {id}", id);
            var query = new GetSingleCountryRequestModel(id);
            var result = await bus.InvokeAsync<GetSingleCountryResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        [ProducesResponseType(typeof(GetHistoryCountryResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryCountryRequestModel(skip, take, pageSize);
            var result = await bus.InvokeAsync<GetHistoryCountryResponseModel>(query);
            return Ok(result);
        }

        [HttpGet("GetTempleteData")]
        [ProducesResponseType(typeof(CountryTemplateResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTempleteData()
        {
            logger.LogInformation("Get Templete Data called");
            var result = await bus.InvokeAsync<CountryTemplateResponseModel>(new CountryTemplateRequestModel());
            return Ok(result);

        }
        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(CountryPOSTRequestDTO masterPOST)
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
        public async Task<IActionResult> Update(CountryPUTRequestDTO masterPUT)
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