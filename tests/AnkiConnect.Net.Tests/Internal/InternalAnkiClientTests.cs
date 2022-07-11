using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AnkiConnect.Net.Models;
using Xunit;

namespace AnkiConnect.Net.Internal;

public class InternalAnkiClientTests
{
    private static Field Field => new() {Value = "Foo", Order = 0};

    private MockHandler Handler { get; } = new();
    private InternalAnkiClient Target => new(new HttpClient(Handler));

    [Fact]
    public async Task InvokeAsync_NoInput_NoOutput_ShouldSendExpectedText()
    {
        Handler.Returns("{}");

        await Target.InvokeAsync("someAction");

        Handler.WasSent(@"{
    ""action"": ""someAction"",
    ""version"": 6
}");
    }

    [Fact]
    public async Task InvokeAsync_NoInput_NoOutput_ShouldThrow_WhenResponseNotValidJson()
    {
        Handler.Returns("NOT JSON");

        await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync("someAction"));
    }

    [Fact]
    public async Task InvokeAsync_NoInput_NoOutput_ShouldThrow_WhenResponseIsHttpError()
    {
        Handler.Returns(HttpStatusCode.InternalServerError);

        await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync("someAction"));
    }

    [Fact]
    public async Task InvokeAsync_NoInput_NoOutput_ShouldThrow_WhenResponseHasAnkiError()
    {
        Handler.Returns("{\"result\":null,\"error\":\"Anki Error Text\"}");

        var ex = await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync("someAction"));

        Assert.Equal("Anki Error Text", ex.Message);
    }

    [Fact]
    public async Task InvokeAsync_NoInput_SomeOutput_ShouldSendExpectedText()
    {
        Handler.Returns("{}");

        await Target.InvokeAsync<int>("someAction");

        Handler.WasSent(@"{
    ""action"": ""someAction"",
    ""version"": 6
}");
    }

    [Fact]
    public async Task InvokeAsync_NoInput_SomeOutput_ShouldThrow_WhenResponseNotValidJson()
    {
        Handler.Returns("NOT JSON");

        await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync<int>("someAction"));
    }

    [Fact]
    public async Task InvokeAsync_NoInput_SomeOutput_ShouldThrow_WhenResponseIsHttpError()
    {
        Handler.Returns(HttpStatusCode.InternalServerError);

        await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync<int>("someAction"));
    }

    [Fact]
    public async Task InvokeAsync_NoInput_SomeOutput_ShouldThrow_WhenResponseHasAnkiError()
    {
        Handler.Returns("{\"result\":0,\"error\":\"Anki Error Text\"}");

        var ex = await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync<int>("someAction"));

        Assert.Equal("Anki Error Text", ex.Message);
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_NoOutput_ShouldSendExpectedText()
    {
        Handler.Returns("{}");

        await Target.InvokeAsync("someAction", Field);

        Handler.WasSent(@"{
    ""action"": ""someAction"",
    ""version"": 6,
    ""params"": {
        ""value"": ""Foo"",
        ""order"": 0
    }
}");
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_NoOutput_ShouldThrow_WhenResponseNotValidJson()
    {
        Handler.Returns("NOT JSON");

        await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync("someAction", Field));
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_NoOutput_ShouldThrow_WhenResponseIsHttpError()
    {
        Handler.Returns(HttpStatusCode.InternalServerError);

        await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync("someAction", Field));
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_NoOutput_ShouldThrow_WhenResponseHasAnkiError()
    {
        Handler.Returns("{\"result\":null,\"error\":\"Anki Error Text\"}");

        var ex = await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync("someAction", Field));

        Assert.Equal("Anki Error Text", ex.Message);
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_SomeOutput_ShouldSendExpectedText()
    {
        Handler.Returns("{}");

        await Target.InvokeAsync<Field, int>("someAction", Field);

        Handler.WasSent(@"{
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
        Handler.Returns("NOT JSON");

        await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync<Field, int>("someAction", Field));
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_SomeOutput_ShouldThrow_WhenResponseIsHttpError()
    {
        Handler.Returns(HttpStatusCode.InternalServerError);

        await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync<Field, int>("someAction", Field));
    }

    [Fact]
    public async Task InvokeAsync_SomeInput_SomeOutput_ShouldThrow_WhenResponseHasAnkiError()
    {
        Handler.Returns("{\"result\":0,\"error\":\"Anki Error Text\"}");

        var ex = await Assert.ThrowsAsync<AnkiException>(() => Target.InvokeAsync<Field, int>("someAction", Field));

        Assert.Equal("Anki Error Text", ex.Message);
    }
}
