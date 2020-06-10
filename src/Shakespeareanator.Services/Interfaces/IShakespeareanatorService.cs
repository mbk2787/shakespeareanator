namespace Shakespeareanator.Services
{
    using Shakespeareanator.Services.Models;

    public interface IShakespeareanatorService : IService
    {
        ShakespeareanatorResult GetShakespeareanPokemonDescription(string name);
    }
}
