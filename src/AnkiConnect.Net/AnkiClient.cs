using System.Text;
using System.Text.Json;
using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiClient : IAnkiClient
{
    private const string DefaultUrl = "http://localhost:8765";

    private readonly HttpClient _client;

    public AnkiClient(HttpClient client)
    {
        _client = client;
    }

    private async Task<TResult?> InvokeAsync<TResult>(string action)
    {
        try
        {
            var request = new AnkiRequest
            {
                Action = action
            };

            var requestJson = JsonSerializer.Serialize(request);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var message = await _client.PostAsync(DefaultUrl, requestContent);
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

    public async Task<IList<string>?> DeckNamesAsync()
    {
        return await InvokeAsync<IList<string>>(AnkiMethods.DeckNames);
    }

    public async Task<IDictionary<string, int>?> DeckNamesAndIdsAsync()
    {
        return await InvokeAsync<IDictionary<string, int>>(AnkiMethods.DeckNamesAndIds);
    }

    public async Task<GuiCurrentCardResult?> GuiCurrentCardAsync()
    {
        return await InvokeAsync<GuiCurrentCardResult>(AnkiMethods.GuiCurrentCard);
    }

    public async Task<bool?> GuiStartCardTimerAsync()
    {
        return await InvokeAsync<bool>(AnkiMethods.GuiStartCardTimer);
    }

    public async Task<bool?> GuiShowQuestionAsync()
    {
        return await InvokeAsync<bool>(AnkiMethods.GuiShowQuestion);
    }

    public async Task<bool?> GuiShowAnswerAsync()
    {
        return await InvokeAsync<bool>(AnkiMethods.GuiShowAnswer);
    }
}
