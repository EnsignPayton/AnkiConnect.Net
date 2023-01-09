using System.Text.Json;
using AnkiConnect.Net.Internal;
using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiClient : IAnkiClient
{
    private readonly InternalAnkiClient _client;

    public AnkiClient() : this(new HttpClient())
    {
    }

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

    public Task<IList<ulong>?> FindCardsAsync(QueryParams value) =>
        _client.InvokeAsync<QueryParams, IList<ulong>>(AnkiMethods.FindCards, value);

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

    public Task<DeckConfig?> GetDeckConfigAsync(DeckParams value) =>
        _client.InvokeAsync<DeckParams, DeckConfig>(AnkiMethods.GetDeckConfig, value);

    public Task<bool?> SaveDeckConfigAsync(DeckConfigParams value) =>
        _client.InvokeAsync<DeckConfigParams, bool?>(AnkiMethods.SaveDeckConfig, value);

    public Task<bool?> SetDeckConfigIdAsync(SetDeckConfigIdParams value) =>
        _client.InvokeAsync<SetDeckConfigIdParams, bool?>(AnkiMethods.SetDeckConfigId, value);

    public async Task<ulong?> CloneDeckConfigIdAsync(CloneDeckConfigIdParams value)
    {
        var result = await _client.InvokeAsync<CloneDeckConfigIdParams, JsonElement>(
            AnkiMethods.CloneDeckConfigId, value);

        if (result.ValueKind is JsonValueKind.Number && result.TryGetUInt64(out var u64Result))
            return u64Result;

        return null;
    }

    public Task<bool?> RemoveDeckConfigIdAsync(RemoveDeckConfigIdParams value) =>
        _client.InvokeAsync<RemoveDeckConfigIdParams, bool?>(AnkiMethods.RemoveDeckConfigId, value);

    public Task<IDictionary<ulong, DeckStats>?> GetDeckStatsAsync(DecksParams value) =>
        _client.InvokeAsync<DecksParams, IDictionary<ulong, DeckStats>>(AnkiMethods.GetDeckStats, value);

    #endregion

    #region IAnkiGui

    public Task<IList<ulong>?> GuiBrowseAsync(QueryParams value) =>
        _client.InvokeAsync<QueryParams, IList<ulong>?>(AnkiMethods.GuiBrowse, value);

    public Task<IList<ulong>?> GuiSelectedNotesAsync() =>
        _client.InvokeAsync<IList<ulong>?>(AnkiMethods.GuiSelectedNotes);

    public Task GuiEditNoteAsync(NoteParams value) =>
        _client.InvokeAsync(AnkiMethods.GuiEditNote, value);

    public Task<GuiCurrentCardResult?> GuiCurrentCardAsync() =>
        _client.InvokeAsync<GuiCurrentCardResult>(AnkiMethods.GuiCurrentCard);

    public Task<bool?> GuiStartCardTimerAsync() =>
        _client.InvokeAsync<bool?>(AnkiMethods.GuiStartCardTimer);

    public Task<bool?> GuiShowQuestionAsync() =>
        _client.InvokeAsync<bool?>(AnkiMethods.GuiShowQuestion);

    public Task<bool?> GuiShowAnswerAsync() =>
        _client.InvokeAsync<bool?>(AnkiMethods.GuiShowAnswer);

    public Task<bool?> GuiAnswerCardAsync(GuiAnswerCardParams value) =>
        _client.InvokeAsync<GuiAnswerCardParams, bool?>(AnkiMethods.GuiAnswerCard, value);

    public Task<bool?> GuiDeckOverviewAsync(DeckNameParams value) =>
        _client.InvokeAsync<DeckNameParams, bool?>(AnkiMethods.GuiDeckOverview, value);

    public Task GuiDeckBrowserAsync() =>
        _client.InvokeAsync(AnkiMethods.GuiDeckBrowser);

    public Task<bool?> GuiDeckReviewAsync(DeckNameParams value) =>
        _client.InvokeAsync<DeckNameParams, bool?>(AnkiMethods.GuiDeckReview, value);

    public Task GuiExitAnkiAsync() =>
        _client.InvokeAsync(AnkiMethods.GuiExitAnki);

    public Task GuiCheckDatabaseAsync() =>
        _client.InvokeAsync(AnkiMethods.GuiCheckDatabase);

    #endregion

    #region IAnkiMedia

    public Task<string?> StoreMediaFileAsync(StoreMediaFileParams value) =>
        _client.InvokeAsync<StoreMediaFileParams, string?>(AnkiMethods.StoreMediaFile, value);

    public async Task<string?> RetrieveMediaFileAsync(FileNameParams value)
    {
        var result = await _client.InvokeAsync<FileNameParams, JsonElement>(AnkiMethods.RetrieveMediaFile, value);

        return result.ValueKind is JsonValueKind.String ? result.GetString() : null;
    }

    public Task<IList<string>?> GetMediaFileNamesAsync(PatternParams value) =>
        _client.InvokeAsync<PatternParams, IList<string>>(AnkiMethods.GetMediaFilesNames, value);

    public Task DeleteMediaFileAsync(FileNameParams value) =>
        _client.InvokeAsync(AnkiMethods.DeleteMediaFile, value);

    #endregion

    #region IAnkiMisc

    public Task<RequestPermissionResult?> RequestPermissionAsync() =>
        _client.InvokeAsync<RequestPermissionResult>(AnkiMethods.RequestPermission);

    public Task<int?> VersionAsync() =>
        _client.InvokeAsync<int?>(AnkiMethods.Version);

    public Task<ApiReflectResult?> ApiReflectAsync(ApiReflectParams value) =>
        _client.InvokeAsync<ApiReflectParams, ApiReflectResult>(AnkiMethods.ApiReflect, value);

    public Task SyncAsync() =>
        _client.InvokeAsync(AnkiMethods.Sync);

    public Task<IList<string>?> GetProfilesAsync() =>
        _client.InvokeAsync<IList<string>>(AnkiMethods.GetProfiles);

    public Task<bool?> LoadProfileAsync(NameParams value) =>
        _client.InvokeAsync<NameParams, bool?>(AnkiMethods.LoadProfile, value);

    public Task<bool?> ExportPackageAsync(ExportPackageParams value) =>
        _client.InvokeAsync<ExportPackageParams, bool?>(AnkiMethods.ExportPackage, value);

    public Task<bool?> ImportPackageAsync(PathParams value) =>
        _client.InvokeAsync<PathParams, bool?>(AnkiMethods.ImportPackage, value);

    public Task ReloadCollectionAsync() =>
        _client.InvokeAsync(AnkiMethods.ReloadCollection);

    #endregion

    #region IAnkiModels

    public Task<IList<string>?> ModelNamesAsync() =>
        _client.InvokeAsync<IList<string>>(AnkiMethods.ModelNames);

    public Task<IDictionary<string, ulong>?> ModelNamesAndIdsAsync() =>
        _client.InvokeAsync<IDictionary<string, ulong>>(AnkiMethods.ModelNamesAndIds);

    public Task<IList<string>?> ModelFieldNamesAsync(ModelNameParams value) =>
        _client.InvokeAsync<ModelNameParams, IList<string>>(AnkiMethods.ModelFieldNames, value);

    public Task<IDictionary<string, IList<IList<string>>>?> ModelFieldsOnTemplatesAsync(ModelNameParams value) =>
        _client.InvokeAsync<ModelNameParams, IDictionary<string, IList<IList<string>>>>(
            AnkiMethods.ModelFieldsOnTemplates, value);

    public Task<IDictionary<string, CardTemplate>?> ModelTemplatesAsync(ModelNameParams value) =>
        _client.InvokeAsync<ModelNameParams, IDictionary<string, CardTemplate>>(AnkiMethods.ModelTemplates, value);

    public Task<ModelStyling?> ModelStylingAsync(ModelNameParams value) =>
        _client.InvokeAsync<ModelNameParams, ModelStyling>(AnkiMethods.ModelStyling, value);

    public Task UpdateModelTemplatesAsync(UpdateModelTemplatesParams value) =>
        _client.InvokeAsync(AnkiMethods.UpdateModelTemplates, value);

    public Task UpdateModelStylingAsync(UpdateModelStylingParams value) =>
        _client.InvokeAsync(AnkiMethods.UpdateModelStyling, value);

    public Task<int?> FindAndReplaceInModelsAsync(FindAndReplaceInModelsParams value) =>
        _client.InvokeAsync<FindAndReplaceInModelsParams, int?>(AnkiMethods.FindAndReplaceInModels, value);

    #endregion

    #region IAnkiNotes

    public Task AddTagsAsync(NoteTagsParams value) =>
        _client.InvokeAsync(AnkiMethods.AddTags, value);

    public Task RemoveTagsAsync(NoteTagsParams value) =>
        _client.InvokeAsync(AnkiMethods.RemoveTags, value);

    public Task<IList<string>?> GetTagsAsync() =>
        _client.InvokeAsync<IList<string>>(AnkiMethods.GetTags);

    public Task ClearUnusedTagsAsync() =>
        _client.InvokeAsync(AnkiMethods.ClearUnusedTags);

    public Task ReplaceTagsAsync(ReplaceTagsParams value) =>
        _client.InvokeAsync(AnkiMethods.ReplaceTags, value);

    public Task ReplaceTagsInAllNotesAsync(ReplaceTagsInAllNotesParams value) =>
        _client.InvokeAsync(AnkiMethods.ReplaceTagsInAllNotes, value);

    public Task<IList<ulong>?> FindNotesAsync(QueryParams value) =>
        _client.InvokeAsync<QueryParams, IList<ulong>>(AnkiMethods.FindNotes, value);

    public Task<IList<NoteInfo>?> NotesInfoAsync(NotesParams value) =>
        _client.InvokeAsync<NotesParams, IList<NoteInfo>>(AnkiMethods.NotesInfo, value);

    public Task DeleteNotesAsync(NotesParams value) =>
        _client.InvokeAsync(AnkiMethods.DeleteNotes, value);

    public Task RemoveEmptyNotesAsync() =>
        _client.InvokeAsync(AnkiMethods.RemoveEmptyNotes);

    #endregion

    #region IAnkiStats

    public Task<int?> GetNumCardsReviewedTodayAsync() =>
        _client.InvokeAsync<int?>(AnkiMethods.GetNumCardsReviewedToday);

    public Task<string?> GetCollectionStatsHtmlAsync(WholeCollectionParams value) =>
        _client.InvokeAsync<WholeCollectionParams, string?>(AnkiMethods.GetCollectionStatsHtml, value);

    public Task<ulong?> GetLatestReviewIdAsync(DeckParams value) =>
        _client.InvokeAsync<DeckParams, ulong?>(AnkiMethods.GetLatestReviewId, value);

    #endregion
}
