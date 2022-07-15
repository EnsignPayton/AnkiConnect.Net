using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiGuiTests : AnkiClientTestsBase<IAnkiGui>
{
    [Fact]
    public async Task GuiBrowseAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiBrowseAsync("deck:current");

        Handler.WasSent(@"{
    ""action"": ""guiBrowse"",
    ""version"": 6,
    ""params"": {
        ""query"": ""deck:current""
    }
}");
    }

    [Fact]
    public async Task GuiBrowseAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1494723142483, 1494703460437, 1494703479525],
    ""error"": null
}");

        var result = await Target.GuiBrowseAsync("");

        Assert.NotNull(result);
        Assert.Equal(3, result!.Count);
        Assert.Equal(1494723142483ul, result[0]);
        Assert.Equal(1494703460437ul, result[1]);
        Assert.Equal(1494703479525ul, result[2]);
    }

    [Fact]
    public async Task GuiSelectedNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiSelectedNotesAsync();

        Handler.WasSent("{\"action\":\"guiSelectedNotes\",\"version\":6}");
    }

    [Fact]
    public async Task GuiSelectedNotesAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1494723142483, 1494703460437, 1494703479525],
    ""error"": null
}");

        var result = await Target.GuiSelectedNotesAsync();

        Assert.NotNull(result);
        Assert.Equal(3, result!.Count);
        Assert.Equal(1494723142483ul, result[0]);
        Assert.Equal(1494703460437ul, result[1]);
        Assert.Equal(1494703479525ul, result[2]);
    }

    [Fact(Skip = "Method does not exist yet")]
    public async Task GuiAddCardsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Task.CompletedTask;
    }

    [Fact(Skip = "Method does not exist yet")]
    public async Task GuiAddCardsAsync_ShouldParseResponse()
    {
        await Task.CompletedTask;
    }

    [Fact]
    public async Task GuiEditNoteAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiEditNoteAsync(1649198355435ul);

        Handler.WasSent(@"{
    ""action"": ""guiEditNote"",
    ""version"": 6,
    ""params"": {
        ""note"": 1649198355435
    }
}");
    }

    [Fact]
    public async Task GuiEditNoteAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.GuiEditNoteAsync(new NoteParams());
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
    public async Task GuiCurrentCardAsync_ShouldParseResponse_WhenNull()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        var result = await Target.GuiCurrentCardAsync();

        Assert.Null(result);
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
    public async Task GuiAnswerCardAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiAnswerCardAsync(1);

        Handler.WasSent(@"{
    ""action"": ""guiAnswerCard"",
    ""version"": 6,
    ""params"": {
        ""ease"": 1
    }
}");
    }

    [Fact]
    public async Task GuiAnswerCardAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.GuiAnswerCardAsync(0);

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task GuiDeckOverviewAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiDeckOverviewAsync("Default");

        Handler.WasSent(@"{
    ""action"": ""guiDeckOverview"",
    ""version"": 6,
    ""params"": {
        ""name"": ""Default""
    }
}");
    }

    [Fact]
    public async Task GuiDeckOverviewAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.GuiDeckOverviewAsync(new DeckNameParams());

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
    public async Task GuiDeckReviewAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiDeckReviewAsync("Default");

        Handler.WasSent(@"{
    ""action"": ""guiDeckReview"",
    ""version"": 6,
    ""params"": {
        ""name"": ""Default""
    }
}");
    }

    [Fact]
    public async Task GuiDeckReviewAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.GuiDeckReviewAsync(new DeckNameParams());

        Assert.NotNull(result);
        Assert.True(result);
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
}
