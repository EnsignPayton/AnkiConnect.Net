using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class GuiCurrentCardResult
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

    [JsonPropertyName("template")]
    public string Template { get; set; } = string.Empty;

    [JsonPropertyName("cardId")]
    public ulong CardId { get; set; }

    [JsonPropertyName("buttons")]
    public IList<int> Buttons { get; set; } = new List<int>();

    [JsonPropertyName("nextReviews")]
    public IList<string> NextReviews { get; set; } = new List<string>();
}
