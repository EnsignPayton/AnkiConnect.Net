namespace AnkiConnect.Net.Models;

public class CardInfo
{
    [JsonPropertyName("answer")]
    public string Answer { get; set; } = string.Empty;

    [JsonPropertyName("question")]
    public string Question { get; set; } = string.Empty;

    [JsonPropertyName("deckName")]
    public string DeckName { get; set; } = string.Empty;

    [JsonPropertyName("modelName")]
    public string ModelName { get; set; } = string.Empty;

    [JsonPropertyName("fieldOrder")]
    public int FieldOrder { get; set; }

    [JsonPropertyName("fields")]
    public IDictionary<string, Field> Fields { get; set; } = new Dictionary<string, Field>();

    [JsonPropertyName("css")]
    public string Css { get; set; } = string.Empty;

    [JsonPropertyName("cardId")]
    public ulong CardId { get; set; }

    [JsonPropertyName("interval")]
    public int Interval { get; set; }

    [JsonPropertyName("note")]
    public ulong Note { get; set; }

    [JsonPropertyName("ord")]
    public int Ord { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("queue")]
    public int Queue { get; set; }

    [JsonPropertyName("due")]
    public int Due { get; set; }

    [JsonPropertyName("reps")]
    public int Reps { get; set; }

    [JsonPropertyName("lapses")]
    public int Lapses { get; set; }

    [JsonPropertyName("left")]
    public int Left { get; set; }

    [JsonPropertyName("mod")]
    public ulong Mod { get; set; }
}
