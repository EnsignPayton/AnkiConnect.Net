using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Internal;

internal class AnkiRequest
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public int Version { get; set; } = 6;
}

internal class AnkiRequest<TParams> : AnkiRequest where TParams : class
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TParams? Params { get; set; }
}
