namespace AnkiConnect.Net.Models;

public class FindCardsParams
{
    [JsonPropertyName("query")]
    public string Query { get; set; } = string.Empty;
}
