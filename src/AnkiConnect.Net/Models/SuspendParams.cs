using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class SuspendParams
{
    [JsonPropertyName("cards")]
    public IList<ulong> Cards { get; set; } = new List<ulong>();
}
