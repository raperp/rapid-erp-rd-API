using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.SolutionDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SolutionController(ISolutionService solution) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        var result = await solution.GetAll(skip, take, pageSize);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await solution.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        var result = await solution.GetHistory(skip, take, pageSize);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(SolutionPOST masterPOST)
    {
        var result = await solution.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<SolutionPOST> masterPOSTs)
    {
        var result = await solution.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(SolutionPUT masterPUT)
    {
        var result = await solution.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var result = await solution.SoftDelete(id);
        return Ok(result);
    }
}
