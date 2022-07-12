namespace AnkiConnect.Net.Models;

public class RevConfig
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("bury")]
    public bool Bury { get; set; }

    [JsonPropertyOrder(1)]
    [JsonPropertyName("ivlFct")]
    public int IvlFct { get; set; }

    [JsonPropertyOrder(2)]
    [JsonPropertyName("ease4")]
    public double Ease4 { get; set; }

    [JsonPropertyOrder(3)]
    [JsonPropertyName("maxIvl")]
    public int MaxIvl { get; set; }

    [JsonPropertyOrder(4)]
    [JsonPropertyName("perDay")]
    public int PerDay { get; set; }

    [JsonPropertyOrder(5)]
    [JsonPropertyName("minSpace")]
    public int MinSpace { get; set; }

    [JsonPropertyOrder(6)]
    [JsonPropertyName("fuzz")]
    public double Fuzz { get; set; }
}
