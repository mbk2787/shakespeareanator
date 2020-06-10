namespace Shakespeareanator.Tests
{
    using FluentAssertions;
    using Moq;
    using Shakespeareanator.Pokemon;
    using Shakespeareanator.Pokemon.Interfaces;
    using Shakespeareanator.Services;
    using Xunit;

    public class PokemonServicesTests
    {
        #region Constants

        private const string Prefix = "Can Get Pokemon Specie by ";

        #endregion

        [Theory(DisplayName = Prefix + "name")]
        [InlineData("ditto")]
        [InlineData("charizard")]
        public void CanGetPokemonSpecieByName(string name)
        {
            // arrange
            var expectedResult = new PokemonSpeciesDto() { Name = name };
            var mockedClient = new Mock<IPokemonClient>();
            mockedClient.Setup(p => p.GetPokemonSpecieByName(name)).ReturnsAsync(expectedResult);
            var pokemonService = new PokemonService(mockedClient.Object);

            // act
            var result = pokemonService.GetSpecieByName(name);

            // assert
            result.Should().Be(expectedResult);
        }

        [Theory(DisplayName = Prefix + "id")]
        [InlineData(1)]
        [InlineData(101)]
        public void CanGetPokemonSpecieById(long id)
        {
            var expectedResult = new PokemonSpeciesDto() { Id = id };
            var mockedService = new Mock<IPokemonClient>();
            mockedService.Setup(p => p.GetPokemonSpecieById(id)).ReturnsAsync(expectedResult);
            var pokemonService = new PokemonService(mockedService.Object);

            var result = pokemonService.GetSpecieById(id);

            result.Should().Be(expectedResult);
        }
    }
}
