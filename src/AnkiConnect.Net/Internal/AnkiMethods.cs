namespace AnkiConnect.Net.Internal;

internal static class AnkiMethods
{
    // Card Actions
    public const string GetEaseFactors = "getEaseFactors";
    public const string SetEaseFactors = "setEaseFactors";
    public const string SetSpecificValueOfCard = "setSpecificValueOfCard";
    public const string Suspend = "suspend";
    public const string Unsuspend = "unsuspend";
    public const string Suspended = "suspended";
    public const string AreSuspended = "areSuspended";
    public const string AreDue = "areDue";
    public const string GetIntervals = "getIntervals";
    public const string FindCards = "findCards";
    public const string CardsToNotes = "cardsToNotes";
    public const string CardsModTime = "cardsModTime";
    public const string CardsInfo = "cardsInfo";
    public const string ForgetCards = "forgetCards";
    public const string RelearnCards = "relearnCards";

    // Deck Actions
    public const string DeckNames = "deckNames";
    public const string DeckNamesAndIds = "deckNamesAndIds";
    public const string GetDecks = "getDecks";
    public const string CreateDeck = "createDeck";
    public const string ChangeDeck = "changeDeck";
    public const string DeleteDecks = "deleteDecks";
    public const string GetDeckConfig = "getDeckConfig";
    public const string SaveDeckConfig = "saveDeckConfig";
    public const string SetDeckConfigId = "setDeckConfigId";
    public const string CloneDeckConfigId = "cloneDeckConfigId";
    public const string RemoveDeckConfigId = "removeDeckConfigId";
    public const string GetDeckStats = "getDeckStats";

    // Graphical Actions
    public const string GuiBrowse = "guiBrowse";
    public const string GuiSelectedNotes = "guiSelectedNotes";
    public const string GuiAddCards = "guiAddCards";
    public const string GuiEditNote = "guiEditNote";
    public const string GuiCurrentCard = "guiCurrentCard";
    public const string GuiStartCardTimer = "guiStartCardTimer";
    public const string GuiShowQuestion = "guiShowQuestion";
    public const string GuiShowAnswer = "guiShowAnswer";
    public const string GuiAnswerCard = "guiAnswerCard";
    public const string GuiDeckOverview = "guiDeckOverview";
    public const string GuiDeckBrowser = "guiDeckBrowser";
    public const string GuiDeckReview = "guiDeckReview";
    public const string GuiExitAnki = "guiExitAnki";
    public const string GuiCheckDatabase = "guiCheckDatabase";

    // Media Actions
    public const string StoreMediaFile = "storeMediaFile";
    public const string RetrieveMediaFile = "retrieveMediaFile";
    public const string GetMediaFilesNames = "getMediaFilesNames";
    public const string DeleteMediaFile = "deleteMediaFile";

    // Miscellaneous Actions
    public const string RequestPermission = "requestPermission";
    public const string Version = "version";
    public const string ApiReflect = "apiReflect";
    public const string Sync = "sync";
    public const string GetProfiles = "getProfiles";
    public const string LoadProfile = "loadProfile";
    public const string Multi = "multi";
    public const string ExportPackage = "exportPackage";
    public const string ImportPackage = "importPackage";
    public const string ReloadCollection = "reloadCollection";

    // Model Actions
    public const string ModelNames = "modelNames";
    public const string ModelNamesAndIds = "modelNamesAndIds";
    public const string ModelFieldNames = "modelFieldNames";
    public const string ModelFieldsOnTemplates = "modelFieldsOnTemplates";
    public const string CreateModel = "createModel";
    public const string ModelTemplates = "modelTemplates";
    public const string ModelStyling = "modelStyling";
    public const string UpdateModelTemplates = "updateModelTemplates";
    public const string UpdateModelStyling = "updateModelStyling";
    public const string FindAndReplaceInModels = "findAndReplaceInModels";

    // Note Actions
    public const string AddNote = "addNote";
    public const string AddNotes = "addNotes";
    public const string CanAddNodes = "canAddNotes";
    public const string UpdateNoteFields = "updateNoteFields";
    public const string AddTags = "addTags";
    public const string RemoveTags = "removeTags";
    public const string GetTags = "getTags";
    public const string ClearUnusedTags = "clearUnusedTags";
    public const string ReplaceTags = "replaceTags";
    public const string ReplaceTagsInAllNotes = "replaceTagsInAllNotes";
    public const string FindNotes = "findNotes";
    public const string NotesInfo = "notesInfo";
    public const string DeleteNotes = "deleteNotes";
    public const string RemoveEmptyNotes = "removeEmptyNotes";

    // Statistic Actions
    public const string GetNumCardsReviewedToday = "getNumCardsReviewedToday";
    public const string GetNumCardsReviewedByDay = "getNumCardsReviewedByDay";
    public const string GetCollectionStatsHtml = "getCollectionStatsHTML";
    public const string CardReviews = "cardReviews";
    public const string GetLatestReviewId = "getLatestReviewID";
    public const string InsertReviews = "insertReviews";
}
