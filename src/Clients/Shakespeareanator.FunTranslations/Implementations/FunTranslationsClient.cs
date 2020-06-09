namespace Shakespeareanator.FunTranslations
{
    using Flurl;
    using Flurl.Http;
    using Shakespeareanator.FunTranslations.Interfaces;
    using System.Threading.Tasks;

    public class FunTranslationsClient : IFunTranslationsClient
    {
        #region Constants

        private const string FUN_TRANSLATIONS_API_URL = "https://api.funtranslations.com/translate";
        private const string SHAKESPEARE_API = "shakespeare.json";

        #endregion

        #region Translate Text

        public async Task<FunTranslationsDto> TranslateText(string text)
        {
            var url = Url.Combine(FUN_TRANSLATIONS_API_URL, SHAKESPEARE_API)
                        .SetQueryParams(new
                        {
                            text
                        });

            return await url.GetJsonAsync<FunTranslationsDto>();
        }

        #endregion
    }
}
