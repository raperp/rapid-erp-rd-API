using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.KitchenDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenController(IKitchen kitchen) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await kitchen.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await kitchen.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take)
        {
            var result = await kitchen.GetHistory(skip, take);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(KitchenPOST masterPOST)
        {
            var result = await kitchen.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<KitchenPOST> masterPOSTs)
        {
            var result = await kitchen.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(KitchenPUT masterPUT)
        {
            var result = await kitchen.Update(masterPUT);
            return Ok(result);
        }

        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await kitchen.Delete(id);
        //    return Ok(result);
        //}
    }
}
