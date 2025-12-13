using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CityDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(ICityService city) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            var result = await city.GetAll(skip, take, pageSize);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await city.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            var result = await city.GetHistory(skip, take, pageSize);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(CityPOST masterPOST)
        {
            var result = await city.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<CityPOST> masterPOSTs)
        {
            var result = await city.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CityPUT masterPUT)
        {
            var result = await city.Update(masterPUT);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await city.SoftDelete(id);
            return Ok(result);
        }
    }
}
