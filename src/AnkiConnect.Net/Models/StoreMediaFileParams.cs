namespace AnkiConnect.Net.Models;

public class StoreMediaFileParams
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("filename")]
    public string FileName { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    [JsonPropertyName("data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Data { get; set; }

    [JsonPropertyOrder(2)]
    [JsonPropertyName("path")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Path { get; set; }

    [JsonPropertyOrder(3)]
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    // TODO: JsonIgnore when it's true. Custom converter required?
    [JsonPropertyOrder(4)]
    [JsonPropertyName("deleteExisting")]
    public bool DeleteExisting { get; set; } = true;
}
