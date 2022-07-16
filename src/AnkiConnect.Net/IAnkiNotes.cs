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

    /// <summary>
    /// Replace tags in notes bby note ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task ReplaceTagsAsync(ReplaceTagsParams value);

    /// <summary>
    /// Replace tags in all the notes for the current user
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task ReplaceTagsInAllNotesAsync(ReplaceTagsInAllNotesParams value);

    /// <summary>
    /// Returns an array of note IDs for a given query
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>An array of note IDs for a given query</returns>
    Task<IList<ulong>?> FindNotesAsync(QueryParams value);

    /// <summary>
    /// Returns a list of objects containing for each not ID the note fields, tags, not type and the cards belonging
    /// to the note
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Notes info</returns>
    Task<IList<NoteInfo>?> NotesInfoAsync(NotesParams value);

    /// <summary>
    /// Deletes notes with the given ids
    /// </summary>
    /// <remarks>If a note has several cards associated with it, all associated cards will be deleted</remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task DeleteNotesAsync(NotesParams value);

    /// <summary>
    /// Removes all the empty notes for the current user
    /// </summary>
    /// <returns>Task</returns>
    Task RemoveEmptyNotesAsync();
}
