namespace AnkiConnect.Net.Models;

public class ReplaceTagsParams
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("notes")]
    public IList<ulong> Notes { get; set; } = new List<ulong>();

    [JsonPropertyOrder(1)]
    [JsonPropertyName("tag_to_replace")]
    public string TagToReplace { get; set; } = string.Empty;

    [JsonPropertyOrder(2)]
    [JsonPropertyName("replace_with_tag")]
    public string ReplaceWithTag { get; set; } = string.Empty;
}
