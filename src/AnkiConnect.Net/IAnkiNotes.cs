using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiNotes
{
    // TODO: addNote
    // TODO: addNotes
    // TODO: canAddNotes
    // TODO: updateNoteFields

    /// <summary>
    /// Adds tags to notes by note ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task AddTagsAsync(NoteTagsParams value);

    /// <summary>
    /// Remove tags from notes by note ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task RemoveTagsAsync(NoteTagsParams value);

    /// <summary>
    /// Gets the complete list of tags for the current user
    /// </summary>
    /// <returns>Tags</returns>
    Task<IList<string>?> GetTagsAsync();

    /// <summary>
    /// Clears all the unused tags in the notes for the current user
    /// </summary>
    /// <returns>Task</returns>
    Task ClearUnusedTagsAsync();

    Task RemoveEmptyNotesAsync();
}
