namespace AnkiConnect.Net;

public interface IAnkiNotes
{
    Task<IList<string>?> GetTagsAsync();
    Task ClearUnusedTagsAsync();
    Task RemoveEmptyNotesAsync();
}
