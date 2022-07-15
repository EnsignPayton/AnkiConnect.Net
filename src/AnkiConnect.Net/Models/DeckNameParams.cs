namespace AnkiConnect.Net.Models;

public class DeckNameParams
{
    public DeckNameParams()
    {
    }

    public DeckNameParams(string name)
    {
        Name = name;
    }

    public static implicit operator DeckNameParams(string name) => new(name);

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
