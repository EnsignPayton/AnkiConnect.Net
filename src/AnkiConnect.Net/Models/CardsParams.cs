namespace AnkiConnect.Net.Models;

public class CardsParams
{
    [JsonPropertyName("cards")]
    public IList<ulong> Cards { get; set; } = new List<ulong>();
}
