using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiClient : IAnkiCards, IAnkiDecks, IAnkiGui
{
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
