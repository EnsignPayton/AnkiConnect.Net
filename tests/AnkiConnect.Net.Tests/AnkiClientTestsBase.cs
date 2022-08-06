using VerifyTests.Http;

namespace AnkiConnect.Net;

public abstract class AnkiClientTestsBase<T> where T : class
{
    private readonly RecordingHandler _recording;
    private readonly VerifySettings _settings = new();

    protected readonly MockHandler Handler = new();

    protected AnkiClientTestsBase()
    {
        _settings.UseDirectory("Data");
        _recording = new RecordingHandler {InnerHandler = Handler};
    }

    protected async Task VerifyRequest() =>
        await Verify(_recording.Sends, _settings);

    protected async Task VerifyResponse<TResult>(TResult result) =>
        await Verify(result, _settings);

    protected T Target => GetTarget();

    private T GetTarget()
    {
        var httpClient = new HttpClient(_recording);
        return new AnkiClient(httpClient) as T ?? throw new InvalidOperationException();
    }
}
