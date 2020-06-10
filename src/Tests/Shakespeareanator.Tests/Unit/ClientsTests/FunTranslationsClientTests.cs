namespace Shakespeareanator.Tests.ClientsTests
{
    using Flurl.Http.Testing;
    using Shakespeareanator.FunTranslations;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class FunTranslationsClientTests
    {
        #region Constants

        private const string Prefix = "Can Call Fun Translations API";

        #endregion

        [Theory(DisplayName = Prefix)]
        [InlineData("textToTranslate", "translatedText")]
        public async Task CanCallFunTranslationsAPI(string originalText, string translatedText)
        {
            var client = new FunTranslationsClient();

            using (var httpTest = new HttpTest())
            {
                // arrange
                httpTest.RespondWithJson(new { Contents = new { Text = originalText, Translation = translatedText } });

                // act
                await client.TranslateText(originalText);

                // assert
                httpTest.ShouldHaveCalled($"https://api.funtranslations.com/translate/shakespeare.json").WithVerb(HttpMethod.Get).WithQueryParamValue("text", originalText);
            }
        }
    }
}
