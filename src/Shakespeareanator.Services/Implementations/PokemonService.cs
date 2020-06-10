namespace Shakespeareanator.Services
{
    using Shakespeareanator.Pokemon;
    using Shakespeareanator.Pokemon.Interfaces;

    public class PokemonService : IPokemonService
    {
        #region Constructor(s)

        public PokemonService(IPokemonClient pokemonClient)
        {
            this.pokemonClient = pokemonClient;
        }

        #endregion

        #region Fields

        private readonly IPokemonClient pokemonClient;

        #endregion

        public PokemonSpeciesDto GetSpecieByName(string name)
        {
          return pokemonClient.GetPokemonSpecieByName(name).Result;
        }

        public PokemonSpeciesDto GetSpecieById(long id)
        {
            return pokemonClient.GetPokemonSpecieById(id).Result;
        }
    }
}
