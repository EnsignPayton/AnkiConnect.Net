using System.Text;
using System.Text.Json;

namespace AnkiConnect.Net.Internal;

internal class InternalAnkiClient
{
    private const string DefaultUrl = "http://127.0.0.1:8765";

    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        Converters = { new StoreMediaFileParamsConverter() }
    };

    public InternalAnkiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task InvokeAsync(string action)
    {
        try
        {
            var request = new AnkiRequest(action);
            var response = await InvokeAsync(request);
            HandleResponse(response);
        }
        catch (AnkiException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AnkiException(ex);
        }
    }

    public async Task<TResult?> InvokeAsync<TResult>(string action)
    {
        try
        {
            var request = new AnkiRequest(action);
            var response = await InvokeAsync(request);
            return HandleResponse<TResult>(response);
        }
        catch (AnkiException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AnkiException(ex);
        }
    }

    public async Task InvokeAsync<TParams>(string action, TParams value) where TParams : class
    {
        try
        {
            var request = new AnkiRequest<TParams>(action, value);
            var response = await InvokeAsync(request);
            HandleResponse(response);
        }
        catch (AnkiException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AnkiException(ex);
        }
    }

    public async Task<TResult?> InvokeAsync<TParams, TResult>(string action, TParams value) where TParams : class
    {
        try
        {
            var request = new AnkiRequest<TParams>(action, value);
            var response = await InvokeAsync(request);
            return HandleResponse<TResult>(response);
        }
        catch (AnkiException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new AnkiException(ex);
        }
    }

    private async Task<string> InvokeAsync<T>(T request)
    {
        var json = JsonSerializer.Serialize(request, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var message = await _httpClient.PostAsync(DefaultUrl, content);
        message.EnsureSuccessStatusCode();
        return await message.Content.ReadAsStringAsync();
    }

    private static void HandleResponse(string json)
    {
        var response = JsonSerializer.Deserialize<AnkiResponse>(json);
        ThrowIfNullResponse(response);
        ThrowIfErrorResponse(response!);
    }

    private static TResult? HandleResponse<TResult>(string json)
    {
        var response = JsonSerializer.Deserialize<AnkiResponse<TResult>>(json);
        ThrowIfNullResponse(response);
        ThrowIfErrorResponse(response!);
        return response!.Result;
    }

    private static void ThrowIfNullResponse(AnkiResponse? response)
    {
        if (response is null)
            throw new AnkiException("Response was null");
    }

    private static void ThrowIfErrorResponse(AnkiResponse response)
    {
        if (!string.IsNullOrEmpty(response.Error))
            throw new AnkiException(response.Error);
    }
}
