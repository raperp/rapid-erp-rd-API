using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.MessageModuleDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController(IMessageModule message) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await message.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await message.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetAllAudits")]
    public async Task<IActionResult> GetAllAudits(int skip, int take)
    {
        var result = await message.GetAllAudits(skip, take);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(MessageModulePOST masterPOST)
    {
        var result = await message.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<MessageModulePOST> masterPOSTs)
    {
        var result = await message.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(MessageModulePUT masterPUT)
    {
        var result = await message.Update(masterPUT);
        return Ok(result);
    }

    [HttpPut("Delete")]
    public async Task<IActionResult> SoftDelete(DeleteDTO softDelete)
    {
        var result = await message.SoftDelete(softDelete);
        return Ok(result);
    }
}
