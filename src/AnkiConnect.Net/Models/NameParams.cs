namespace AnkiConnect.Net.Models;

public class NameParams
{
    public NameParams()
    {
    }

    public NameParams(string name)
    {
        Name = name;
    }

    public static implicit operator NameParams(string name) => new(name);

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
