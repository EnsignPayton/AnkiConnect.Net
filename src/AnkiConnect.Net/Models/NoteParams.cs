namespace AnkiConnect.Net.Models;

public class NoteParams
{
    public NoteParams()
    {
    }

    public NoteParams(ulong note)
    {
        Note = note;
    }

    public static implicit operator NoteParams(ulong note) => new(note);

    [JsonPropertyName("note")]
    public ulong Note { get; set; }
}
