using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiClient : IAnkiCards
{
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
