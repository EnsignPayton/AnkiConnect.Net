using System.Text.Json;

namespace AnkiConnect.Net;

public static class StringExtensions
{
    public static string AsJson(this string value)
    {
        using var doc = JsonDocument.Parse(value);
        return JsonSerializer.Serialize(doc);
    }
}
