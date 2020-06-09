namespace Shakespeareanator.Pokemon
{
    using Flurl;
    using Flurl.Http;
    using Shakespeareanator.Pokemon.Interfaces;
    using System.Threading.Tasks;

    public class PokemonClient : IPokemonClient
    {
        #region Constants

        private const string POKE_API_URL = "https://pokeapi.co/api/v2";
        private const string POKE_API_SPECIES = "pokemon-species";

        #endregion

        #region Pokemon Species

        public async Task<PokemonSpeciesDto> GetPokemonSpecieByName(string name)
        {
            return await Url.Combine(POKE_API_URL, POKE_API_SPECIES, name).GetJsonAsync<PokemonSpeciesDto>();
        }

        public async Task<PokemonSpeciesDto> GetPokemonSpecieById(long id)
        {
            return await Url.Combine(POKE_API_URL, POKE_API_SPECIES, id.ToString()).GetJsonAsync<PokemonSpeciesDto>();
        }

        #endregion
    }
}