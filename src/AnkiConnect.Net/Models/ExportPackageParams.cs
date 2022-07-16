namespace AnkiConnect.Net.Models;

public class ExportPackageParams
{
    [JsonPropertyName("deck")]
    public string Deck { get; set; } = string.Empty;

    [JsonPropertyName("path")]
    public string Path { get; set; } = string.Empty;

    [JsonPropertyName("includeSched")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool IncludeScheduleData { get; set; }
}
