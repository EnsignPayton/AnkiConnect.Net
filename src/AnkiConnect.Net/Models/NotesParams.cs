namespace AnkiConnect.Net.Models;

public class NotesParams
{
    public NotesParams()
    {
    }

    public NotesParams(IList<ulong> notes)
    {
        Notes = notes;
    }

    public NotesParams(params ulong[] notes)
    {
        Notes = notes;
    }

    [JsonPropertyName("notes")]
    public IList<ulong> Notes { get; set; } = new List<ulong>();
}
