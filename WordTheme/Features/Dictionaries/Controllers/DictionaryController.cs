using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WordTheme.Features.Dictionaries.Data;
using WordTheme.Features.Dictionaries.DTOs;
using WordTheme.Features.Dictionaries.Models;
using WordTheme.Features.Dictionaries.Services;

namespace WordTheme.Features.Dictionaries.Controllers;

[ApiController, Route("api/v1/dictionary")]
public class DictionaryController(DictionaryContext context, DictionaryService service) : ControllerBase
{
    [HttpGet("list")]
    public async Task<ActionResult<List<DictionaryListDto>>> List()
    {
        var dictionaries = await service.GetAllDictionariesAsync();
        return Ok(dictionaries);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Dictionary>> Create(DictionaryCreateDto dictionary)
    {
        var response = await service.CreateDictionaryAsync(dictionary);
        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpPatch("update/<id:int>")]
    public async Task<ActionResult<DictionaryMinimalDto>> Update(int id, DictionaryUpdateDto dictionary)
    {
        var result = await service.UpdateDictionaryAsync(id, dictionary);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpDelete("delete/<id:int>")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await service.DeleteDictionaryAsync(id);
        return result ? NoContent() : NotFound();
    }
}