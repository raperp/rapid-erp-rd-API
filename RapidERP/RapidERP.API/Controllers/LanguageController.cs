using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.LanguageDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.ExportTypeModels;
using System.Reflection.Metadata;

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

    [HttpGet("GetAllAudits")]
    public async Task<IActionResult> GetAllAudits(int skip, int take)
    {
        var result = await language.GetAllAudits(skip, take);
        return Ok(result);
    }

    [HttpGet("GetAllExports")]
    public async Task<IActionResult> GetAllExports(int skip, int take)
    {
        var result = await language.GetAllExports(skip, take);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(LanguagePOST masterPOST)
    {
        var result = await language.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateExport")]
    public async Task<IActionResult> CreateExport(LanguageExportDTO export)
    {
        var result = await language.CreateExport(export);
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

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await language.Delete(id);
        return Ok(result);
    }
}
