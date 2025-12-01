using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.TenantDTOs.TenantLicenseDTOs;
using RapidERP.Application.Interfaces.Tenant;

namespace RapidERP.API.Controllers.TenantControllers;

[Route("api/[controller]")]
[ApiController]
public class TenantLicenseController(ITenantLicense tenantLicense) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await tenantLicense.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await tenantLicense.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    public async Task<IActionResult> GetHistory(int skip, int take)
    {
        var result = await tenantLicense.GetHistory(skip, take);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(TenantLicensePOST masterPOST)
    {
        var result = await tenantLicense.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<TenantLicensePOST> masterPOSTs)
    {
        var result = await tenantLicense.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(TenantLicensePUT masterPUT)
    {
        var result = await tenantLicense.Update(masterPUT);
        return Ok(result);
    }
}
