using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiGui
{
    /// <summary>
    /// Invokes the CardBrowser dialog and searches for a given query
    /// </summary>
    /// <remarks>
    /// Query syntax is documented at https://docs.ankiweb.net/searching.html
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>An array of identifier of the cards that were found</returns>
    Task<IList<ulong>?> GuiBrowseAsync(QueryParams value);

    /// <summary>
    /// Finds the open instance of the Card Browser dialog and returns an array of identifiers of the notes that are
    /// selected. Returns an empty list of the browser is not open.
    /// </summary>
    /// <returns>Selected note ids</returns>
    Task<IList<ulong>?> GuiSelectedNotesAsync();
}
