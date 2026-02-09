using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.TenantDTOs.TenantCalendarDTOs;
using RapidERP.Application.Interfaces.Tenant;

namespace RapidERP.API.Controllers.TenantControllers;

[Route("api/[controller]")]
[ApiController]
public class TenantCalendarController(ITenantCalendarService tenantCalendar) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await tenantCalendar.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await tenantCalendar.GetSingle(id);
        return Ok(result);
    }

    //[HttpGet("GetHistory")]
    //public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    //{
    //    var result = await tenantCalendar.GetHistory(skip, take, pageSize);
    //    return Ok(result);
    //}

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(TenantCalendarPOST masterPOST)
    {
        var result = await tenantCalendar.CreateSingle(masterPOST);
        return Ok(result);
    }

    //[HttpPost("CreateBulk")]
    //public async Task<IActionResult> CreateBulk(List<TenantCalendarPOST> masterPOSTs)
    //{
    //    var result = await tenantCalendar.CreateBulk(masterPOSTs);
    //    return Ok(result);
    //}

    [HttpPut("Update")]
    public async Task<IActionResult> Update(TenantCalendarPUT masterPUT)
    {
        var result = await tenantCalendar.Update(masterPUT);
        return Ok(result);
    }
}
