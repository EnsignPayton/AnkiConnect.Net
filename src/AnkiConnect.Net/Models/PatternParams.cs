namespace AnkiConnect.Net.Models;

public class PatternParams
{
    public PatternParams()
    {
    }

    public PatternParams(string pattern)
    {
        Pattern = pattern;
    }

    public static implicit operator PatternParams(string pattern) => new(pattern);

    [JsonPropertyName("pattern")]
    public string Pattern { get; set; } = string.Empty;
}
