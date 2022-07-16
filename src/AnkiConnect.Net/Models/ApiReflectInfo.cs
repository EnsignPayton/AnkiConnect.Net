namespace AnkiConnect.Net.Models;

public abstract class ApiReflectInfo
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("scopes")]
    public IList<string> Scopes { get; set; } = new List<string>();

    [JsonPropertyOrder(1)]
    [JsonPropertyName("actions")]
    public IList<string>? Actions { get; set; }
}

public class ApiReflectParams : ApiReflectInfo
{
}

public class ApiReflectResult : ApiReflectInfo
{
}
