using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.StateDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController(IStateService state) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
        {
            var result = await state.GetAll(skip, take, pageSize);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await state.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        {
            var result = await state.GetHistory(skip, take, pageSize);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(StatePOST masterPOST)
        {
            var result = await state.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<StatePOST> masterPOSTs)
        {
            var result = await state.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(StatePUT masterPUT)
        {
            var result = await state.Update(masterPUT);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await state.SoftDelete(id);
            return Ok(result);
        }
    }
}
