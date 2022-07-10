using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class CreateDeckParams
{
    [JsonPropertyName("deck")]
    public string Deck { get; set; } = string.Empty;
}
