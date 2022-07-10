using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class ChangeDeckParams : CardsParams
{
    [JsonPropertyOrder(1)]
    [JsonPropertyName("deck")]
    public string Deck { get; set; } = string.Empty;
}
