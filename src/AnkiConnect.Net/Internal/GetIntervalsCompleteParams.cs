using AnkiConnect.Net.Models;

namespace AnkiConnect.Net.Internal;

internal class GetIntervalsCompleteParams : CardsParams
{
    public GetIntervalsCompleteParams(CardsParams inner)
    {
        Cards = inner.Cards;
    }

    [JsonPropertyOrder(1)]
    [JsonPropertyName("complete")]
    public bool Complete { get; set; } = true;
}
