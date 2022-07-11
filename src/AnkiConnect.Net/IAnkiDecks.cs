using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiDecks
{
    /// <summary>
    /// Gets the complete list of deck names for the current user
    /// </summary>
    /// <returns>The complete list of deck names for the current user</returns>
    Task<IList<string>?> DeckNamesAsync();

    /// <summary>
    /// Gets the complete list of deck names and their respective IDs for the current user
    /// </summary>
    /// <returns>The complete list of deck names and their respective IDs for the current user</returns>
    Task<IDictionary<string, int>?> DeckNamesAndIdsAsync();

    /// <summary>
    /// Accepts an array of card IDs and returns an object with each deck name as a key, and its value an array of
    /// the given cards which belong to it
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>
    /// An object with each deck name as a key, and its value an array of the given cards which belong to it
    /// </returns>
    Task<IDictionary<string, IList<ulong>>?> GetDecksAsync(CardsParams value);

    /// <summary>
    /// Create a new empty deck. Will not overwrite a deck the exists with the same name
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Deck ID</returns>
    Task<ulong?> CreateDeckAsync(DeckParams value);

    /// <summary>
    /// Moves cards with the given IDs to a different deck, creating the deck if it doesn't exist yet
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task ChangeDeckAsync(ChangeDeckParams value);

    /// <summary>
    /// Deletes decks with the given names
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task DeleteDecksAsync(DecksParams value);
}
