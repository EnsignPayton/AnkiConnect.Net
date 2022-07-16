namespace AnkiConnect.Net.Models;

public class CardTemplate
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("Front")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Front { get; set; }

    [JsonPropertyOrder(0)]
    [JsonPropertyName("Back")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Back { get; set; }
}
