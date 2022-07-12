namespace AnkiConnect.Net.Models;

public class SetDeckConfigIdParams : DecksParams
{
    [JsonPropertyOrder(1)]
    [JsonPropertyName("configId")]
    public int ConfigId { get; set; }
}
