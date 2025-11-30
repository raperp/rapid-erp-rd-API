using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.MainModuleDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MainModuleController(IMainModule mainModule) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await mainModule.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await mainModule.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetAllAudits")]
    public async Task<IActionResult> GetAllAudits(int skip, int take)
    {
        var result = await mainModule.GetAllAudits(skip, take);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(MainModulePOST masterPOST)
    {
        var result = await mainModule.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<MainModulePOST> masterPOSTs)
    {
        var result = await mainModule.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(MainModulePUT masterPUT)
    {
        var result = await mainModule.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var result = await mainModule.SoftDelete(id);
        return Ok(result);
    }

    //[HttpDelete("Delete")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var result = await mainModule.Delete(id);
    //    return Ok(result);
    //}
}
