namespace Shakespeareanator.Services
{
    using Shakespeareanator.Pokemon;

    public interface IPokemonService : IService
    {
        PokemonSpeciesDto GetSpecieByName(string name);

        PokemonSpeciesDto GetSpecieById(long id);
    }
}
