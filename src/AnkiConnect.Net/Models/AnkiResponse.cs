using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

internal class AnkiResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;
}

internal class AnkiResponse<TResult> : AnkiResponse
{
    [JsonPropertyName("result")]
    public TResult? Result { get; set; }
}
