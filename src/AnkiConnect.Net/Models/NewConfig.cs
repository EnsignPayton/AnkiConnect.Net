namespace AnkiConnect.Net.Models;

public class NewConfig
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("bury")]
    public bool Bury { get; set; }

    [JsonPropertyOrder(1)]
    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyOrder(2)]
    [JsonPropertyName("initialFactor")]
    public int InitialFactor { get; set; }

    [JsonPropertyOrder(3)]
    [JsonPropertyName("perDay")]
    public int PerDay { get; set; }

    [JsonPropertyOrder(4)]
    [JsonPropertyName("delays")]
    public IList<int> Delays { get; set; } = new List<int>();

    [JsonPropertyOrder(5)]
    [JsonPropertyName("separate")]
    public bool Separate { get; set; }

    [JsonPropertyOrder(6)]
    [JsonPropertyName("ints")]
    public IList<int> Ints { get; set; } = new List<int>();
}
