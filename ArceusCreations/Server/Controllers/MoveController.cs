using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class MoveController : ControllerBase
{
    private readonly IMoveService _moveService;
    public MoveController(IMoveService moveService)
    {
        _moveService = moveService;
    }

    public async Task<IActionResult> Index()
    {
        var moves = await _moveService.GetAllMovesAsync();
        return Ok(moves);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MoveCreate model)
    {
        if (model == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        bool wasSuccessful = await _moveService.CreateMoveAsync(model);
        if (wasSuccessful)
        {
            return Ok();
        }
        return UnprocessableEntity();
    }

    [HttpPut("edit/{id}")]
    public async Task<IActionResult> Edit(int id, MoveEdit model)
    {
        if (model == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        if (model.Id != id)
        {
            return BadRequest();
        }
        bool wassuccessful = await _moveService.UpdateMoveAsync(model);
        if (wassuccessful)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var move = await _moveService.GetMoveById(id);
        if (move == null)
        {
            return NotFound();
        }
        bool wasSuccessful = await _moveService.DeleteMoveAsync(id);
        if (wasSuccessful)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("ByName")]
    public async Task<IActionResult> GetMoveByName(string moveName)
    {
        var move = await _moveService.GetMoveByNameAsync(moveName);
        if (move == null)
        {
            return NotFound();
        }
        return Ok(move);
    }

    [HttpGet("ByType")]
    public async Task<IActionResult> GetMovesBytype(int typeId)
    {
        var moves = await _moveService.GetMovesByTypeAsync(typeId);
        return Ok(moves);
    }

    [HttpGet("ByDamage")]
    public async Task<IActionResult> GetMovesByDamage(SearchMoveByDamage model)
    {
        if (model == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        var moves = await _moveService.GetMovesByDamageAsync(model);
        return Ok(moves);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetMoveById(int Id)
    {
        var move = await _moveService.GetMoveById(Id);
        if (move == null)
        {
            return NotFound();
        }
        return Ok(move);
    }
}
