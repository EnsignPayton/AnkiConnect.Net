using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AnkiConnect.Net.Models;
using Moq;
using Xunit;

namespace AnkiConnect.Net.Internal;

public class InternalAnkiClientTests
{
    private static Field Field => new() {Value = "Foo", Order = 0};

    [Fact]
    public async Task InvokeAsync_NoInput_NoOutput_ShouldSendExpectedText()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns("{}");

        await ankiClient.InvokeAsync("someAction");

        mockHandler.WasSent(@"{
    ""action"": ""someAction"",
    ""version"": 6
}");
    }

    [Fact]
    public async Task InvokeAsync_NoInput_NoOutput_ShouldThrow_WhenResponseNotValidJson()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns("NOT JSON");

        await Assert.ThrowsAsync<AnkiException>(() => ankiClient.InvokeAsync("someAction"));
    }

    [Fact]
    public async Task InvokeAsync_NoInput_NoOutput_ShouldThrow_WhenResponseIsHttpError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns(HttpStatusCode.InternalServerError);

        await Assert.ThrowsAsync<AnkiException>(() => ankiClient.InvokeAsync("someAction"));
    }

    [Fact]
    public async Task InvokeAsync_NoInput_NoOutput_ShouldThrow_WhenResponseHasAnkiError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns("{\"result\":null,\"error\":\"Anki Error Text\"}");

        var ex = await Assert.ThrowsAsync<AnkiException>(() => ankiClient.InvokeAsync("someAction"));

        Assert.Equal("Anki Error Text", ex.Message);
    }

    [Fact]
    public async Task InvokeAsync_NoInput_SomeOutput_ShouldSendExpectedText()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns("{}");

        await ankiClient.InvokeAsync<int>("someAction");

        mockHandler.WasSent(@"{
    ""action"": ""someAction"",
    ""version"": 6
}");
    }

    [Fact]
    public async Task InvokeAsync_NoInput_SomeOutput_ShouldThrow_WhenResponseNotValidJson()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns("NOT JSON");

        await Assert.ThrowsAsync<AnkiException>(() => ankiClient.InvokeAsync<int>("someAction"));
    }

    [Fact]
    public async Task InvokeAsync_NoInput_SomeOutput_ShouldThrow_WhenResponseIsHttpError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns(HttpStatusCode.InternalServerError);

        await Assert.ThrowsAsync<AnkiException>(() => ankiClient.InvokeAsync<int>("someAction"));
    }

    [Fact]
    public async Task InvokeAsync_NoInput_SomeOutput_ShouldThrow_WhenResponseHasAnkiError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns("{\"result\":0,\"error\":\"Anki Error Text\"}");

        var ex = await Assert.ThrowsAsync<AnkiException>(() => ankiClient.InvokeAsync<int>("someAction"));

        Assert.Equal("Anki Error Text", ex.Message);
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_SomeOutput_ShouldSendExpectedText()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns("{}");

        await ankiClient.InvokeAsync<Field, int>("someAction", Field);

        mockHandler.WasSent(@"{
    ""action"": ""someAction"",
    ""version"": 6,
    ""params"": {
        ""value"": ""Foo"",
        ""order"": 0
    }
}");
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_SomeOutput_ShouldThrow_WhenResponseNotValidJson()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns("NOT JSON");

        await Assert.ThrowsAsync<AnkiException>(() => ankiClient.InvokeAsync<Field, int>("someAction", Field));
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_SomeOutput_ShouldThrow_WhenResponseIsHttpError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns(HttpStatusCode.InternalServerError);

        await Assert.ThrowsAsync<AnkiException>(() => ankiClient.InvokeAsync<Field, int>("someAction", Field));
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_SomeOutput_ShouldThrow_WhenResponseHasAnkiError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(mockHandler.Object);
        var ankiClient = new InternalAnkiClient(httpClient);

        mockHandler.Returns("{\"result\":0,\"error\":\"Anki Error Text\"}");

        var ex = await Assert.ThrowsAsync<AnkiException>(() => ankiClient.InvokeAsync<Field, int>("someAction", Field));

        Assert.Equal("Anki Error Text", ex.Message);
    }
}
