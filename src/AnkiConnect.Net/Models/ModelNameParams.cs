namespace AnkiConnect.Net.Models;

public class ModelNameParams
{
    public ModelNameParams()
    {
    }

    public ModelNameParams(string modelName)
    {
        ModelName = modelName;
    }

    public static implicit operator ModelNameParams(string modelName) => new(modelName);

    [JsonPropertyName("modelName")]
    public string ModelName { get; set; } = string.Empty;
}
