using System;
using Microsoft.EntityFrameworkCore;

public class PokemonService : IPokemonService
{
    private string _userId;
    private readonly ApplicationDbContext _context;

    public PokemonService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreatePokemonAsync(PokemonCreate model)
    {
        var pokemonEntity = new Pokemon
        {
            Name = model.Name,
            Hp = model.Hp,
            OwnerId = _userId,
            TypeId = model.TypeId,
            Move1Id = model.Move1Id,
            Move2Id = model.Move2Id,
            Move3Id = model.Move3Id,
            Move4Id = model.Move4Id,
        };
        _context.Pokemon.Add(pokemonEntity);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<PokemonListItem>> GetAllPokemonasync()
    {
        var pokeQuery = await _context.Pokemon
            .Select(n => new PokemonListItem
            {
                Id = n.Id,
                Name = n.Name,
                TypeName = n.Type.Name
            }).ToListAsync();
        return pokeQuery;
    }

    public async Task<bool> UpdatePokemonAsync(PokemonEdit model)
    {
        if (model == null)
        {
            return false;
        }
        var entity = await _context.Pokemon.FindAsync(model.Id);
        if (entity?.OwnerId != _userId)
        {
            return false;
        }
        entity.Name = model.Name;
        entity.Hp = model.Hp;
        entity.TypeId = model.TypeId;
        entity.Move1Id = model.Move1Id;
        entity.Move2Id = model.Move2Id;
        entity.Move3Id = model.Move3Id;
        entity.Move4Id = model.Move4Id;

        //return await _context.SaveChangesAsync() == 1;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePokemonAsync(int pokemonId)
    {
        var entity = await _context.Pokemon.FindAsync(pokemonId);
        if (entity is null)
        {
            return false;
        }
        _context.Pokemon.Remove(entity);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<PokemonDetail> GetPokemonByNameAsync(string pokemonName)
    {
        var pokemonEntity = await _context.Pokemon
            .FirstOrDefaultAsync(n => n.Name.ToLower() == pokemonName.ToLower());
        if (pokemonEntity is null)
        {
            return null;
        }
        var detail = new PokemonDetail
        {
            Id = pokemonEntity.Id,
            Name = pokemonEntity.Name,
            Hp = pokemonEntity.Hp,
            TypeId = pokemonEntity.TypeId,
            TypeName = pokemonEntity.Type.Name,
            Move1Id = pokemonEntity.Move1Id,
            MoveName1 = pokemonEntity.Move1.Name,
            Move2Id = pokemonEntity.Move2Id,
            MoveName2 = pokemonEntity.Move2.Name,
            Move3Id = pokemonEntity.Move3Id,
            MoveName3 = pokemonEntity.Move3.Name,
            Move4Id = pokemonEntity.Move4Id,
            MoveName4 = pokemonEntity.Move4.Name
        };
        return detail;
         
    }

    public async Task<IEnumerable<PokemonListItem>> GetPokemonByTypeAsync(int typeId)
    {
        var pokeQuery = await _context.Pokemon
            .Where(n => n.TypeId == typeId)
            .Select(n => new PokemonListItem
            {
                Id = n.Id,
                Name = n.Name,
                TypeName = n.Type.Name
            }).ToListAsync();
        return pokeQuery;
    }

    public async Task<PokemonDetail> GetPokemonById(int Id)
    {
        var pokemon = await _context.Pokemon
            .Include(x => x.Type)
            .Include(x => x.Move1)
            .Include(x => x.Move2)
            .Include(x => x.Move3)
            .Include(x => x.Move4)
            .FirstOrDefaultAsync(x => x.Id == Id);
        if (pokemon == null)
        {
            return null;
        }

        var detail = new PokemonDetail
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            Hp = pokemon.Hp,
            TypeId = pokemon.TypeId,
            TypeName = pokemon.Type.Name,
            Move1Id = pokemon.Move1Id,
            MoveName1 = pokemon.Move1.Name,
            Move2Id = pokemon.Move2Id,
            MoveName2 = pokemon.Move2.Name,
            Move3Id = pokemon.Move3Id,
            MoveName3 = pokemon.Move3.Name,
            Move4Id = pokemon.Move4Id,
            MoveName4 = pokemon.Move4.Name,
        };
        return detail;
    }

    public void SetUserId(string userId) => _userId = userId;
}

