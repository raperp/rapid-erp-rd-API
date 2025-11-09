using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.ActionTypeDTOs;
using RapidERP.Application.DTOs.StatusTypeDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTypeController(IStatusType statusType) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await statusType.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await statusType.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits(int skip, int take)
        {
            var result = await statusType.GetAllAudits(skip, take);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(StatusTypePOST masterPOST)
        {
            var result = await statusType.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<StatusTypePOST> masterPOSTs)
        {
            var result = await statusType.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(StatusTypePUT masterPUT)
        {
            var result = await statusType.Update(masterPUT);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await statusType.Delete(id);
            return Ok(result);
        }
    }
}
