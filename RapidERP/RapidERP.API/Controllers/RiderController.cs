using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.RiderDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiderController(IRiderService rider) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await rider.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await rider.GetSingle(id);
            return Ok(result);
        }

        //[HttpGet("GetHistory")]
        //public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        //{
        //    var result = await rider.GetHistory(skip, take, pageSize);
        //    return Ok(result);
        //}

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(RiderPOST masterPOST)
        {
            var result = await rider.CreateSingle(masterPOST);
            return Ok(result);
        }

        //[HttpPost("CreateBulk")]
        //public async Task<IActionResult> CreateBulk(List<RiderPOST> masterPOSTs)
        //{
        //    var result = await rider.CreateBulk(masterPOSTs);
        //    return Ok(result);
        //}

        [HttpPut("Update")]
        public async Task<IActionResult> Update(RiderPUT masterPUT)
        {
            var result = await rider.Update(masterPUT);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await rider.Delete(id);
            return Ok(result);
        }
    }
}
