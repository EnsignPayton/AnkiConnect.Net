namespace AnkiConnect.Net.Models;

public class CardModTime
{
    [JsonPropertyName("cardId")]
    public ulong CardId { get; set; }

    [JsonPropertyName("mod")]
    public ulong Mod { get; set; }
}
