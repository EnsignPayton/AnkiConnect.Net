namespace AnkiConnect.Net.Models;

public class UpdateModelTemplatesParams
{
    public UpdateModelTemplatesParams()
    {
    }

    public UpdateModelTemplatesParams(UpdateModelTemplatesData model)
    {
        Model = model;
    }

    public static implicit operator UpdateModelTemplatesParams(UpdateModelTemplatesData model) => new(model);

    [JsonPropertyName("model")]
    public UpdateModelTemplatesData Model { get; set; } = new();
}

public class UpdateModelTemplatesData
{
    [JsonPropertyOrder(0)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    [JsonPropertyName("templates")]
    public IDictionary<string, CardTemplate> Templates { get; set; } = new Dictionary<string, CardTemplate>();
}
