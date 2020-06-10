namespace Shakespeareanator.Services.Implementations
{
    using Shakespeareanator.Services.Models;
    using Shakespeareanator.Utils;
    using System.Linq;

    public class ShakespeareanatorService : IShakespeareanatorService
    {
        private readonly IPokemonService pokemonService;
        private readonly IFunTranslationsService funTranslationsService;

        public ShakespeareanatorService(IPokemonService pokemonService, IFunTranslationsService funTranslationsService)
        {
            this.pokemonService = pokemonService;
            this.funTranslationsService = funTranslationsService;
        }

        public ShakespeareanatorResult GetShakespeareanPokemonDescription(string name)
        {
            // Get pokemon specie information
            var specie = pokemonService.GetSpecieByName(name);

            // Pick an english description of the pokemon
            var flavorTextEntry = specie.FlavorTextEntries.Where(i => i.Language.Name == "en").FirstOrDefault();

            // Translate text
            var translation = funTranslationsService.TranslateText(StringHelper.EscapeString(flavorTextEntry?.FlavorText)).Contents.Translated;

            return new ShakespeareanatorResult() { Description = translation, Name = name };
        }
    }
}
