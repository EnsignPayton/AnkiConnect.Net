using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiClient
{
    /// <summary>
    /// Returns an array with the ease factor for each of the given cards (in the same order)
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>An array with the ease factor for each of the given cards (in the same order)</returns>
    Task<IList<int>?> GetEaseFactorsAsync(GetEaseFactorsParams value);

    /// <summary>
    /// Sets ease factor of cards by card ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful (all cards existed) or false otherwise</returns>
    Task<IList<bool>?> SetEaseFactorsAsync(SetEaseFactorsParams value);

    Task<IList<string>?> DeckNamesAsync();
    Task<IDictionary<string, int>?> DeckNamesAndIdsAsync();
    Task<GuiCurrentCardResult?> GuiCurrentCardAsync();
    Task<bool?> GuiStartCardTimerAsync();
    Task<bool?> GuiShowQuestionAsync();
    Task<bool?> GuiShowAnswerAsync();
    Task GuiDeckBrowserAsync();
    Task GuiExitAnkiAsync();
    Task GuiCheckDatabaseAsync();
    Task<RequestPermissionResult?> RequestPermissionAsync();
    Task<int?> VersionAsync();
    Task SyncAsync();
    Task<IList<string>?> GetProfilesAsync();
    Task ReloadCollectionAsync();
    Task<IList<string>?> ModelNamesAsync();
    Task<IDictionary<string, ulong>?> ModelNamesAndIdsAsync();
    Task<IList<string>?> GetTagsAsync();
    Task ClearUnusedTagsAsync();
    Task RemoveEmptyNotesAsync();
    Task<int?> GetNumCardsReviewedTodayAsync();
    // TODO: Parse. What is the type of ["2021-02-28", 124] ?
    Task<IList<object?>?> GetNumCardsReviewedByDayAsync();
}
