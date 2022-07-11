namespace AnkiConnect.Net.Models;

public class SetSpecificValueOfCardParams
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("card")]
    public ulong Card { get; set; }

    [JsonPropertyOrder(1)]
    [JsonPropertyName("keys")]
    public IList<string> Keys { get; set; } = new List<string>();

    [JsonPropertyOrder(2)]
    [JsonPropertyName("newValues")]
    public IList<string> NewValues { get; set; } = new List<string>();

    [JsonPropertyOrder(3)]
    [JsonPropertyName("warning_check")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool WarningCheck { get; set; }
}
