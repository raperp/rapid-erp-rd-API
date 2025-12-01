using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.SalesmanDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesmanController(ISalesman salesman) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await salesman.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await salesman.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take)
        {
            var result = await salesman.GetHistory(skip, take);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(SalesmanPOST masterPOST)
        {
            var result = await salesman.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<SalesmanPOST> masterPOSTs)
        {
            var result = await salesman.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(SalesmanPUT masterPUT)
        {
            var result = await salesman.Update(masterPUT);
            return Ok(result);
        }

        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await salesman.Delete(id);
        //    return Ok(result);
        //}
    }
}
