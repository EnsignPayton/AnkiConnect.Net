using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace AnkiConnect.Net.Tests;

public class AnkiClientTests
{
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

    private static IAnkiClient GetClient(IMock<HttpMessageHandler> mockHandler)
    {
        var client = new HttpClient(mockHandler.Object);
        var anki = new AnkiClient(client);
        return anki;
    }
}
