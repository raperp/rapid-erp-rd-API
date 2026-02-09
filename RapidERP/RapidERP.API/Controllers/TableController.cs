using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.TableDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController(ITableService table) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await table.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await table.GetSingle(id);
            return Ok(result);
        }

        //[HttpGet("GetHistory")]
        //public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        //{
        //    var result = await table.GetHistory(skip, take, pageSize);
        //    return Ok(result);
        //}

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(TablePOST masterPOST)
        {
            var result = await table.CreateSingle(masterPOST);
            return Ok(result);
        }

        //[HttpPost("CreateBulk")]
        //public async Task<IActionResult> CreateBulk(List<TablePOST> masterPOSTs)
        //{
        //    var result = await table.CreateBulk(masterPOSTs);
        //    return Ok(result);
        //}

        [HttpPut("Update")]
        public async Task<IActionResult> Update(TablePUT masterPUT)
        {
            var result = await table.Update(masterPUT);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await table.Delete(id);
            return Ok(result);
        }
    }
}
