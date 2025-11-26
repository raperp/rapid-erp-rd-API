using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.MenuModuleDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuModuleController(IMenuModule menuModule) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await menuModule.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await menuModule.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetAllAudits")]
    public async Task<IActionResult> GetAllAudits(int skip, int take)
    {
        var result = await menuModule.GetAllAudits(skip, take);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(MenuModulePOST masterPOST)
    {
        var result = await menuModule.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<MenuModulePOST> masterPOSTs)
    {
        var result = await menuModule.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(MenuModulePUT masterPUT)
    {
        var result = await menuModule.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> SoftDelete(DeleteDTO softDelete)
    {
        var result = await menuModule.SoftDelete(softDelete);
        return Ok(result);
    }

    //[HttpDelete("Delete")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var result = await menu.Delete(id);
    //    return Ok(result);
    //}
}
