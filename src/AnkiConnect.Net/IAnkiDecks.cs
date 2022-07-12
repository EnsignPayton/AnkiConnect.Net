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

    /// <summary>
    /// Gets the configuration group object for the given deck
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>The configuration group object for the given deck</returns>
    // TODO: Parse out to an object
    Task<object?> GetDeckConfigAsync(DeckParams value);

    /// <summary>
    /// Saves the given configuration group
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True on success or false if the ID of the configuration group is invalid</returns>
    // TODO: Take a sensible parameter. Should match the structure of GetDeckConfigAsync return value
    Task<bool?> SaveDeckConfigAsync(DeckParams value);

    /// <summary>
    /// Changes the configuration group for the given decks to the one with the given ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True on success or false if the given configuration group or any of the given decks do not exist</returns>
    Task<bool?> SetDeckConfigIdAsync(SetDeckConfigIdParams value);

    /// <summary>
    /// Creates a new configuration group with the given name, cloning from the group with the given ID, or from
    /// the default group if this is unspecified
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>The ID of the new configuration group, or false if the specified group to clone from does not exist</returns>
    // TODO: How the hell does one represent a ulong / bool option type coming from json
    Task<ulong?> CloneDeckConfigIdAsync(CloneDeckConfigIdParams value);

    /// <summary>
    /// Removes the configuration group with the given ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful, or false if attempting to remove either the default configuration group (ID = 1)
    /// or a configuration group that does not exist</returns>
    Task<bool?> RemoveDeckConfigIdAsync(RemoveDeckConfigIdParams value);

    /// <summary>
    /// Gets statistics such as total cards and cards due for the given decks
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Deck stats</returns>
    Task<IDictionary<ulong, DeckStats>?> GetDeckStatsAsync(DecksParams value);
}
