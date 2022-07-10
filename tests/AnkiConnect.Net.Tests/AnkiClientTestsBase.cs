﻿using System;
using System.Net.Http;
using Moq;

namespace AnkiConnect.Net;

public abstract class AnkiClientTestsBase<T> where T : class
{
    protected readonly Mock<HttpMessageHandler> Handler = new();

    protected T Target => GetTarget();

    private T GetTarget()
    {
        var httpClient = new HttpClient(Handler.Object);
        return new AnkiClient(httpClient) as T ?? throw new InvalidOperationException();
    }
}
