using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.ExportTypeDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportTypeController(IExportType exportType) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int skip, int take)
        {
            var result = await exportType.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var result = await exportType.GetSingle(id);
            return Ok(result);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits(int skip, int take)
        {
            var result = await exportType.GetAllAudits(skip, take);
            return Ok(result);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle(ExportTypePOST masterPOST)
        {
            var result = await exportType.CreateSingle(masterPOST);
            return Ok(result);
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(List<ExportTypePOST> masterPOSTs)
        {
            var result = await exportType.CreateBulk(masterPOSTs);
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await exportType.SoftDelete(id);
            return Ok(result);
        }

        //[HttpDelete("Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await exportType.Delete(id);
        //    return Ok(result);
        //}
    }
}
