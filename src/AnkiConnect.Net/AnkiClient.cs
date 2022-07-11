﻿using AnkiConnect.Net.Internal;
using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiClient : IAnkiClient
{
    private readonly InternalAnkiClient _client;

    public AnkiClient(HttpClient httpClient)
    {
        _client = new InternalAnkiClient(httpClient);
    }

    #region IAnkiCards

    public Task<IList<int>?> GetEaseFactorsAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, IList<int>>(AnkiMethods.GetEaseFactors, value);

    public Task<IList<bool>?> SetEaseFactorsAsync(SetEaseFactorsParams value) =>
        _client.InvokeAsync<SetEaseFactorsParams, IList<bool>>(AnkiMethods.SetEaseFactors, value);

    public Task<IList<bool>?> SetSpecificValueOfCardAsync(SetSpecificValueOfCardParams value) =>
        _client.InvokeAsync<SetSpecificValueOfCardParams, IList<bool>>(AnkiMethods.SetSpecificValueOfCard, value);

    public Task<bool?> SuspendAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, bool?>(AnkiMethods.Suspend, value);

    public Task<bool?> UnsuspendAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, bool?>(AnkiMethods.Unsuspend, value);

    public Task<bool?> SuspendedAsync(SuspendedParams value) =>
        _client.InvokeAsync<SuspendedParams, bool?>(AnkiMethods.Suspended, value);

    public Task<IList<bool?>?> AreSuspendedAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, IList<bool?>>(AnkiMethods.AreSuspended, value);

    public Task<IList<bool>?> AreDueAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, IList<bool>>(AnkiMethods.AreDue, value);

    public Task<IList<int>?> GetIntervalsAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, IList<int>>(AnkiMethods.GetIntervals, value);

    public Task<IList<IList<int>>?> GetIntervalsCompleteAsync(CardsParams value) =>
        _client.InvokeAsync<GetIntervalsCompleteParams, IList<IList<int>>>(AnkiMethods.GetIntervals,
            new GetIntervalsCompleteParams(value));

    public Task<IList<ulong>?> FindCardsAsync(FindCardsParams value) =>
        _client.InvokeAsync<FindCardsParams, IList<ulong>>(AnkiMethods.FindCards, value);

    public Task<IList<ulong>?> CardsToNotesAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, IList<ulong>>(AnkiMethods.CardsToNotes, value);

    public Task<IList<CardModTime>?> CardsModTimeAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, IList<CardModTime>>(AnkiMethods.CardsModTime, value);

    public Task<IList<CardInfo>?> CardsInfoAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, IList<CardInfo>>(AnkiMethods.CardsInfo, value);

    public Task ForgetCardsAsync(CardsParams value) =>
        _client.InvokeAsync(AnkiMethods.ForgetCards, value);

    public Task RelearnCardsAsync(CardsParams value) =>
        _client.InvokeAsync(AnkiMethods.RelearnCards, value);

    #endregion

    #region IAnkiDecks

    public Task<IList<string>?> DeckNamesAsync() =>
        _client.InvokeAsync<IList<string>>(AnkiMethods.DeckNames);

    public Task<IDictionary<string, int>?> DeckNamesAndIdsAsync() =>
        _client.InvokeAsync<IDictionary<string, int>>(AnkiMethods.DeckNamesAndIds);

    public Task<IDictionary<string, IList<ulong>>?> GetDecksAsync(CardsParams value) =>
        _client.InvokeAsync<CardsParams, IDictionary<string, IList<ulong>>>(AnkiMethods.GetDecks, value);

    public Task<ulong?> CreateDeckAsync(DeckParams value) =>
        _client.InvokeAsync<DeckParams, ulong?>(AnkiMethods.CreateDeck, value);

    public Task ChangeDeckAsync(ChangeDeckParams value) =>
        _client.InvokeAsync(AnkiMethods.ChangeDeck, value);

    public Task DeleteDecksAsync(DecksParams value) =>
        _client.InvokeAsync(AnkiMethods.DeleteDecks, new DeleteDecksParams(value));

    #endregion

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
