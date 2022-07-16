namespace AnkiConnect.Net.Models;

public class PathParams
{
    public PathParams()
    {
    }

    public PathParams(string path)
    {
        Path = path;
    }

    public static implicit operator PathParams(string path) => new(path);

    [JsonPropertyName("path")]
    public string Path { get; set; } = string.Empty;
}
