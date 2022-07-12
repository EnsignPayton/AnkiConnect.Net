namespace AnkiConnect.Net.Models;

public class QueryParams
{
    public QueryParams()
    {
    }

    public QueryParams(string query)
    {
        Query = query;
    }

    public static implicit operator QueryParams(string query) => new(query);

    [JsonPropertyName("query")]
    public string Query { get; set; } = string.Empty;
}
