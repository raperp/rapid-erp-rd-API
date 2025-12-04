using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.LanguageDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageController(ILanguage language) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await language.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await language.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    public async Task<IActionResult> GetHistory(int skip, int take)
    {
        var result = await language.GetHistory(skip, take);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(LanguagePOST masterPOST)
    {
        var result = await language.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<LanguagePOST> masterPOSTs)
    {
        var result = await language.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(LanguagePUT masterPUT)
    {
        var result = await language.Update(masterPUT);
        return Ok(result);
    }

    //[HttpPut("Delete")]
    //public async Task<IActionResult> SoftDelete(int id)
    //{
    //    var result = await language.SoftDelete(id);
    //    return Ok(result);
    //}

    //[HttpDelete("Delete")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var result = await language.Delete(id);
    //    return Ok(result);
    //}
}
