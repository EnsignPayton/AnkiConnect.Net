namespace AnkiConnect.Net.Models;

public class DeckParams
{
    public DeckParams()
    {
    }

    public DeckParams(string deck)
    {
        Deck = deck;
    }

    public static implicit operator DeckParams(string deck) => new(deck);

    [JsonPropertyName("deck")]
    public string Deck { get; set; } = string.Empty;
}
