namespace AnkiConnect.Net.Models;

public class NoteTagsParams
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("notes")]
    public IList<ulong> Notes { get; set; } = new List<ulong>();

    [JsonPropertyOrder(1)]
    [JsonPropertyName("tags")]
    public string Tags { get; set; } = string.Empty;
}
