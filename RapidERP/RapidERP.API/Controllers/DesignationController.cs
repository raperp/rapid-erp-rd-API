using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.DesignationDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController(IDesignationService designation) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            var result = await designation.GetAll(skip, take, pageSize);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await designation.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            var result = await designation.GetHistory(skip, take, pageSize);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(DesignationPOST masterPOST)
        {
            var result = await designation.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<DesignationPOST> masterPOSTs)
        {
            var result = await designation.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(DesignationPUT masterPUT)
        {
            var result = await designation.Update(masterPUT);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await designation.SoftDelete(id);
            return Ok(result);
        }
    }
}
