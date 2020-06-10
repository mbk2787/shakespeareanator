namespace Shakespeareanator.Services
{
    using Shakespeareanator.FunTranslations;

    public interface IFunTranslationsService : IService
    {
        FunTranslationsDto TranslateText(string text);
    }
}
