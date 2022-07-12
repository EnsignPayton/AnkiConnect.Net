namespace AnkiConnect.Net.Models;

public class RemoveDeckConfigIdParams
{
    public RemoveDeckConfigIdParams()
    {
    }

    public RemoveDeckConfigIdParams(ulong configId)
    {
        ConfigId = configId;
    }

    public static implicit operator RemoveDeckConfigIdParams(ulong configId) => new(configId);

    [JsonPropertyName("configId")]
    public ulong ConfigId { get; set; }
}
