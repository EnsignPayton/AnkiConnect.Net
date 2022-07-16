namespace AnkiConnect.Net.Models;

public class ReplaceTagsInAllNotesParams
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("tag_to_replace")]
    public string TagToReplace { get; set; } = string.Empty;

    [JsonPropertyOrder(0)]
    [JsonPropertyName("replace_with_tag")]
    public string ReplaceWithTag { get; set; } = string.Empty;
}
