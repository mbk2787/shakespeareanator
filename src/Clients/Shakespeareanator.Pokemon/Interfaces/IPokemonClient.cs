namespace Shakespeareanator.Pokemon.Interfaces
{
    using System.Threading.Tasks;

    public interface IPokemonClient
    {
        Task<PokemonSpeciesDto> GetPokemonSpecieByName(string name);
        Task<PokemonSpeciesDto> GetPokemonSpecieById(long id);
    }
}
