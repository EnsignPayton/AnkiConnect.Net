namespace AnkiConnect.Net.Models;

public class SuspendedParams
{
    public SuspendedParams()
    {
    }

    public SuspendedParams(ulong card)
    {
        Card = card;
    }

    public static implicit operator SuspendedParams(ulong card) => new(card);

    [JsonPropertyName("card")]
    public ulong Card { get; set; }
}
