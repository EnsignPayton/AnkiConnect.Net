namespace AnkiConnect.Net.Models;

public class CloneDeckConfigIdParams
{
    public CloneDeckConfigIdParams()
    {
    }

    public CloneDeckConfigIdParams(string name, int? cloneFrom = null)
    {
        Name = name;
        CloneFrom = cloneFrom;
    }

    [JsonPropertyOrder(0)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    [JsonPropertyName("cloneFrom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CloneFrom { get; set; }
}
