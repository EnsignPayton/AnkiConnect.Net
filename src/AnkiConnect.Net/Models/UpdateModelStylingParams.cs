namespace AnkiConnect.Net.Models;

public class UpdateModelStylingParams
{
    public UpdateModelStylingParams()
    {
    }

    public UpdateModelStylingParams(UpdateModelStylingData model)
    {
        Model = model;
    }

    public static implicit operator UpdateModelStylingParams(UpdateModelStylingData model) => new(model);

    [JsonPropertyName("model")]
    public UpdateModelStylingData Model { get; set; } = new();
}

public class UpdateModelStylingData
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    [JsonPropertyName("css")]
    public string Css { get; set; } = string.Empty;
}
