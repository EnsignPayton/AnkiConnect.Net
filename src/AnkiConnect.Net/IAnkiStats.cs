using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public interface IAnkiStats
{
    /// <summary>
    /// Gets the count of cards that have been reviewed in the current day
    /// (with day start time as configured by user in Anki)
    /// </summary>
    /// <returns>Review Count</returns>
    Task<int?> GetNumCardsReviewedTodayAsync();

    // TODO: Parse. What is the type of ["2021-02-28", 124] ?
    // Task<IList<object?>?> GetNumCardsReviewedByDayAsync();

    /// <summary>
    /// Gets the collection statistics report
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Collection Stats HTML</returns>
    Task<string?> GetCollectionStatsHtmlAsync(WholeCollectionParams value);

    /// <summary>
    /// Returns the unix time of the latest review for the given deck. 0 if no review has ever been made for the deck.
    /// </summary>
    /// <param name="value">Parameter structure</param>
    /// <returns>Review Time</returns>
    Task<ulong?> GetLatestReviewIdAsync(DeckParams value);
}
