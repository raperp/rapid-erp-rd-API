using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(ICountryService country) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            var result = await country.GetAll(skip, take, pageSize);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await country.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            var result = await country.GetHistory(skip, take, pageSize);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(CountryPOSTRequestDTO masterPOST)
        {
            var result = await country.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<CountryPOSTRequestDTO> masterPOSTs)
        {
            var result = await country.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CountryPUTRequestDTO masterPUT)
        {
            var result = await country.Update(masterPUT);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await country.SoftDelete(id);
            return Ok(result);
        }

        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await country.Delete(id);
        //    return Ok(result);
        //}
    }
}