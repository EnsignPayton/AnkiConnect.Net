namespace AnkiConnect.Net.Internal;

internal record AnkiRequest(
    [property: JsonPropertyOrder(0)] [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyOrder(1)] [property: JsonPropertyName("version")] int Version = 6);

internal record AnkiRequest<TParams>(
        string Action,
        [property: JsonPropertyOrder(2)]
        [property: JsonPropertyName("params")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        TParams? Params,
        int Version = 6)
    : AnkiRequest(Action, Version) where TParams : class;
