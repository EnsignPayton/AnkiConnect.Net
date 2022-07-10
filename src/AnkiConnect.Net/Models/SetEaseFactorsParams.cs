using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class SetEaseFactorsParams : CardsParams
{
    [JsonPropertyOrder(1)]
    [JsonPropertyName("easeFactors")]
    public IList<int> EaseFactors { get; set; } = new List<int>();
}
