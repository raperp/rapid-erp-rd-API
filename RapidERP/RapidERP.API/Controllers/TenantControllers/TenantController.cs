using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.TenantDTOs.TenantDTOs;
using RapidERP.Application.Interfaces.Tenant;

namespace RapidERP.API.Controllers.TenantControllers
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

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take)
        {
            var result = await tenant.GetHistory(skip, take);
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

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await tenant.SoftDelete(id);
            return Ok(result);
        }
    }
}
