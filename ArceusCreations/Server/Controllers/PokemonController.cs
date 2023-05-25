using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class PokemonController : Controller
{
    private readonly IPokemonService _pokemonService;
    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    } 

    private string GetUserId()
    {
        string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        if (userIdClaim == null)
        {
            return null;
        }
        return userIdClaim;
    }

    private bool SetUserIdInService()
    {
        var userId = GetUserId();
        if (userId == null)
        {
            return false;
        }
        _pokemonService.SetUserId(userId);
        return true;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var pokemon = await _pokemonService.GetAllPokemonasync();
        return Ok(pokemon);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PokemonCreate model)
    {
        if (model == null)
        {
            return BadRequest();
        }
        if (!SetUserIdInService())
        {
            return Unauthorized();
        }
        bool wasSuccessful = await _pokemonService.CreatePokemonAsync(model);
        if (wasSuccessful)
        {
            return Ok();
        }
        return UnprocessableEntity();
    }

    [HttpPut("edit/{Id}")]
    public async Task<IActionResult> Edit(int Id, PokemonEdit model)
    {
        if (!SetUserIdInService())
        {
            return Unauthorized();
        }
        if (model == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        if (model.Id != Id)
        {
            return BadRequest();
        }
        bool wasSuccessful = await _pokemonService.UpdatePokemonAsync(model);
        if (wasSuccessful)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pokemon = await _pokemonService.GetPokemonById(id);
        if (pokemon == null)
        {
            return NotFound();
        }
        bool wasSuccessful = await _pokemonService.DeletePokemonAsync(id);
        if (wasSuccessful)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("ByName")]
    public async Task<IActionResult> GetPokemonbyName(string pokemonName)
    {
        var pokemon = await _pokemonService.GetPokemonByNameAsync(pokemonName);
        if (pokemonName == null)
        {
            return NotFound();
        }
        return Ok(pokemon);
    }

    [HttpGet("ByType")]
    public async Task<IActionResult> GetPokemonbyType(int pokemonType)
    {
        var pokemon = await _pokemonService.GetPokemonByTypeAsync(pokemonType);
        return Ok(pokemon);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetPokemonById(int Id)
    {
        var pokemon = await _pokemonService.GetPokemonById(Id);
        if (pokemon == null)
        {
            return NotFound();
        }
        return Ok(pokemon);
    }
}

