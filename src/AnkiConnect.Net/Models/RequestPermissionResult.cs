using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class RequestPermissionResult
{
    [JsonPropertyName("permission")]
    public string Permission { get; set; } = string.Empty;

    [JsonPropertyName("requireApiKey")]
    public bool RequireApiKey { get; set; }

    [JsonPropertyName("version")]
    public int Version { get; set; }
}
