using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AnkiConnect.Net.Models;
using Moq;
using Xunit;

namespace AnkiConnect.Net.Tests;

public class AnkiClientTests
{
    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GetEaseFactorsAsync(new GetEaseFactorsParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        mockHandler.WasSent(Regex.Replace(@"{
    ""action"": ""getEaseFactors"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":[4100, 3900],\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.GetEaseFactorsAsync(new GetEaseFactorsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(4100, result[0]);
        Assert.Equal(3900, result[1]);
    }

    [Fact]
    public async Task GetEaseFactorsAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GetEaseFactorsAsync(new GetEaseFactorsParams()));
    }

    [Fact]
    public async Task GetEaseFactorsAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GetEaseFactorsAsync(new GetEaseFactorsParams()));
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.SetEaseFactorsAsync(new SetEaseFactorsParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul},
            EaseFactors = new[] {4100, 3900}
        });

        mockHandler.WasSent(Regex.Replace(@"{
    ""action"": ""setEaseFactors"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217],
        ""easeFactors"": [4100, 3900]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":[true, true],\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.SetEaseFactorsAsync(new SetEaseFactorsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(true, result[0]);
        Assert.Equal(true, result[1]);
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SetEaseFactorsAsync(new SetEaseFactorsParams()));
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SetEaseFactorsAsync(new SetEaseFactorsParams()));
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams
        {
            Card = 1483959291685ul,
            Keys = new[] {"flags", "odue"},
            NewValues = new[] {"1", "-100"}
        });

        mockHandler.WasSent(Regex.Replace(@"{
    ""action"": ""setSpecificValueOfCard"",
    ""version"": 6,
    ""params"": {
        ""card"": 1483959291685,
        ""keys"": [""flags"", ""odue""],
        ""newValues"": [""1"", ""-100""]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":[true, true],\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(true, result[0]);
        Assert.Equal(true, result[1]);
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams()));
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams()));
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.SuspendAsync(new SuspendParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        mockHandler.WasSent(Regex.Replace(@"{
    ""action"": ""suspend"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":true,\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.SuspendAsync(new SuspendParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task SuspendAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SuspendAsync(new SuspendParams()));
    }

    [Fact]
    public async Task SuspendAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SuspendAsync(new SuspendParams()));
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.UnsuspendAsync(new UnsuspendParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        mockHandler.WasSent(Regex.Replace(@"{
    ""action"": ""unsuspend"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":true,\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.UnsuspendAsync(new UnsuspendParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.UnsuspendAsync(new UnsuspendParams()));
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.UnsuspendAsync(new UnsuspendParams()));
    }

    [Fact]
    public async Task SuspendedAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.SuspendedAsync(new SuspendedParams
        {
            Card = 1483959293217ul
        });

        mockHandler.WasSent(Regex.Replace(@"{
    ""action"": ""suspended"",
    ""version"": 6,
    ""params"": {
        ""card"": 1483959293217
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task SuspendedAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":true,\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.SuspendedAsync(new SuspendedParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task SuspendedAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SuspendedAsync(new SuspendedParams()));
    }

    [Fact]
    public async Task SuspendedAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SuspendedAsync(new SuspendedParams()));
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.AreSuspendedAsync(new AreSuspendedParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul, 1234567891234ul}
        });

        mockHandler.WasSent(Regex.Replace(@"{
    ""action"": ""areSuspended"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217, 1234567891234]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":[false, true, null],\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.AreSuspendedAsync(new AreSuspendedParams());

        Assert.NotNull(result);
        Assert.Equal(3, result!.Count);
        Assert.False(result[0]);
        Assert.True(result[1]);
        Assert.Null(result[2]);
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.AreSuspendedAsync(new AreSuspendedParams()));
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.AreSuspendedAsync(new AreSuspendedParams()));
    }

    [Fact]
    public async Task DeckNamesAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.DeckNamesAsync();

        mockHandler.WasSent("{\"action\":\"deckNames\",\"version\":6}");
    }

    [Fact]
    public async Task DeckNamesAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":[\"Default\"],\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.DeckNamesAsync();

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Equal("Default", result[0]);
    }

    [Fact]
    public async Task DeckNamesAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.DeckNamesAsync());
    }

    [Fact]
    public async Task DeckNamesAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.DeckNamesAsync());
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.DeckNamesAndIdsAsync();

        mockHandler.WasSent("{\"action\":\"deckNamesAndIds\",\"version\":6}");
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":{\"Default\":1},\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.DeckNamesAndIdsAsync();

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Contains("Default", result);
        Assert.Equal(1, result["Default"]);
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.DeckNamesAndIdsAsync());
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.DeckNamesAndIdsAsync());
    }

    [Fact]
    public async Task GuiCurrentCardAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GuiCurrentCardAsync();

        mockHandler.WasSent("{\"action\":\"guiCurrentCard\",\"version\":6}");
    }

    [Fact]
    public async Task GuiCurrentCardAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(@"{
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
        var client = GetClient(mockHandler);

        var result = await client.GuiCurrentCardAsync();

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
    public async Task GuiCurrentCardAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiCurrentCardAsync());
    }

    [Fact]
    public async Task GuiCurrentCardAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiCurrentCardAsync());
    }

    [Fact]
    public async Task GuiStartCardTimerAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GuiStartCardTimerAsync();

        mockHandler.WasSent("{\"action\":\"guiStartCardTimer\",\"version\":6}");
    }

    [Fact]
    public async Task GuiStartCardTimerAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":true,\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.GuiStartCardTimerAsync();

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task GuiStartCardTimerAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiStartCardTimerAsync());
    }

    [Fact]
    public async Task GuiStartCardTimerAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiStartCardTimerAsync());
    }

    [Fact]
    public async Task GuiShowQuestionAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GuiShowQuestionAsync();

        mockHandler.WasSent("{\"action\":\"guiShowQuestion\",\"version\":6}");
    }

    [Fact]
    public async Task GuiShowQuestionAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":true,\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.GuiShowQuestionAsync();

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task GuiShowQuestionAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiShowQuestionAsync());
    }

    [Fact]
    public async Task GuiShowQuestionAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiShowQuestionAsync());
    }

    [Fact]
    public async Task GuiShowAnswerAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GuiShowAnswerAsync();

        mockHandler.WasSent("{\"action\":\"guiShowAnswer\",\"version\":6}");
    }

    [Fact]
    public async Task GuiShowAnswerAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":true,\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.GuiShowAnswerAsync();

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task GuiShowAnswerAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiShowAnswerAsync());
    }

    [Fact]
    public async Task GuiShowAnswerAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiShowAnswerAsync());
    }

    [Fact]
    public async Task GuiDeckBrowserAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GuiDeckBrowserAsync();

        mockHandler.WasSent("{\"action\":\"guiDeckBrowser\",\"version\":6}");
    }

    [Fact]
    public async Task GuiDeckBrowserAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":null,\"error\":null}");
        var client = GetClient(mockHandler);

        // Does not throw
        await client.GuiDeckBrowserAsync();
    }

    [Fact]
    public async Task GuiDeckBrowserAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiDeckBrowserAsync());
    }

    [Fact]
    public async Task GuiDeckBrowserAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiDeckBrowserAsync());
    }

    [Fact]
    public async Task GuiExitAnkiAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GuiExitAnkiAsync();

        mockHandler.WasSent("{\"action\":\"guiExitAnki\",\"version\":6}");
    }

    [Fact]
    public async Task GuiExitAnkiAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":null,\"error\":null}");
        var client = GetClient(mockHandler);

        // Does not throw
        await client.GuiExitAnkiAsync();
    }

    [Fact]
    public async Task GuiExitAnkiAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiExitAnkiAsync());
    }

    [Fact]
    public async Task GuiExitAnkiAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiExitAnkiAsync());
    }

    [Fact]
    public async Task GuiCheckDatabaseAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GuiCheckDatabaseAsync();

        mockHandler.WasSent("{\"action\":\"guiCheckDatabase\",\"version\":6}");
    }

    [Fact]
    public async Task GuiCheckDatabaseAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":true,\"error\":null}");
        var client = GetClient(mockHandler);

        // Does not throw
        await client.GuiCheckDatabaseAsync();
    }

    [Fact]
    public async Task GuiCheckDatabaseAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiCheckDatabaseAsync());
    }

    [Fact]
    public async Task GuiCheckDatabaseAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GuiCheckDatabaseAsync());
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.RequestPermissionAsync();

        mockHandler.WasSent("{\"action\":\"requestPermission\",\"version\":6}");
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldParseResponse_WhenValid_Granted()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(@"{
    ""result"": {
        ""permission"": ""granted"",
        ""requireApiKey"": false,
        ""version"": 6
    },
    ""error"": null
}");
        var client = GetClient(mockHandler);

        var result = await client.RequestPermissionAsync();

        Assert.NotNull(result);
        Assert.Equal("granted", result!.Permission);
        Assert.False(result.RequireApiKey);
        Assert.Equal(6, result.Version);
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldParseResponse_WhenValid_Denied()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(@"{
    ""result"": {
        ""permission"": ""denied""
    },
    ""error"": null
}");
        var client = GetClient(mockHandler);

        var result = await client.RequestPermissionAsync();

        Assert.NotNull(result);
        Assert.Equal("denied", result!.Permission);
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.RequestPermissionAsync());
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.RequestPermissionAsync());
    }

    [Fact]
    public async Task VersionAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.VersionAsync();

        mockHandler.WasSent("{\"action\":\"version\",\"version\":6}");
    }

    [Fact]
    public async Task VersionAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":6,\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.VersionAsync();

        Assert.NotNull(result);
        Assert.Equal(6, result);
    }

    [Fact]
    public async Task VersionAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.VersionAsync());
    }

    [Fact]
    public async Task VersionAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.VersionAsync());
    }

    [Fact]
    public async Task SyncAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.SyncAsync();

        mockHandler.WasSent("{\"action\":\"sync\",\"version\":6}");
    }

    [Fact]
    public async Task SyncAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":null,\"error\":null}");
        var client = GetClient(mockHandler);

        // Does not throw
        await client.SyncAsync();
    }

    [Fact]
    public async Task SyncAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SyncAsync());
    }

    [Fact]
    public async Task SyncAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.SyncAsync());
    }

    [Fact]
    public async Task GetProfilesAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GetProfilesAsync();

        mockHandler.WasSent("{\"action\":\"getProfiles\",\"version\":6}");
    }

    [Fact]
    public async Task GetProfilesAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":[\"User 1\"],\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.GetProfilesAsync();

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Equal("User 1", result[0]);
    }

    [Fact]
    public async Task GetProfilesAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GetProfilesAsync());
    }

    [Fact]
    public async Task GetProfilesAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GetProfilesAsync());
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.ReloadCollectionAsync();

        mockHandler.WasSent("{\"action\":\"reloadCollection\",\"version\":6}");
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":null,\"error\":null}");
        var client = GetClient(mockHandler);

        // Does not throw
        await client.ReloadCollectionAsync();
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.ReloadCollectionAsync());
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.ReloadCollectionAsync());
    }

    [Fact]
    public async Task ModelNamesAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.ModelNamesAsync();

        mockHandler.WasSent("{\"action\":\"modelNames\",\"version\":6}");
    }

    [Fact]
    public async Task ModelNamesAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":[\"Basic\", \"Basic (and reversed card)\"],\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.ModelNamesAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal("Basic", result[0]);
        Assert.Equal("Basic (and reversed card)", result[1]);
    }

    [Fact]
    public async Task ModelNamesAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.ModelNamesAsync());
    }

    [Fact]
    public async Task ModelNamesAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.ModelNamesAsync());
    }

    [Fact]
    public async Task ModelNamesAndIdsAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.ModelNamesAndIdsAsync();

        mockHandler.WasSent("{\"action\":\"modelNamesAndIds\",\"version\":6}");
    }

    [Fact]
    public async Task ModelNamesAndIdsAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(@"{
    ""result"": {
        ""Basic"": 1483883011648,
        ""Basic (and reversed card)"": 1483883011644,
        ""Basic (optional reversed card)"": 1483883011631,
        ""Cloze"": 1483883011630
    },
    ""error"": null
}");
        var client = GetClient(mockHandler);

        var result = await client.ModelNamesAndIdsAsync();

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
    public async Task ModelNamesAndIdsAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.ModelNamesAndIdsAsync());
    }

    [Fact]
    public async Task ModelNamesAndIdsAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.ModelNamesAndIdsAsync());
    }

    [Fact]
    public async Task GetTagsAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GetTagsAsync();

        mockHandler.WasSent("{\"action\":\"getTags\",\"version\":6}");
    }

    [Fact]
    public async Task GetTagsAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":[\"european-languages\", \"idioms\"],\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.GetTagsAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal("european-languages", result[0]);
        Assert.Equal("idioms", result[1]);
    }

    [Fact]
    public async Task GetTagsAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GetTagsAsync());
    }

    [Fact]
    public async Task GetTagsAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GetTagsAsync());
    }

    [Fact]
    public async Task ClearUnusedTagsAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.ClearUnusedTagsAsync();

        mockHandler.WasSent("{\"action\":\"clearUnusedTags\",\"version\":6}");
    }

    [Fact]
    public async Task ClearUnusedTagsAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":null,\"error\":null}");
        var client = GetClient(mockHandler);

        // Does not throw
        await client.ClearUnusedTagsAsync();
    }

    [Fact]
    public async Task ClearUnusedTagsAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.ClearUnusedTagsAsync());
    }

    [Fact]
    public async Task ClearUnusedTagsAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.ClearUnusedTagsAsync());
    }

    [Fact]
    public async Task RemoveEmptyNotesAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.RemoveEmptyNotesAsync();

        mockHandler.WasSent("{\"action\":\"removeEmptyNotes\",\"version\":6}");
    }

    [Fact]
    public async Task RemoveEmptyNotesAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":null,\"error\":null}");
        var client = GetClient(mockHandler);

        // Does not throw
        await client.RemoveEmptyNotesAsync();
    }

    [Fact]
    public async Task RemoveEmptyNotesAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.RemoveEmptyNotesAsync());
    }

    [Fact]
    public async Task RemoveEmptyNotesAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.RemoveEmptyNotesAsync());
    }

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseRequest()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{}");
        var client = GetClient(mockHandler);

        await client.GetNumCardsReviewedTodayAsync();

        mockHandler.WasSent("{\"action\":\"getNumCardsReviewedToday\",\"version\":6}");
    }

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseResponse_WhenValid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("{\"result\":6,\"error\":null}");
        var client = GetClient(mockHandler);

        var result = await client.GetNumCardsReviewedTodayAsync();

        Assert.NotNull(result);
        Assert.Equal(6, result);
    }

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldThrow_WhenResponseInvalid()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns("Hello, world");
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GetNumCardsReviewedTodayAsync());
    }

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldThrow_WhenResponseError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient(mockHandler);

        await Assert.ThrowsAsync<AnkiException>(() => client.GetNumCardsReviewedTodayAsync());
    }

    // TODO: GetNumCardsReviewedByDay Tests

    private static IAnkiClient GetClient(IMock<HttpMessageHandler> mockHandler)
    {
        var client = new HttpClient(mockHandler.Object);
        var anki = new AnkiClient(client);
        return anki;
    }
}
