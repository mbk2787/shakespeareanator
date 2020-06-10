namespace Shakespeareanator.Tests
{
    using FluentAssertions;
    using Moq;
    using Shakespeareanator.FunTranslations;
    using Shakespeareanator.FunTranslations.Interfaces;
    using Shakespeareanator.Services;
    using Xunit;

    public class FunTranslationsServicesTests
    {
        #region Constants

        private const string Prefix = "Can Get Translated text";

        #endregion

        [Theory(DisplayName = Prefix)]
        [InlineData("originalText", "translatedText")]
        public void CanGetTranslatedText(string originalText, string translatedText)
        {
            // arrange
            var expectedResult = new FunTranslationsDto() { Contents = new Contents() { Translation = translatedText } };
            var mockedClient = new Mock<IFunTranslationsClient>();
            mockedClient.Setup(p => p.TranslateText(originalText)).ReturnsAsync(expectedResult);
            var funTranslationService = new FunTranslationsService(mockedClient.Object);

            // act
            var result = funTranslationService.TranslateText(originalText);

            // assert
            result.Should().Be(expectedResult);
        }
    }
}
