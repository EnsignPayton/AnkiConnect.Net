namespace AnkiConnect.Net.Models;

public class WholeCollectionParams
{
    public WholeCollectionParams(bool wholeCollection = true)
    {
        WholeCollection = wholeCollection;
    }

    public static implicit operator WholeCollectionParams(bool wholeCollection) => new(wholeCollection);

    [JsonPropertyName("wholeCollection")]
    public bool WholeCollection { get; set; }
}
