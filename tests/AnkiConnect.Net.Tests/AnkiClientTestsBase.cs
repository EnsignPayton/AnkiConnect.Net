using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace AnkiConnect.Net.Tests;

public abstract class AnkiClientTestsBase<T> where T : class
{
    protected readonly Mock<HttpMessageHandler> Handler = new();

    protected T GetClient()
    {
        var httpClient = new HttpClient(Handler.Object);
        return new AnkiClient(httpClient) as T ?? throw new InvalidOperationException();
    }

    protected async Task AssertThrowsOnResponseInvalid(Func<T, Task> fn)
    {
        Handler.Returns("Hello, world");
        var client = GetClient();

        await Assert.ThrowsAsync<AnkiException>(() => fn(client));
    }

    protected async Task AssertThrowsOnResponseError(Func<T, Task> fn)
    {
        Handler.Returns(HttpStatusCode.InternalServerError);
        var client = GetClient();

        await Assert.ThrowsAsync<AnkiException>(() => fn(client));
    }
}
