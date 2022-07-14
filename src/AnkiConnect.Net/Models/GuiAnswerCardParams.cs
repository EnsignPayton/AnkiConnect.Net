namespace AnkiConnect.Net.Models;

public class GuiAnswerCardParams
{
    public GuiAnswerCardParams()
    {
    }

    public GuiAnswerCardParams(int ease)
    {
        Ease = ease;
    }

    public static implicit operator GuiAnswerCardParams(int ease) => new(ease);

    [JsonPropertyName("ease")]
    public int Ease { get; set; }
}
