using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class GetEaseFactorsParams
{
    [JsonPropertyName("cards")]
    public IList<ulong> Cards { get; set; } = new List<ulong>();
}
