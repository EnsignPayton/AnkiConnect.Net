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

    /// <summary>
    /// Sets specific value of a single card
    /// </summary>
    /// <remarks>
    /// Given the risk of wreaking havoc in the database when changing some of the values of a card, some of the keys
    /// require the argument "warning_check" set to True. This can be used to set a card's flag, change its
    /// ease factor, change the review order in a filtered deck and change the column "data" (not currently used
    /// by anki apparently), and many other values. A list of values and explanation of their respective utility
    /// can be found at AnkiDroid's wiki.
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful or false otherwise</returns>
    // TODO: Check out this "warning_check" argument. Do we need to support this?
    Task<IList<bool>?> SetSpecificValueOfCardAsync(SetSpecificValueOfCardParams value);

    /// <summary>
    /// Suspend cards by card ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful (at least one card wasn't already suspended) or false otherwise</returns>
    Task<bool?> SuspendAsync(SuspendParams value);

    /// <summary>
    /// Unsuspend cards by card ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful (at least one card was previously suspended) or false otherwise</returns>
    Task<bool?> UnsuspendAsync(UnsuspendParams value);

    /// <summary>
    /// Check if card is suspended by its ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if suspended, false otherwise</returns>
    Task<bool?> SuspendedAsync(SuspendedParams value);

    /// <summary>
    /// Check if cards are suspended by card ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>
    /// An array indicating whether each of the given cards is suspended (in the same order).
    /// If card doesn't exist returns null
    /// </returns>
    Task<IList<bool?>?> AreSuspendedAsync(AreSuspendedParams value);

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
