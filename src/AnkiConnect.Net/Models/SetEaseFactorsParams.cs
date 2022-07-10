using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class SetEaseFactorsParams
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("cards")]
    public IList<ulong> Cards { get; set; } = new List<ulong>();

    [JsonPropertyOrder(1)]
    [JsonPropertyName("easeFactors")]
    public IList<int> EaseFactors { get; set; } = new List<int>();
}
