namespace AnkiConnect.Net.Models;

public class DecksParams
{
    [JsonPropertyName("decks")]
    public IList<string> Decks { get; set; } = new List<string>();
}
