using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.DepartmentDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentService department) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            var result = await department.GetAll(skip, take, pageSize);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await department.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            var result = await department.GetHistory(skip, take, pageSize);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(DepartmentPOST masterPOST)
        {
            var result = await department.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<DepartmentPOST> masterPOSTs)
        {
            var result = await department.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(DepartmentPUT masterPUT)
        {
            var result = await department.Update(masterPUT);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await department.SoftDelete(id);
            return Ok(result);
        }
    }
}
