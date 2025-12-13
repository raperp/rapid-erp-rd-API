using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.TextModuleDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TextModuleController(ITextModuleService textModule) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        var result = await textModule.GetAll(skip, take, pageSize);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await textModule.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        var result = await textModule.GetHistory(skip, take, pageSize);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(TextModulePOST masterPOST)
    {
        var result = await textModule.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<TextModulePOST> masterPOSTs)
    {
        var result = await textModule.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(TextModulePUT masterPUT)
    {
        var result = await textModule.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var result = await textModule.SoftDelete(id);
        return Ok(result);
    }
}
