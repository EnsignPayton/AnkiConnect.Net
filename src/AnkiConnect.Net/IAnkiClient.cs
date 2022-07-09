using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiClient
{
    Task<IList<string>?> DeckNamesAsync();
    Task<IDictionary<string, int>?> DeckNamesAndIdsAsync();
    Task<GuiCurrentCardResult?> GuiCurrentCardAsync();
    Task<bool?> GuiStartCardTimerAsync();
    Task<bool?> GuiShowQuestionAsync();
    Task<bool?> GuiShowAnswerAsync();
}
