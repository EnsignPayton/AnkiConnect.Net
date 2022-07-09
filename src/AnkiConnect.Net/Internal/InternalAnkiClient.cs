using System.Text;
using System.Text.Json;

namespace AnkiConnect.Net.Internal;

internal class InternalAnkiClient
{
    private const string DefaultUrl = "http://localhost:8765";

    private readonly HttpClient _httpClient;

    public InternalAnkiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TResult?> InvokeAsync<TResult>(string action)
    {
        try
        {
            var request = new AnkiRequest
            {
                Action = action
            };

            var requestJson = JsonSerializer.Serialize(request);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var message = await _httpClient.PostAsync(DefaultUrl, requestContent);
            message.EnsureSuccessStatusCode();
            var responseJson = await message.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<AnkiResponse<TResult>>(responseJson);
            if (response is null)
                throw new AnkiException("Response was null");
            if (!string.IsNullOrEmpty(response.Error))
                throw new AnkiException(response.Error);
            return response.Result;
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

    public async Task InvokeAsync(string action)
    {
        try
        {
            var request = new AnkiRequest
            {
                Action = action
            };

            var requestJson = JsonSerializer.Serialize(request);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var message = await _httpClient.PostAsync(DefaultUrl, requestContent);
            message.EnsureSuccessStatusCode();
            var responseJson = await message.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<AnkiResponse>(responseJson);
            if (response is null)
                throw new AnkiException("Response was null");
            if (!string.IsNullOrEmpty(response.Error))
                throw new AnkiException(response.Error);
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
}
