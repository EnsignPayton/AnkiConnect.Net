using System;
using System.Net.Http;

namespace AnkiConnect.Net;

public abstract class AnkiClientTestsBase<T> where T : class
{
    protected readonly MockHandler Handler = new();

    protected T Target => GetTarget();

    private T GetTarget()
    {
        var httpClient = new HttpClient(Handler);
        return new AnkiClient(httpClient) as T ?? throw new InvalidOperationException();
    }
}
