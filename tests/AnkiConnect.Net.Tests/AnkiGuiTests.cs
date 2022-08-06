using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

[UsesVerify]
public class AnkiGuiTests : AnkiClientTestsBase<IAnkiGui>
{
    [Fact]
    public async Task GuiBrowseAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GuiBrowseAsync("deck:current");
        await VerifyRequest();
    }

    [Fact]
    public async Task GuiBrowseAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1494723142483, 1494703460437, 1494703479525],
    ""error"": null
}");

        var result = await Target.GuiBrowseAsync("");
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GuiSelectedNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GuiSelectedNotesAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task GuiSelectedNotesAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1494723142483, 1494703460437, 1494703479525],
    ""error"": null
}");

        var result = await Target.GuiSelectedNotesAsync();
        await VerifyResponse(result);
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
        await VerifyRequest();
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
        await VerifyRequest();
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
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GuiCurrentCardAsync_ShouldParseResponse_WhenNull()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");
        var result = await Target.GuiCurrentCardAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GuiStartCardTimerAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GuiStartCardTimerAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task GuiStartCardTimerAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.GuiStartCardTimerAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GuiShowQuestionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GuiShowQuestionAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task GuiShowQuestionAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.GuiShowQuestionAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GuiShowAnswerAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GuiShowAnswerAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task GuiShowAnswerAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.GuiShowAnswerAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GuiAnswerCardAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GuiAnswerCardAsync(1);
        await VerifyRequest();
    }

    [Fact]
    public async Task GuiAnswerCardAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.GuiAnswerCardAsync(0);
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GuiDeckOverviewAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GuiDeckOverviewAsync("Default");
        await VerifyRequest();
    }

    [Fact]
    public async Task GuiDeckOverviewAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.GuiDeckOverviewAsync(new DeckNameParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GuiDeckBrowserAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GuiDeckBrowserAsync();
        await VerifyRequest();
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
        await VerifyRequest();
    }

    [Fact]
    public async Task GuiDeckReviewAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.GuiDeckReviewAsync(new DeckNameParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GuiExitAnkiAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GuiExitAnkiAsync();
        await VerifyRequest();
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
        await VerifyRequest();
    }

    [Fact]
    public async Task GuiCheckDatabaseAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        // Does not throw
        await Target.GuiCheckDatabaseAsync();
    }
}
