namespace Shakespeareanator.FunTranslations.Interfaces
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IFunTranslationsClient
    {
        Task<FunTranslationsDto> TranslateText(string text);
    }
}
