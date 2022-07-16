namespace AnkiConnect.Net;

public class AnkiStatsTests : AnkiClientTestsBase<IAnkiStats>
{
    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetNumCardsReviewedTodayAsync();

        Handler.WasSent("{\"action\":\"getNumCardsReviewedToday\",\"version\":6}");
    }

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":6,\"error\":null}");

        var result = await Target.GetNumCardsReviewedTodayAsync();

        Assert.NotNull(result);
        Assert.Equal(6, result);
    }
}
