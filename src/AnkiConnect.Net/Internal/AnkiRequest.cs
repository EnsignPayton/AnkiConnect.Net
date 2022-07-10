using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Internal;

internal class AnkiRequest
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    [JsonPropertyName("version")]
    public int Version { get; set; } = 6;
}

internal class AnkiRequest<TParams> : AnkiRequest where TParams : class
{
    [JsonPropertyOrder(2)]
    [JsonPropertyName("params")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TParams? Params { get; set; }
}
