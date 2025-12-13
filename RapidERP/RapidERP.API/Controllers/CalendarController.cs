using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.CalendarDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalendarController(ICalendarService calendar) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take, int pageSize)
    {
        var result = await calendar.GetAll(skip, take, pageSize);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await calendar.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
    {
        var result = await calendar.GetHistory(skip, take, pageSize);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(CalendarPOST masterPOST)
    {
        var result = await calendar.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<CalendarPOST> masterPOSTs)
    {
        var result = await calendar.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CalendarPUT masterPUT)
    {
        var result = await calendar.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var result = await calendar.SoftDelete(id);
        return Ok(result);
    }
}
