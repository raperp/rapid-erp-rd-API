using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CurrencyDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrencyController(ICurrency currency) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await currency.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await currency.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    public async Task<IActionResult> GetHistory(int skip, int take)
    {
        var result = await currency.GetHistory(skip, take);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(CurrencyPOST masterPOST)
    {
        var result = await currency.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<CurrencyPOST> masterPOSTs)
    {
        var result = await currency.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CurrencyPUT masterPUT)
    {
        var result = await currency.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var result = await currency.SoftDelete(id);
        return Ok(result);
    }

    //[HttpDelete("Delete")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var result = await currency.Delete(id);
    //    return Ok(result);
    //}
}
