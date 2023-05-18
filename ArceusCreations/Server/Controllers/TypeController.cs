using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TypeController : ControllerBase
{
    private readonly ITypeService _typeService;
    public TypeController(ITypeService typeService)
    {
        _typeService = typeService;
    }

    public async Task<IActionResult> Index()
    {
        var types = await _typeService.GetAllTypesAsync();
        return Ok(types);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TypeCreate model)
    {
        if (model == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        bool wasSuccessful = await _typeService.CreateTypeAsync(model);

        if (wasSuccessful)
        {
            return Ok();
        }
        return UnprocessableEntity();
    }

    [HttpPut("edit/{id}")]
    public async Task<IActionResult> Update(int id, TypeEdit model)
    {
        if (model == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        if (model.Id != id)
        {
            return BadRequest();
        }
        bool wasSuccessful = await _typeService.UpdateTypeAsync(model);

        if (wasSuccessful)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var type = await _typeService.GetTypeById(id);
        if (type == null)
        {
            return NotFound();
        }
        bool wasSuccessful = await _typeService.DeleteTypeAsync(id);
        if (!wasSuccessful)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Type(int id)
    {
        var type = await _typeService.GetTypeById(id);

        if (type == null)
        {
            return NotFound();
        }
        return Ok(type);
    }
}

