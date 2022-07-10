using System.Text.RegularExpressions;

namespace AnkiConnect.Net;

public static class StringExtensions
{
    public static string NoWhitespace(this string value) =>
        Regex.Replace(value, @"\s+", string.Empty);
}
