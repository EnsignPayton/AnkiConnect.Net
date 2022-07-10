using System.Threading.Tasks;
using AnkiConnect.Net.Models;
using Xunit;

namespace AnkiConnect.Net;

public class AnkiClientTests : AnkiClientTestsBase<IAnkiClient>
{
    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetEaseFactorsAsync(new GetEaseFactorsParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(@"{
    ""action"": ""getEaseFactors"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[4100, 3900],\"error\":null}");

        var result = await Target.GetEaseFactorsAsync(new GetEaseFactorsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(4100, result[0]);
        Assert.Equal(3900, result[1]);
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SetEaseFactorsAsync(new SetEaseFactorsParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul},
            EaseFactors = new[] {4100, 3900}
        });

        Handler.WasSent(@"{
    ""action"": ""setEaseFactors"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217],
        ""easeFactors"": [4100, 3900]
    }
}");
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[true, true],\"error\":null}");

        var result = await Target.SetEaseFactorsAsync(new SetEaseFactorsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.True(result[0]);
        Assert.True(result[1]);
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams
        {
            Card = 1483959291685ul,
            Keys = new[] {"flags", "odue"},
            NewValues = new[] {"1", "-100"}
        });

        Handler.WasSent(@"{
    ""action"": ""setSpecificValueOfCard"",
    ""version"": 6,
    ""params"": {
        ""card"": 1483959291685,
        ""keys"": [""flags"", ""odue""],
        ""newValues"": [""1"", ""-100""]
    }
}");
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[true, true],\"error\":null}");

        var result = await Target.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.True(result[0]);
        Assert.True(result[1]);
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SuspendAsync(new SuspendParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(@"{
    ""action"": ""suspend"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.SuspendAsync(new SuspendParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.UnsuspendAsync(new UnsuspendParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(@"{
    ""action"": ""unsuspend"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.UnsuspendAsync(new UnsuspendParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task SuspendedAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SuspendedAsync(new SuspendedParams
        {
            Card = 1483959293217ul
        });

        Handler.WasSent(@"{
    ""action"": ""suspended"",
    ""version"": 6,
    ""params"": {
        ""card"": 1483959293217
    }
}");
    }

    [Fact]
    public async Task SuspendedAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.SuspendedAsync(new SuspendedParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.AreSuspendedAsync(new AreSuspendedParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul, 1234567891234ul}
        });

        Handler.WasSent(@"{
    ""action"": ""areSuspended"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217, 1234567891234]
    }
}");
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[false, true, null],\"error\":null}");

        var result = await Target.AreSuspendedAsync(new AreSuspendedParams());

        Assert.NotNull(result);
        Assert.Equal(3, result!.Count);
        Assert.False(result[0]);
        Assert.True(result[1]);
        Assert.Null(result[2]);
    }

    [Fact]
    public async Task AreDueAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.AreDueAsync(new AreDueParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(@"{
    ""action"": ""areDue"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task AreDueAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[false, true],\"error\":null}");

        var result = await Target.AreDueAsync(new AreDueParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.False(result[0]);
        Assert.True(result[1]);
    }

    [Fact]
    public async Task GetIntervalsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetIntervalsAsync(new GetIntervalsParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(@"{
    ""action"": ""getIntervals"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task GetIntervalsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[-14400, 3],\"error\":null}");

        var result = await Target.GetIntervalsAsync(new GetIntervalsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(-14400, result[0]);
        Assert.Equal(3, result[1]);
    }

    [Fact]
    public async Task GetIntervalsCompleteAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetIntervalsCompleteAsync(new GetIntervalsCompleteParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(@"{
    ""action"": ""getIntervals"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217],
        ""complete"": true
    }
}");
    }

    [Fact]
    public async Task GetIntervalsCompleteAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [
        [-120, -180, -240, -300, -360, -14400],
        [-120, -180, -240, -300, -360, -14400, 1, 3]
    ],
    ""error"": null
}");

        var result = await Target.GetIntervalsCompleteAsync(new GetIntervalsCompleteParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(6, result[0].Count);
        Assert.Equal(-120, result[0][0]);
        Assert.Equal(-180, result[0][1]);
        Assert.Equal(-240, result[0][2]);
        Assert.Equal(-300, result[0][3]);
        Assert.Equal(-360, result[0][4]);
        Assert.Equal(-14400, result[0][5]);
        Assert.Equal(8, result[1].Count);
        Assert.Equal(-120, result[1][0]);
        Assert.Equal(-180, result[1][1]);
        Assert.Equal(-240, result[1][2]);
        Assert.Equal(-300, result[1][3]);
        Assert.Equal(-360, result[1][4]);
        Assert.Equal(-14400, result[1][5]);
        Assert.Equal(1, result[1][6]);
        Assert.Equal(3, result[1][7]);
    }

    [Fact]
    public async Task DeckNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.DeckNamesAsync();

        Handler.WasSent("{\"action\":\"deckNames\",\"version\":6}");
    }

    [Fact]
    public async Task DeckNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"Default\"],\"error\":null}");

        var result = await Target.DeckNamesAsync();

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Equal("Default", result[0]);
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.DeckNamesAndIdsAsync();

        Handler.WasSent("{\"action\":\"deckNamesAndIds\",\"version\":6}");
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":{\"Default\":1},\"error\":null}");

        var result = await Target.DeckNamesAndIdsAsync();

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Contains("Default", result);
        Assert.Equal(1, result["Default"]);
    }

    [Fact]
    public async Task GuiCurrentCardAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiCurrentCardAsync();

        Handler.WasSent("{\"action\":\"guiCurrentCard\",\"version\":6}");
    }

    [Fact]
    public async Task GuiCurrentCardAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": {
        ""answer"": ""back content"",
        ""question"": ""front content"",
        ""deckName"": ""Default"",
        ""modelName"": ""Basic"",
        ""fieldOrder"": 0,
        ""fields"": {
            ""Front"": {""value"": ""front content"", ""order"": 0},
            ""Back"": {""value"": ""back content"", ""order"": 1}
        },
        ""template"": ""Forward"",
        ""cardId"": 1498938915662,
        ""buttons"": [1, 2, 3],
        ""nextReviews"": [""<1m"", ""<10m"", ""4d""]
    },
    ""error"": null
}");

        var result = await Target.GuiCurrentCardAsync();

        Assert.NotNull(result);
        Assert.Equal("back content", result!.Answer);
        Assert.Equal("front content", result.Question);
        Assert.Equal("Default", result.DeckName);
        Assert.Equal("Basic", result.ModelName);
        Assert.Equal(0, result.FieldOrder);
        Assert.Equal(2, result.Fields.Count);
        Assert.Contains("Front", result.Fields);
        Assert.Equal("front content", result.Fields["Front"].Value);
        Assert.Equal(0, result.Fields["Front"].Order);
        Assert.Contains("Back", result.Fields);
        Assert.Equal("back content", result.Fields["Back"].Value);
        Assert.Equal(1, result.Fields["Back"].Order);
        Assert.Equal("Forward", result.Template);
        Assert.Equal(1498938915662ul, result.CardId);
        Assert.Equal(3, result.Buttons.Count);
        Assert.Equal(1, result.Buttons[0]);
        Assert.Equal(2, result.Buttons[1]);
        Assert.Equal(3, result.Buttons[2]);
        Assert.Equal(3, result.NextReviews.Count);
        Assert.Equal("<1m", result.NextReviews[0]);
        Assert.Equal("<10m", result.NextReviews[1]);
        Assert.Equal("4d", result.NextReviews[2]);
    }

    [Fact]
    public async Task GuiStartCardTimerAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiStartCardTimerAsync();

        Handler.WasSent("{\"action\":\"guiStartCardTimer\",\"version\":6}");
    }

    [Fact]
    public async Task GuiStartCardTimerAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.GuiStartCardTimerAsync();

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task GuiShowQuestionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiShowQuestionAsync();

        Handler.WasSent("{\"action\":\"guiShowQuestion\",\"version\":6}");
    }

    [Fact]
    public async Task GuiShowQuestionAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.GuiShowQuestionAsync();

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task GuiShowAnswerAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiShowAnswerAsync();

        Handler.WasSent("{\"action\":\"guiShowAnswer\",\"version\":6}");
    }

    [Fact]
    public async Task GuiShowAnswerAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.GuiShowAnswerAsync();

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task GuiDeckBrowserAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiDeckBrowserAsync();

        Handler.WasSent("{\"action\":\"guiDeckBrowser\",\"version\":6}");
    }

    [Fact]
    public async Task GuiDeckBrowserAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.GuiDeckBrowserAsync();
    }

    [Fact]
    public async Task GuiExitAnkiAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiExitAnkiAsync();

        Handler.WasSent("{\"action\":\"guiExitAnki\",\"version\":6}");
    }

    [Fact]
    public async Task GuiExitAnkiAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.GuiExitAnkiAsync();
    }

    [Fact]
    public async Task GuiCheckDatabaseAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiCheckDatabaseAsync();

        Handler.WasSent("{\"action\":\"guiCheckDatabase\",\"version\":6}");
    }

    [Fact]
    public async Task GuiCheckDatabaseAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        // Does not throw
        await Target.GuiCheckDatabaseAsync();
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.RequestPermissionAsync();

        Handler.WasSent("{\"action\":\"requestPermission\",\"version\":6}");
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldParseResponse_WhenGranted()
    {
        Handler.Returns(@"{
    ""result"": {
        ""permission"": ""granted"",
        ""requireApiKey"": false,
        ""version"": 6
    },
    ""error"": null
}");

        var result = await Target.RequestPermissionAsync();

        Assert.NotNull(result);
        Assert.Equal("granted", result!.Permission);
        Assert.False(result.RequireApiKey);
        Assert.Equal(6, result.Version);
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldParseResponse_WhenDenied()
    {
        Handler.Returns(@"{
    ""result"": {
        ""permission"": ""denied""
    },
    ""error"": null
}");

        var result = await Target.RequestPermissionAsync();

        Assert.NotNull(result);
        Assert.Equal("denied", result!.Permission);
    }

    [Fact]
    public async Task VersionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.VersionAsync();

        Handler.WasSent("{\"action\":\"version\",\"version\":6}");
    }

    [Fact]
    public async Task VersionAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":6,\"error\":null}");

        var result = await Target.VersionAsync();

        Assert.NotNull(result);
        Assert.Equal(6, result);
    }

    [Fact]
    public async Task SyncAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SyncAsync();

        Handler.WasSent("{\"action\":\"sync\",\"version\":6}");
    }

    [Fact]
    public async Task SyncAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.SyncAsync();
    }

    [Fact]
    public async Task GetProfilesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetProfilesAsync();

        Handler.WasSent("{\"action\":\"getProfiles\",\"version\":6}");
    }

    [Fact]
    public async Task GetProfilesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"User 1\"],\"error\":null}");

        var result = await Target.GetProfilesAsync();

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Equal("User 1", result[0]);
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ReloadCollectionAsync();

        Handler.WasSent("{\"action\":\"reloadCollection\",\"version\":6}");
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.ReloadCollectionAsync();
    }

    [Fact]
    public async Task ModelNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ModelNamesAsync();

        Handler.WasSent("{\"action\":\"modelNames\",\"version\":6}");
    }

    [Fact]
    public async Task ModelNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"Basic\", \"Basic (and reversed card)\"],\"error\":null}");

        var result = await Target.ModelNamesAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal("Basic", result[0]);
        Assert.Equal("Basic (and reversed card)", result[1]);
    }

    [Fact]
    public async Task ModelNamesAndIdsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ModelNamesAndIdsAsync();

        Handler.WasSent("{\"action\":\"modelNamesAndIds\",\"version\":6}");
    }

    [Fact]
    public async Task ModelNamesAndIdsAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": {
        ""Basic"": 1483883011648,
        ""Basic (and reversed card)"": 1483883011644,
        ""Basic (optional reversed card)"": 1483883011631,
        ""Cloze"": 1483883011630
    },
    ""error"": null
}");

        var result = await Target.ModelNamesAndIdsAsync();

        Assert.NotNull(result);
        Assert.Equal(4, result!.Count);
        Assert.Contains("Basic", result);
        Assert.Equal(1483883011648ul, result["Basic"]);
        Assert.Contains("Basic (and reversed card)", result);
        Assert.Equal(1483883011644ul, result["Basic (and reversed card)"]);
        Assert.Contains("Basic (optional reversed card)", result);
        Assert.Equal(1483883011631ul, result["Basic (optional reversed card)"]);
        Assert.Contains("Cloze", result);
        Assert.Equal(1483883011630ul, result["Cloze"]);
    }

    [Fact]
    public async Task GetTagsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetTagsAsync();

        Handler.WasSent("{\"action\":\"getTags\",\"version\":6}");
    }

    [Fact]
    public async Task GetTagsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"european-languages\", \"idioms\"],\"error\":null}");

        var result = await Target.GetTagsAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal("european-languages", result[0]);
        Assert.Equal("idioms", result[1]);
    }

    [Fact]
    public async Task ClearUnusedTagsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ClearUnusedTagsAsync();

        Handler.WasSent("{\"action\":\"clearUnusedTags\",\"version\":6}");
    }

    [Fact]
    public async Task ClearUnusedTagsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.ClearUnusedTagsAsync();
    }

    [Fact]
    public async Task RemoveEmptyNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.RemoveEmptyNotesAsync();

        Handler.WasSent("{\"action\":\"removeEmptyNotes\",\"version\":6}");
    }

    [Fact]
    public async Task RemoveEmptyNotesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.RemoveEmptyNotesAsync();
    }

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetNumCardsReviewedTodayAsync();

        Handler.WasSent("{\"action\":\"getNumCardsReviewedToday\",\"version\":6}");
    }

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":6,\"error\":null}");

        var result = await Target.GetNumCardsReviewedTodayAsync();

        Assert.NotNull(result);
        Assert.Equal(6, result);
    }
}
