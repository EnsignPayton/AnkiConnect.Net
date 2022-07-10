using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class GetIntervalsParams
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("cards")]
    public IList<ulong> Cards { get; set; } = new List<ulong>();
}

public class GetIntervalsCompleteParams : GetIntervalsParams
{
    [JsonPropertyOrder(1)]
    [JsonPropertyName("complete")]
    public bool Complete { get; set; } = true;
}
