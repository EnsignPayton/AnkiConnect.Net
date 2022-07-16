namespace AnkiConnect.Net.Models;

public class NoteInfo
{
    [JsonPropertyName("noteId")]
    public ulong NoteId { get; set; }

    [JsonPropertyName("modelName")]
    public string ModelName { get; set; } = string.Empty;

    [JsonPropertyName("tags")]
    public IList<string> Tags { get; set; } = new List<string>();

    [JsonPropertyName("fields")]
    public IDictionary<string, Field> Fields { get; set; } = new Dictionary<string, Field>();
}
