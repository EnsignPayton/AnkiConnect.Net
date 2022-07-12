using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiCards
{
    /// <summary>
    /// Returns an array with the ease factor for each of the given cards (in the same order)
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>An array with the ease factor for each of the given cards (in the same order)</returns>
    Task<IList<int>?> GetEaseFactorsAsync(CardsParams value);

    /// <summary>
    /// Sets ease factor of cards by card ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful (all cards existed) or false otherwise</returns>
    Task<IList<bool>?> SetEaseFactorsAsync(SetEaseFactorsParams value);

    /// <summary>
    /// Sets specific value of a single card
    /// </summary>
    /// <remarks>
    /// Given the risk of wreaking havoc in the database when changing some of the values of a card, some of the keys
    /// require the argument "warning_check" set to True. This can be used to set a card's flag, change its
    /// ease factor, change the review order in a filtered deck and change the column "data" (not currently used
    /// by anki apparently), and many other values. A list of values and explanation of their respective utility
    /// can be found at AnkiDroid's wiki.
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful or false otherwise</returns>
    Task<IList<bool>?> SetSpecificValueOfCardAsync(SetSpecificValueOfCardParams value);

    /// <summary>
    /// Suspend cards by card ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful (at least one card wasn't already suspended) or false otherwise</returns>
    Task<bool?> SuspendAsync(CardsParams value);

    /// <summary>
    /// Unsuspend cards by card ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if successful (at least one card was previously suspended) or false otherwise</returns>
    Task<bool?> UnsuspendAsync(CardsParams value);

    /// <summary>
    /// Check if card is suspended by its ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>True if suspended, false otherwise</returns>
    Task<bool?> SuspendedAsync(SuspendedParams value);

    /// <summary>
    /// Check if cards are suspended by card ID
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>
    /// An array indicating whether each of the given cards is suspended (in the same order).
    /// If card doesn't exist returns null
    /// </returns>
    Task<IList<bool?>?> AreSuspendedAsync(CardsParams value);

    /// <summary>
    /// Returns an array indicating whether each of the given cards is due (in the same order)
    /// </summary>
    /// <remarks>
    /// cards in the learning queue with a large interval (over 20 minutes) are treated as not due until
    /// the time of their interval has passed, to match the way Anki treats them when reviewing.
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>An array indicating whether each of the given cards is due (in the same order)</returns>
    Task<IList<bool>?> AreDueAsync(CardsParams value);

    /// <summary>
    /// Returns an array of the most recent intervals for each given card ID
    /// </summary>
    /// <remarks>
    /// Negative intervals are in seconds and positive intervals in days.
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>An array of the most recent intervals for each given card ID</returns>
    Task<IList<int>?> GetIntervalsAsync(CardsParams value);

    /// <summary>
    /// Returns a 2-dimensional array of all the intervals for each given card ID
    /// </summary>
    /// <remarks>
    /// Negative intervals are in seconds and positive intervals in days.
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>A 2-dimensional array of all the intervals for each given card ID</returns>
    Task<IList<IList<int>>?> GetIntervalsCompleteAsync(CardsParams value);

    /// <summary>
    /// Returns an array of card IDs for a given query
    /// </summary>
    /// <remarks>
    /// Functionally equivalent to guiBrowse but doesn't use the GUI for better performance
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>An array of card IDs for a given query</returns>
    Task<IList<ulong>?> FindCardsAsync(QueryParams value);

    /// <summary>
    /// Returns an unordered array of note IDs for the given card IDs
    /// </summary>
    /// <remarks>
    /// For cards with the same note, the ID is only given once in the array
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>An unordered array of note IDs for the given card IDs</returns>
    Task<IList<ulong>?> CardsToNotesAsync(CardsParams value);

    /// <summary>
    /// Returns a list of objects containing the modification time for each card ID
    /// </summary>
    /// <remarks>
    /// This function is about 15 times faster than executing cardsInfo
    /// </remarks>
    /// <param name="value">Parameter structure</param>
    /// <returns>A list of objects containing the modification time for each card ID</returns>
    Task<IList<CardModTime>?> CardsModTimeAsync(CardsParams value);

    /// <summary>
    /// Returns a list of objects containing for each card ID the card fields, front and back sides including CSS,
    /// note type, the note that the card belongs to, and deck name, last modification timestamp as well as
    /// ease and interval
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>
    /// A list of objects containing for each card ID the card fields, front and back sides including CSS,
    /// note type, the note that the card belongs to, and deck name, last modification timestamp as well as
    /// ease and interval
    /// </returns>
    Task<IList<CardInfo>?> CardsInfoAsync(CardsParams value);

    /// <summary>
    /// Forget cards, making the cards new again
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task ForgetCardsAsync(CardsParams value);

    /// <summary>
    /// Make cards be "relearning"
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Task</returns>
    Task RelearnCardsAsync(CardsParams value);
}
