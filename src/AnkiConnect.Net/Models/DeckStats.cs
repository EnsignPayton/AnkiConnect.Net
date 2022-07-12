namespace AnkiConnect.Net.Models;

public class DeckStats
{
    [JsonPropertyName("deck_id")]
    public ulong DeckId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("new_count")]
    public int NewCount { get; set; }

    [JsonPropertyName("learn_count")]
    public int LearnCount { get; set; }

    [JsonPropertyName("review_count")]
    public int ReviewCount { get; set; }

    [JsonPropertyName("total_in_deck")]
    public int TotalInDeck { get; set; }
}
