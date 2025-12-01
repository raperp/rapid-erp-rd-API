using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.ActionTypeDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActionTypeController(IActionType actionType) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(int skip, int take)
    {
        var result = await actionType.GetAll(skip, take);
        return Ok(result);
    }

    [HttpGet("GetSingle")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var result = await actionType.GetSingle(id);
        return Ok(result);
    }

    [HttpGet("GetHistory")]
    public async Task<IActionResult> GetHistory(int skip, int take)
    {
        var result = await actionType.GetHistory(skip, take);
        return Ok(result);
    }

    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(ActionTypePOST masterPOST)
    {
        var result = await actionType.CreateSingle(masterPOST);
        return Ok(result);
    }

    [HttpPost("CreateBulk")]
    public async Task<IActionResult> CreateBulk(List<ActionTypePOST> masterPOSTs)
    {
        var result = await actionType.CreateBulk(masterPOSTs);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(ActionTypePUT masterPUT)
    {
        var result = await actionType.Update(masterPUT);
        return Ok(result);
    }

    //[HttpPut("Delete")]
    //public async Task<IActionResult> SoftDelete(DeleteDTO softDelete)
    //{
    //    var result = await actionType.SoftDelete(softDelete);
    //    return Ok(result);
    //}

    //[HttpDelete("Delete")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var result = await actionType.Delete(id);
    //    return Ok(result);
    //}
}
