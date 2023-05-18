using System;
public interface IPokemonService
{
    Task<bool> CreatePokemonAsync(PokemonCreate model);
    Task<IEnumerable<PokemonListItem>> GetAllPokemonasync();
    Task<bool> UpdatePokemonAsync(PokemonEdit model);
    Task<bool> DeletePokemonAsync(int pokemonId);
    Task<PokemonDetail> GetPokemonByNameAsync(string pokemonName);
    Task<IEnumerable<PokemonListItem>> GetPokemonByTypeAsync(int typeId);
    Task<PokemonDetail> GetPokemonById(int id);
    void SetUserId(string userId);
}

