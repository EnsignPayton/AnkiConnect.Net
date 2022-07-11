namespace AnkiConnect.Net.Models;

public class DeckParams
{
    [JsonPropertyName("deck")]
    public string Deck { get; set; } = string.Empty;
}
