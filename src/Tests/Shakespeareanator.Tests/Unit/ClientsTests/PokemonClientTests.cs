namespace Shakespeareanator.Tests.ClientsTests
{
    using Flurl.Http.Testing;
    using Shakespeareanator.Pokemon;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class PokemonClientTests
    {
        #region Constants

        private const string Prefix = "Can Call Pokemon API specie by ";

        #endregion

        [Theory(DisplayName = Prefix + "name")]
        [InlineData("ditto")]
        [InlineData("charizard")]
        public async Task CanCallPokemonAPISpecieByName(string name)
        {
            var client = new PokemonClient();

            using (var httpTest = new HttpTest())
            {
                // arrange
                httpTest.RespondWithJson(new { Name = name });

                // act
                await client.GetPokemonSpecieByName(name);

                // assert
                httpTest.ShouldHaveCalled($"https://pokeapi.co/api/v2/pokemon-species/{name}").WithVerb(HttpMethod.Get);
            }
        }

        [Theory(DisplayName = Prefix + "id")]
        [InlineData(1)]
        [InlineData(101)]
        public async Task CanCallPokemonAPISpecieById(long id)
        {
            var client = new PokemonClient();

            using (var httpTest = new HttpTest())
            {
                // arrange
                httpTest.RespondWithJson(new { Id = id });

                // act
                await client.GetPokemonSpecieById(id);

                // assert
                httpTest.ShouldHaveCalled($"https://pokeapi.co/api/v2/pokemon-species/{id}").WithVerb(HttpMethod.Get);
            }
        }
    }
}
