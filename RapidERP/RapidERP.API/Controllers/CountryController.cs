using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CountryDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(ICountry country) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await country.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await country.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits(int skip, int take)
        {
            var result = await country.GetAllAudits(skip, take);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(CountryPOST masterPOST)
        {
            var result = await country.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<CountryPOST> masterPOSTs)
        {
            var result = await country.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CountryPUT masterPUT)
        {
            var result = await country.Update(masterPUT);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await country.Delete(id);
            return Ok(result);
        }
    }
}
