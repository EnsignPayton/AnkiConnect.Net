namespace AnkiConnect.Net.Models;

public class CardsParams
{
    public CardsParams()
    {
    }

    public CardsParams(IList<ulong> cards)
    {
        Cards = cards;
    }

    public CardsParams(params ulong[] cards)
    {
        Cards = cards;
    }

    [JsonPropertyName("cards")]
    public IList<ulong> Cards { get; set; } = new List<ulong>();
}
