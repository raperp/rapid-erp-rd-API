using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.UserIPWhitelistDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserIPWhitelistController(IUserIPWhitelistService userIPWhitelist) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await userIPWhitelist.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await userIPWhitelist.GetById(id);
        return Ok(result);
    }

    //[HttpGet("GetHistory")]
    //public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    //{
    //    var result = await userIPWhitelist.GetHistory(skip, take, pageSize);
    //    return Ok(result);
    //}

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(UserIPWhitelistPOST masterPOST)
    {
        var result = await userIPWhitelist.Create(masterPOST);
        return Ok(result);
    }

    //[HttpPost("CreateBulk")]
    //public async Task<IActionResult> CreateBulk(List<UserIPWhitelistPOST> masterPOSTs)
    //{
    //    var result = await userIPWhitelist.CreateBulk(masterPOSTs);
    //    return Ok(result);
    //}

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UserIPWhitelistPUT masterPUT)
    {
        var result = await userIPWhitelist.Update(masterPUT);
        return Ok(result);
    }

    //[HttpPut("Delete")]
    //public async Task<IActionResult> SoftDelete(int id)
    //{
    //    var result = await userIPWhitelist.UpdateStatus(id);
    //    return Ok(result);
    //}
}
