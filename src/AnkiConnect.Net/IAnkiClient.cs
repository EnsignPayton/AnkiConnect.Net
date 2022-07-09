using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiClient
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
}
