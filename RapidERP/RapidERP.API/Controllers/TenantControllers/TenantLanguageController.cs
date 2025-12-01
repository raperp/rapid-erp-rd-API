using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.TenantDTOs.TenantCalendarDTOs;
using RapidERP.Application.DTOs.TenantDTOs.TenantLanguageDTOs;
using RapidERP.Application.Interfaces.Tenant;

namespace RapidERP.API.Controllers.TenantControllers;

[Route("api/[controller]")]
[ApiController]
public class TenantLanguageController(ITenantLanguage tenantLanguage) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await tenantLanguage.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await tenantLanguage.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    public async Task<IActionResult> GetHistory(int skip, int take)
    {
        var result = await tenantLanguage.GetHistory(skip, take);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(TenantLanguagePOST masterPOST)
    {
        var result = await tenantLanguage.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<TenantLanguagePOST> masterPOSTs)
    {
        var result = await tenantLanguage.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(TenantLanguagePUT masterPUT)
    {
        var result = await tenantLanguage.Update(masterPUT);
        return Ok(result);
    }
}
