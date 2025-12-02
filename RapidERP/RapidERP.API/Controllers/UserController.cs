using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.UserDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.UserIPWhitelistModels;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUser user) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await user.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await user.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetHistory(int skip, int take)
        {
            var result = await user.GetHistory(skip, take);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(UserPOST masterPOST)
        {
            var result = await user.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<UserPOST> masterPOSTs)
        {
            var result = await user.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserPUT masterPUT)
        {
            var result = await user.Update(masterPUT);
            return Ok(result);
        }
        
        [HttpPut("Delete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await user.SoftDelete(id);
            return Ok(result);
        }

        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await user.Delete(id);
        //    return Ok(result);
        //}
    }
}
