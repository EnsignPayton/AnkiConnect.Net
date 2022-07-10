using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class AreDueParams
{
    [JsonPropertyName("cards")]
    public IList<ulong> Cards { get; set; } = new List<ulong>();
}
