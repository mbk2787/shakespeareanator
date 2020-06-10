namespace Shakespeareanator.Services
{
    using Shakespeareanator.FunTranslations;
    using Shakespeareanator.FunTranslations.Interfaces;

    public class FunTranslationsService : IFunTranslationsService
    {
        #region Constructor(s)

        public FunTranslationsService(IFunTranslationsClient funTranslationsClient)
        {
            this.funTranslationsClient = funTranslationsClient;
        }

        #endregion

        #region Fields

        private readonly IFunTranslationsClient funTranslationsClient;

        #endregion

        public FunTranslationsDto TranslateText(string text)
        {
            return funTranslationsClient.TranslateText(text).Result;
        }
    }
}
