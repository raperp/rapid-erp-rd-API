using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.TenantDTOs;
using RapidERP.Application.Interfaces.Tenant;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController(ITenant tenant) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await tenant.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await tenant.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits(int skip, int take)
        {
            var result = await tenant.GetAllAudits(skip, take);
            return Ok(result);
        }

        //[HttpGet("GetAllColumns")]
        //public async Task<IActionResult> GetAllColumns()
        //{
        //    var result = await tenant.GetAllColumns();
        //    return Ok(result);
        //}

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(TenantPOST masterPOST)
        {
            var result = await tenant.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<TenantPOST> masterPOSTs)
        {
            var result = await tenant.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(TenantPUT masterPUT)
        {
            var result = await tenant.Update(masterPUT);
            return Ok(result);
        }

        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await tenant.Delete(id);
        //    return Ok(result);
        //}
    }
}
