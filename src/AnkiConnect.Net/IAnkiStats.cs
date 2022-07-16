namespace AnkiConnect.Net;

public interface IAnkiStats
{
    Task<int?> GetNumCardsReviewedTodayAsync();
    // TODO: Parse. What is the type of ["2021-02-28", 124] ?
    Task<IList<object?>?> GetNumCardsReviewedByDayAsync();
}
