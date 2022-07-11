using AnkiConnect.Net.Models;

namespace AnkiConnect.Net.Internal;

internal class DeleteDecksParams : DecksParams
{
    public DeleteDecksParams(DecksParams inner)
    {
        Decks = inner.Decks;
    }

    [JsonPropertyOrder(1)]
    [JsonPropertyName("cardsToo")]
    public bool CardsToo { get; set; } = true;
}
