namespace AnkiConnect.Net.Models;

public class FindAndReplaceInModelsParams
{
    public FindAndReplaceInModelsParams()
    {
    }

    public FindAndReplaceInModelsParams(FindAndReplaceInModelsData model)
    {
        Model = model;
    }

    public static implicit operator FindAndReplaceInModelsParams(FindAndReplaceInModelsData model) => new(model);

    [JsonPropertyName("model")]
    public FindAndReplaceInModelsData Model { get; set; } = new();
}

public class FindAndReplaceInModelsData
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("modelName")]
    public string ModelName { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    [JsonPropertyName("findText")]
    public string FindText { get; set; } = string.Empty;

    [JsonPropertyOrder(2)]
    [JsonPropertyName("replaceText")]
    public string ReplaceText { get; set; } = string.Empty;

    [JsonPropertyOrder(3)]
    [JsonPropertyName("front")]
    public bool Front { get; set; }

    [JsonPropertyOrder(4)]
    [JsonPropertyName("back")]
    public bool Back { get; set; }

    [JsonPropertyOrder(5)]
    [JsonPropertyName("css")]
    public bool Css { get; set; }
}
