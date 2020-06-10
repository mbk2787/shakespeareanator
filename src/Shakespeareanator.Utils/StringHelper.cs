namespace Shakespeareanator.Utils
{
    using System.Text.RegularExpressions;

    public static class StringHelper
    {
        public static string EscapeString(string stringToEscape)
        {
            return Regex.Replace(stringToEscape, @"\f|\n|\r", " ");
        }
    }
}
