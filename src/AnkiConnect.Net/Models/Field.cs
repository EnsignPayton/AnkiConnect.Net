using System.Text.Json.Serialization;

namespace AnkiConnect.Net.Models;

public class Field
{
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    [JsonPropertyName("order")]
    public int Order { get; set; }
}