namespace AnkiConnect.Net.Models;

public class DecksParams
{
    public DecksParams()
    {
    }

    public DecksParams(IList<string> decks)
    {
        Decks = decks;
    }

    public DecksParams(params string[] decks)
    {
        Decks = decks;
    }

    [JsonPropertyName("decks")]
    public IList<string> Decks { get; set; } = new List<string>();
}
