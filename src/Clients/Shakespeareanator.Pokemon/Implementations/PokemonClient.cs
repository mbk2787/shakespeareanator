namespace Shakespeareanator.Pokemon
{
    using Flurl.Http;
    using Shakespeareanator.Pokemon.Interfaces;
    using System.Threading.Tasks;

    public class PokemonClient : IPokemonClient
    {
        #region Pokemon Species

        public async Task<PokemonSpeciesDto> GetPokemonSpecieByName(string name)
        {
            return await "https://pokeapi.co/api/v2/pokemon-species".GetJsonAsync<PokemonSpeciesDto>();
        }

        public async Task<PokemonSpeciesDto> GetPokemonSpecieById(long id)
        {
            return await "https://pokeapi.co/api/v2/pokemon-species".GetJsonAsync<PokemonSpeciesDto>();
        }

        #endregion
    }
}