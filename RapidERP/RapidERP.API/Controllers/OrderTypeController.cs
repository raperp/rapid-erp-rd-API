using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.OrderTypeDTOs;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTypeController(IOrderTypeService order) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await order.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await order.GetById(id);
            return Ok(result);
        }

        //[HttpGet("GetHistory")]
        //public async Task<IActionResult> GetHistory(int skip, int take, int pageSize)
        //{
        //    var result = await order.GetHistory(skip, take, pageSize);
        //    return Ok(result);
        //}

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(OrderTypePOST masterPOST)
        {
            var result = await order.Create(masterPOST);
            return Ok(result);
        }

        //[HttpPost("CreateBulk")]
        //public async Task<IActionResult> CreateBulk(List<OrderTypePOST> masterPOSTs)
        //{
        //    var result = await order.CreateBulk(masterPOSTs);
        //    return Ok(result);
        //}

        [HttpPut("Update")]
        public async Task<IActionResult> Update(OrderTypePUT masterPUT)
        {
            var result = await order.Update(masterPUT);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await order.Delete(id);
            return Ok(result);
        }
    }
}
