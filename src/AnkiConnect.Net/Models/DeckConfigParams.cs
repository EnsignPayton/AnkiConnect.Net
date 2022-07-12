namespace AnkiConnect.Net.Models;

public class DeckConfigParams
{
    [JsonPropertyName("config")]
    public DeckConfig Config { get; set; } = new();
}
