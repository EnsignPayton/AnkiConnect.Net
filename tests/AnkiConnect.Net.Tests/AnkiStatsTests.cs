using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

[UsesVerify]
public class AnkiStatsTests : AnkiClientTestsBase<IAnkiStats>
{
    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetNumCardsReviewedTodayAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":6,\"error\":null}");
        var result = await Target.GetNumCardsReviewedTodayAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GetCollectionStatsHtmlAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetCollectionStatsHtmlAsync(true);
        await VerifyRequest();
    }

    [Fact]
    public async Task GetCollectionStatsHtmlAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":\"<center> lots of HTML here </center>\",\"error\":null}");
        var result = await Target.GetCollectionStatsHtmlAsync(true);
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GetLatestReviewIdAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetLatestReviewIdAsync("default");
        await VerifyRequest();
    }

    [Fact]
    public async Task GetLatestReviewIdAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":1594194095746,\"error\":null}");
        var result = await Target.GetLatestReviewIdAsync(new DeckParams());
        await VerifyResponse(result);
    }
}
