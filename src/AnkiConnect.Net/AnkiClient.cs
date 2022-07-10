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

    public Task<IList<int>?> GetEaseFactorsAsync(GetEaseFactorsParams value) =>
        _client.InvokeAsync<GetEaseFactorsParams, IList<int>>(AnkiMethods.GetEaseFactors, value);

    public Task<IList<bool>?> SetEaseFactorsAsync(SetEaseFactorsParams value) =>
        _client.InvokeAsync<SetEaseFactorsParams, IList<bool>>(AnkiMethods.SetEaseFactors, value);

    public Task<IList<bool>?> SetSpecificValueOfCardAsync(SetSpecificValueOfCardParams value) =>
        _client.InvokeAsync<SetSpecificValueOfCardParams, IList<bool>>(AnkiMethods.SetSpecificValueOfCard, value);

    public Task<bool?> SuspendAsync(SuspendParams value) =>
        _client.InvokeAsync<SuspendParams, bool?>(AnkiMethods.Suspend, value);

    public Task<bool?> UnsuspendAsync(UnsuspendParams value) =>
        _client.InvokeAsync<UnsuspendParams, bool?>(AnkiMethods.Unsuspend, value);

    public Task<bool?> SuspendedAsync(SuspendedParams value) =>
        _client.InvokeAsync<SuspendedParams, bool?>(AnkiMethods.Suspended, value);

    public Task<IList<bool?>?> AreSuspendedAsync(AreSuspendedParams value) =>
        _client.InvokeAsync<AreSuspendedParams, IList<bool?>>(AnkiMethods.AreSuspended, value);

    public Task<IList<bool>?> AreDueAsync(AreDueParams value) =>
        _client.InvokeAsync<AreDueParams, IList<bool>>(AnkiMethods.AreDue, value);

    public Task<IList<int>?> GetIntervalsAsync(GetIntervalsParams value) =>
        _client.InvokeAsync<GetIntervalsParams, IList<int>>(AnkiMethods.GetIntervals, value);

    public Task<IList<IList<int>>?> GetIntervalsCompleteAsync(GetIntervalsCompleteParams value) =>
        _client.InvokeAsync<GetIntervalsCompleteParams, IList<IList<int>>>(AnkiMethods.GetIntervals, value);

    public Task<IList<string>?> DeckNamesAsync() =>
        _client.InvokeAsync<IList<string>>(AnkiMethods.DeckNames);

    public Task<IDictionary<string, int>?> DeckNamesAndIdsAsync() =>
        _client.InvokeAsync<IDictionary<string, int>>(AnkiMethods.DeckNamesAndIds);

    public Task<GuiCurrentCardResult?> GuiCurrentCardAsync() =>
        _client.InvokeAsync<GuiCurrentCardResult>(AnkiMethods.GuiCurrentCard);

    public Task<bool?> GuiStartCardTimerAsync() =>
        _client.InvokeAsync<bool?>(AnkiMethods.GuiStartCardTimer);

    public Task<bool?> GuiShowQuestionAsync() =>
        _client.InvokeAsync<bool?>(AnkiMethods.GuiShowQuestion);

    public Task<bool?> GuiShowAnswerAsync() =>
        _client.InvokeAsync<bool?>(AnkiMethods.GuiShowAnswer);

    public Task GuiDeckBrowserAsync() =>
        _client.InvokeAsync(AnkiMethods.GuiDeckBrowser);

    public Task GuiExitAnkiAsync() =>
        _client.InvokeAsync(AnkiMethods.GuiExitAnki);

    public Task GuiCheckDatabaseAsync() =>
        _client.InvokeAsync(AnkiMethods.GuiCheckDatabase);

    public Task<RequestPermissionResult?> RequestPermissionAsync() =>
        _client.InvokeAsync<RequestPermissionResult>(AnkiMethods.RequestPermission);

    public Task<int?> VersionAsync() =>
        _client.InvokeAsync<int?>(AnkiMethods.Version);

    public Task SyncAsync() =>
        _client.InvokeAsync(AnkiMethods.Sync);

    public Task<IList<string>?> GetProfilesAsync() =>
        _client.InvokeAsync<IList<string>>(AnkiMethods.GetProfiles);

    public Task ReloadCollectionAsync() =>
        _client.InvokeAsync(AnkiMethods.ReloadCollection);

    public Task<IList<string>?> ModelNamesAsync() =>
        _client.InvokeAsync<IList<string>>(AnkiMethods.ModelNames);

    public Task<IDictionary<string, ulong>?> ModelNamesAndIdsAsync() =>
        _client.InvokeAsync<IDictionary<string, ulong>>(AnkiMethods.ModelNamesAndIds);

    public Task<IList<string>?> GetTagsAsync() =>
        _client.InvokeAsync<IList<string>>(AnkiMethods.GetTags);

    public Task ClearUnusedTagsAsync() =>
        _client.InvokeAsync(AnkiMethods.ClearUnusedTags);

    public Task RemoveEmptyNotesAsync() =>
        _client.InvokeAsync(AnkiMethods.RemoveEmptyNotes);

    public Task<int?> GetNumCardsReviewedTodayAsync() =>
        _client.InvokeAsync<int?>(AnkiMethods.GetNumCardsReviewedToday);

    public Task<IList<object?>?> GetNumCardsReviewedByDayAsync() =>
        _client.InvokeAsync<IList<object?>>(AnkiMethods.GetNumCardsReviewedByDay);
}
