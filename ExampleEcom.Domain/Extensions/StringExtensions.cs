using System.Text;
using System.Text.RegularExpressions;

namespace ExampleEcom.Domain.Extensions
{
    public static class StringExtensions
    {

        private static readonly Regex _toCamelCaseRegex = new Regex(@"([A-Z])([A-Z]+|[a-z0-9_]+)($|[A-Z]\w*)");

        /// <summary>
        /// Convert string to snake_case. 
        /// See <href>https://stackoverflow.com/a/63055998/6236042</href>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSnakeCase(this string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (text.Length < 2)
            {
                return text;
            }
            var sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(text[0]));
            for (var i = 1; i < text.Length; ++i)
            {
                var c = text[i];
                if (char.IsUpper(c))
                {
                    sb.Append('_');
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string ToCamelCase(this string text)
        {
            return _toCamelCaseRegex.Replace(text, m =>
            {
                return m.Groups[1].Value.ToLower() + m.Groups[2].Value.ToLower() + m.Groups[3].Value;
            });
        }
    }
}
