using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.StateDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController(IState state) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await state.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await state.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits(int skip, int take)
        {
            var result = await state.GetAllAudits(skip, take);
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

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await state.Delete(id);
            return Ok(result);
        }
    }
}
