namespace AnkiConnect.Net.Internal;

internal class AnkiResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;
}

internal class AnkiResponse<TResult> : AnkiResponse
{
    [JsonPropertyName("result")]
    public TResult? Result { get; set; }
}
