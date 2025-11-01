using Microsoft.AspNetCore.Mvc;
using RapidERP.Application.DTOs.LanguageDTO;
using RapidERP.Application.Interfaces;

namespace RapidERP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageController(ILanguage language) : ControllerBase
{
    [HttpPost("CreateSingle")]
    public async Task<IActionResult> CreateSingle(LanguagePOST languagePOST)
    {
        var result = await language.CreateSingle(languagePOST);
        return Ok(result);
    }
}
