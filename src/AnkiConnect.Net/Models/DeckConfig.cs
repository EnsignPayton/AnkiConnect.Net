namespace AnkiConnect.Net.Models;

public class DeckConfig
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("lapse")]
    public LapseConfig Lapse { get; set; } = new();

    [JsonPropertyOrder(1)]
    [JsonPropertyName("dyn")]
    public bool Dyn { get; set; }

    [JsonPropertyOrder(2)]
    [JsonPropertyName("autoplay")]
    public bool Autoplay { get; set; }

    [JsonPropertyOrder(3)]
    [JsonPropertyName("mod")]
    public ulong Mod { get; set; }

    [JsonPropertyOrder(4)]
    [JsonPropertyName("id")]
    public ulong Id { get; set; }

    [JsonPropertyOrder(5)]
    [JsonPropertyName("maxTaken")]
    public int MaxTaken { get; set; }

    [JsonPropertyOrder(6)]
    [JsonPropertyName("new")]
    public NewConfig New { get; set; } = new();

    [JsonPropertyOrder(7)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyOrder(8)]
    [JsonPropertyName("rev")]
    public RevConfig Rev { get; set; } = new();

    [JsonPropertyOrder(9)]
    [JsonPropertyName("timer")]
    public int Timer { get; set; }

    [JsonPropertyOrder(10)]
    [JsonPropertyName("replayq")]
    public bool ReplayQ { get; set; }

    [JsonPropertyOrder(11)]
    [JsonPropertyName("usn")]
    public int Usn { get; set; }
}
