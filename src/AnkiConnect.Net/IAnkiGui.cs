using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiGui
{
    /// <summary>
    /// Invokes the CardBrowser dialog and searches for a given query
    /// </summary>
    /// <remarks>
    /// Query syntax is documented at https://docs.ankiweb.net/searching.html
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>An array of identifier of the cards that were found</returns>
    Task<IList<ulong>?> GuiBrowseAsync(QueryParams value);

    /// <summary>
    /// Finds the open instance of the Card Browser dialog and returns an array of identifiers of the notes that are
    /// selected. Returns an empty list of the browser is not open.
    /// </summary>
    /// <returns>Selected note ids</returns>
    Task<IList<ulong>?> GuiSelectedNotesAsync();

    // TODO: GuiAddCardsAsync

    /// <summary>
    /// Opens the edit dialog with a note corresponding to given note ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task GuiEditNoteAsync(NoteParams value);

    /// <summary>
    /// Returns information about the current card or null if not in review mode
    /// </summary>
    /// <returns></returns>
    Task<GuiCurrentCardResult?> GuiCurrentCardAsync();

    /// <summary>
    /// Starts or resets the timerStarted value for the current card.
    /// </summary>
    /// <remarks>
    /// This is useful for deferring the start time to when it is displayed via the API, allowing the recorded
    /// time taken to answer the card to be more accurate when calling <see cref="GuiAnswerCardAsync"/>
    /// </remarks>
    /// <returns>Success</returns>
    Task<bool?> GuiStartCardTimerAsync();

    /// <summary>
    /// Shows question text for the current card
    /// </summary>
    /// <returns>True if in review mode or false otherwise</returns>
    Task<bool?> GuiShowQuestionAsync();

    /// <summary>
    /// Shows answer text for the current card
    /// </summary>
    /// <returns>True if in review mode or false otherwise</returns>
    Task<bool?> GuiShowAnswerAsync();

    /// <summary>
    /// Answers the current card
    /// </summary>
    /// <remarks>Note that the answer for the current card must be displayed before any answer can be accepted by Anki</remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if succeeded or false otherwise</returns>
    Task<bool?> GuiAnswerCardAsync(GuiAnswerCardParams value);

    /// <summary>
    /// Opens the Deck Overview dialog for the deck with the given name
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if succeeded or false otherwise</returns>
    Task<bool?> GuiDeckOverviewAsync(DeckNameParams value);

    /// <summary>
    /// Opens the Deck Browser dialog
    /// </summary>
    /// <returns>Task</returns>
    Task GuiDeckBrowserAsync();

    /// <summary>
    /// Starts review for the deck with the given name
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if succeeded or false otherwise</returns>
    Task<bool?> GuiDeckReviewAsync(DeckNameParams value);

    /// <summary>
    /// Schedules a request to gracefully close Anki
    /// </summary>
    /// <remarks>This operation is asynchronous, so it will return immediately and won't wait until the Anki process actually terminates</remarks>
    /// <returns>Task</returns>
    Task GuiExitAnkiAsync();

    /// <summary>
    /// Requests a database check, but returns immediately without waiting for the check to complete
    /// </summary>
    /// <returns>Task</returns>
    Task GuiCheckDatabaseAsync();
}
