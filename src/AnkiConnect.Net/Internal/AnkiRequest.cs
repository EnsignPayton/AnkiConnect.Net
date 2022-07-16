namespace AnkiConnect.Net.Internal;

internal class AnkiRequest
{
    public AnkiRequest(string action)
    {
        Action = action;
    }

    [JsonPropertyOrder(0)]
    [JsonPropertyName("action")]
    public string Action { get; set; }

    [JsonPropertyOrder(1)]
    [JsonPropertyName("version")]
    public int Version { get; set; } = 6;
}

internal class AnkiRequest<TParams> : AnkiRequest where TParams : class
{
    public AnkiRequest(string action, TParams @params) : base(action)
    {
        Params = @params;
    }

    [JsonPropertyOrder(2)]
    [JsonPropertyName("params")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TParams? Params { get; set; }
}
