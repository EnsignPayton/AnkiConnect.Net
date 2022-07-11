namespace AnkiConnect.Net.Models;

public class FindCardsParams
{
    public FindCardsParams()
    {
    }

    public FindCardsParams(string query)
    {
        Query = query;
    }

    public static implicit operator FindCardsParams(string query) => new(query);

    [JsonPropertyName("query")]
    public string Query { get; set; } = string.Empty;
}
