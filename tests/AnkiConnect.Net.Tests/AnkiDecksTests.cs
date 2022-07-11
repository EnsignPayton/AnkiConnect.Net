using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiDecksTests : AnkiClientTestsBase<IAnkiDecks>
{
    [Fact]
    public async Task DeckNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.DeckNamesAsync();

        Handler.WasSent("{\"action\":\"deckNames\",\"version\":6}");
    }

    [Fact]
    public async Task DeckNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"Default\"],\"error\":null}");

        var result = await Target.DeckNamesAsync();

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Equal("Default", result[0]);
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.DeckNamesAndIdsAsync();

        Handler.WasSent("{\"action\":\"deckNamesAndIds\",\"version\":6}");
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":{\"Default\":1},\"error\":null}");

        var result = await Target.DeckNamesAndIdsAsync();

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Contains("Default", result);
        Assert.Equal(1, result["Default"]);
    }

    [Fact]
    public async Task GetDecksAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetDecksAsync(new CardsParams(1502298036657ul, 1502298033753ul, 1502032366472ul));

        Handler.WasSent(@"{
    ""action"": ""getDecks"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1502298036657, 1502298033753, 1502032366472]
    }
}");
    }

    [Fact]
    public async Task GetDecksAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": {
        ""Default"": [1502032366472],
        ""Japanese::JLPT N3"": [1502298036657, 1502298033753]
    },
    ""error"": null
}");

        var result = await Target.GetDecksAsync(new CardsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Contains("Default", result);
        Assert.Equal(1, result["Default"].Count);
        Assert.Equal(1502032366472ul, result["Default"][0]);
        Assert.Contains("Japanese::JLPT N3", result);
        Assert.Equal(2, result["Japanese::JLPT N3"].Count);
        Assert.Equal(1502298036657ul, result["Japanese::JLPT N3"][0]);
        Assert.Equal(1502298033753ul, result["Japanese::JLPT N3"][1]);
    }

    [Fact]
    public async Task CreateDeckAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.CreateDeckAsync("Japanese::Tokyo");

        Handler.WasSent(@"{
    ""action"": ""createDeck"",
    ""version"": 6,
    ""params"": {
        ""deck"": ""Japanese::Tokyo""
    }
}");
    }

    [Fact]
    public async Task CreateDeckAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":1519323742721,\"error\":null}");

        var result = await Target.CreateDeckAsync(new DeckParams());

        Assert.NotNull(result);
        Assert.Equal(1519323742721ul, result);
    }

    [Fact]
    public async Task ChangeDeckAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ChangeDeckAsync(new ChangeDeckParams
        {
            Cards = new[] {1502098034045ul, 1502098034048ul, 1502298033753ul},
            Deck = "Japanese::JLPT_N3"
        });

        Handler.WasSent(@"{
    ""action"": ""changeDeck"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1502098034045, 1502098034048, 1502298033753],
        ""deck"": ""Japanese::JLPT_N3""
    }
}");
    }

    [Fact]
    public async Task ChangeDeckAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.ChangeDeckAsync(new ChangeDeckParams());
    }

    [Fact]
    public async Task DeleteDecksAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.DeleteDecksAsync(new DecksParams("Japanese::JLPT_N5", "Easy_Spanish"));

        Handler.WasSent(@"{
    ""action"": ""deleteDecks"",
    ""version"": 6,
    ""params"": {
        ""decks"": [""Japanese::JLPT_N5"", ""Easy_Spanish""],
        ""cardsToo"": true
    }
}");
    }

    [Fact]
    public async Task DeleteDecksAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.DeleteDecksAsync(new DecksParams());
    }
}
