using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.CQRS.Command.CountryCommands.CreateBulkCommand;
using RapidERP.Application.CQRS.Command.CountryCommands.CreateSingleCommand;
using RapidERP.Application.CQRS.Command.CountryCommands.SoftDeleteCommand;
using RapidERP.Application.CQRS.Command.CountryCommands.UpdateCommand;
using RapidERP.Application.CQRS.Query.CountryQueries.GetAllQuery;
using RapidERP.Application.CQRS.Query.CountryQueries.GetHistoryQuery;
using RapidERP.Application.CQRS.Query.CountryQueries.GetSingleQuery;
using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;
using RapidERP.Domain.Utilities;
using Wolverine;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(IMessageBus bus, ILogger<CountryController> logger) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetAll called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetAllQuery(skip, take, pageSize);
            var result = await bus.InvokeAsync<RequestResponse>(query);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            logger.LogInformation("GetSingle called with id: {id}", id);
            var query = new GetSingleQuery(id);
            var result = await bus.InvokeAsync<RequestResponse>(query);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            logger.LogInformation("GetHistory called with skip: {skip}, take: {take}, pageSize: {pageSize}", skip, take, pageSize);
            var query = new GetHistoryQuery(skip, take, pageSize);
            var result = await bus.InvokeAsync<RequestResponse>(query);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(CountryPOSTRequestDTO masterPOST)
        {
            logger.LogInformation("CreateSingle called with CountryPOSTRequestDTO: {@masterPOST}", masterPOST);
            var command = new CreateSingleCommand(masterPOST);
            var result = await bus.InvokeAsync<RequestResponse>(command);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<CountryPOSTRequestDTO> masterPOSTs)
        {
            logger.LogInformation("CreateBulk called with {count} CountryPOSTRequestDTO items", masterPOSTs.Count);
            var command = new CreateBulkCommand(masterPOSTs);
            var result = await bus.InvokeAsync<RequestResponse>(command);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CountryPUTRequestDTO masterPUT)
        {
            logger.LogInformation("Update called with CountryPUTRequestDTO: {@masterPUT}", masterPUT);
            var command = new UpdateCommand(masterPUT);
            var result = await bus.InvokeAsync<RequestResponse>(command);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            logger.LogInformation("SoftDelete called with id: {id}", id);
            var command = new SoftDeleteCommand(id);
            var result = await bus.InvokeAsync<RequestResponse>(command);
            return Ok(result);
        }
    }
}