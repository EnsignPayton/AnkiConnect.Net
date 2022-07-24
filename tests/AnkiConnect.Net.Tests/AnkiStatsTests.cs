using AnkiConnect.Net.Models;

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

    [Fact]
    public async Task GetCollectionStatsHtmlAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetCollectionStatsHtmlAsync(true);

        Handler.WasSent(@"{
    ""action"": ""getCollectionStatsHTML"",
    ""version"": 6,
    ""params"": {
        ""wholeCollection"": true
    }
}");
    }

    [Fact]
    public async Task GetCollectionStatsHtmlAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":\"<center> lots of HTML here </center>\",\"error\":null}");

        var result = await Target.GetCollectionStatsHtmlAsync(true);

        Assert.NotNull(result);
        Assert.Equal("<center> lots of HTML here </center>", result);
    }

    [Fact]
    public async Task GetLatestReviewIdAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetLatestReviewIdAsync("default");

        Handler.WasSent(@"{
    ""action"": ""getLatestReviewID"",
    ""version"": 6,
    ""params"": {
        ""deck"": ""default""
    }
}");
    }

    [Fact]
    public async Task GetLatestReviewIdAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":1594194095746,\"error\":null}");

        var result = await Target.GetLatestReviewIdAsync(new DeckParams());

        Assert.NotNull(result);
        Assert.Equal(1594194095746ul, result);
    }
}
