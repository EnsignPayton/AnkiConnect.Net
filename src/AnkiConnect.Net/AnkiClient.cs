using AnkiConnect.Net.Internal;
using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiClient : IAnkiClient
{
    private readonly InternalAnkiClient _client;

    public AnkiClient(HttpClient httpClient)
    {
        _client = new InternalAnkiClient(httpClient);
    }

    private Task<TResult?> InvokeAsync<TResult>(string action) =>
        _client.InvokeAsync<TResult>(action);

    private Task InvokeAsync(string action) =>
        _client.InvokeAsync(action);

    public Task<IList<string>?> DeckNamesAsync() =>
        InvokeAsync<IList<string>>(AnkiMethods.DeckNames);

    public Task<IDictionary<string, int>?> DeckNamesAndIdsAsync() =>
        InvokeAsync<IDictionary<string, int>>(AnkiMethods.DeckNamesAndIds);

    public Task<GuiCurrentCardResult?> GuiCurrentCardAsync() =>
        InvokeAsync<GuiCurrentCardResult>(AnkiMethods.GuiCurrentCard);

    public Task<bool?> GuiStartCardTimerAsync() =>
        InvokeAsync<bool?>(AnkiMethods.GuiStartCardTimer);

    public Task<bool?> GuiShowQuestionAsync() =>
        InvokeAsync<bool?>(AnkiMethods.GuiShowQuestion);

    public Task<bool?> GuiShowAnswerAsync() =>
        InvokeAsync<bool?>(AnkiMethods.GuiShowAnswer);

    public Task GuiDeckBrowserAsync() =>
        InvokeAsync(AnkiMethods.GuiDeckBrowser);

    public Task GuiExitAnkiAsync() =>
        InvokeAsync(AnkiMethods.GuiExitAnki);

    public Task GuiCheckDatabaseAsync() =>
        InvokeAsync(AnkiMethods.GuiCheckDatabase);

    public Task<RequestPermissionResult?> RequestPermissionAsync() =>
        InvokeAsync<RequestPermissionResult>(AnkiMethods.RequestPermission);

    public Task<int?> VersionAsync() =>
        InvokeAsync<int?>(AnkiMethods.Version);

    public Task SyncAsync() =>
        InvokeAsync(AnkiMethods.Sync);

    public Task<IList<string>?> GetProfilesAsync() =>
        InvokeAsync<IList<string>>(AnkiMethods.GetProfiles);

    public Task ReloadCollectionAsync() =>
        InvokeAsync(AnkiMethods.ReloadCollection);

    public Task<IList<string>?> ModelNamesAsync() =>
        InvokeAsync<IList<string>>(AnkiMethods.ModelNames);

    public Task<IDictionary<string, ulong>?> ModelNamesAndIdsAsync() =>
        InvokeAsync<IDictionary<string, ulong>>(AnkiMethods.ModelNamesAndIds);

    public Task<IList<string>?> GetTagsAsync() =>
        InvokeAsync<IList<string>>(AnkiMethods.GetTags);

    public Task ClearUnusedTagsAsync() =>
        InvokeAsync(AnkiMethods.ClearUnusedTags);

    public Task RemoveEmptyNotesAsync() =>
        InvokeAsync(AnkiMethods.RemoveEmptyNotes);

    public Task<int?> GetNumCardsReviewedTodayAsync() =>
        InvokeAsync<int?>(AnkiMethods.GetNumCardsReviewedToday);

    public Task<IList<object?>?> GetNumCardsReviewedByDayAsync() =>
        InvokeAsync<IList<object?>>(AnkiMethods.GetNumCardsReviewedByDay);
}
