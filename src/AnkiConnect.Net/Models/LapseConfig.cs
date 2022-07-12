namespace AnkiConnect.Net.Models;

public class LapseConfig
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("leechFails")]
    public int LeechFails { get; set; }

    [JsonPropertyOrder(1)]
    [JsonPropertyName("delays")]
    public IList<int> Delays { get; set; } = new List<int>();

    [JsonPropertyOrder(2)]
    [JsonPropertyName("minInt")]
    public int MinInt { get; set; }

    [JsonPropertyOrder(3)]
    [JsonPropertyName("leechAction")]
    public int LeechAction { get; set; }

    [JsonPropertyOrder(4)]
    [JsonPropertyName("mult")]
    public int Mult { get; set; }
}
