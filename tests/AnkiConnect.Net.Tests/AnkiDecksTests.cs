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
            Deck = "Japanese::JLPT N3"
        });

        Handler.WasSent(@"{
    ""action"": ""changeDeck"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1502098034045, 1502098034048, 1502298033753],
        ""deck"": ""Japanese::JLPT N3""
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

        await Target.DeleteDecksAsync(new DecksParams("Japanese::JLPT N5", "Easy Spanish"));

        Handler.WasSent(@"{
    ""action"": ""deleteDecks"",
    ""version"": 6,
    ""params"": {
        ""decks"": [""Japanese::JLPT N5"", ""Easy Spanish""],
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

    [Fact]
    public async Task GetDeckConfigAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetDeckConfigAsync("Default");

        Handler.WasSent(@"{
    ""action"": ""getDeckConfig"",
    ""version"": 6,
    ""params"": {
        ""deck"": ""Default""
    }
}");
    }

    [Fact]
    public async Task GetDeckConfigAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": {
        ""lapse"": {
            ""leechFails"": 8,
            ""delays"": [10],
            ""minInt"": 1,
            ""leechAction"": 0,
            ""mult"": 0
        },
        ""dyn"": false,
        ""autoplay"": true,
        ""mod"": 1502970872,
        ""id"": 1,
        ""maxTaken"": 60,
        ""new"": {
            ""bury"": true,
            ""order"": 1,
            ""initialFactor"": 2500,
            ""perDay"": 20,
            ""delays"": [1, 10],
            ""separate"": true,
            ""ints"": [1, 4, 7]
        },
        ""name"": ""Default"",
        ""rev"": {
            ""bury"": true,
            ""ivlFct"": 1,
            ""ease4"": 1.3,
            ""maxIvl"": 36500,
            ""perDay"": 100,
            ""minSpace"": 1,
            ""fuzz"": 0.05
        },
        ""timer"": 0,
        ""replayq"": true,
        ""usn"": -1
    },
    ""error"": null
}");
        var result = await Target.GetDeckConfigAsync(new DeckParams());

        // TODO: Assert stuff once I figure out how to parse deck config
    }

    [Fact]
    public async Task SaveDeckConfigAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SaveDeckConfigAsync(new DeckParams());

        // TODO: Assert stuff once I figure out how to parse deck config
    }

    [Fact]
    public async Task SaveDeckConfigAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.SaveDeckConfigAsync(new DeckParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task SetDeckConfigIdAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SetDeckConfigIdAsync(new SetDeckConfigIdParams()
        {
            Decks = new[] {"Default"},
            ConfigId = 1
        });

        Handler.WasSent(@"{
    ""action"": ""setDeckConfigId"",
    ""version"": 6,
    ""params"": {
        ""decks"": [""Default""],
        ""configId"": 1
    }
}");
    }

    [Fact]
    public async Task SetDeckConfigIdAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.SetDeckConfigIdAsync(new SetDeckConfigIdParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task CloneDeckConfigIdAsync_ShouldParseRequest_WhenCloneFromSpecified()
    {
        Handler.Returns("{}");

        await Target.CloneDeckConfigIdAsync(new CloneDeckConfigIdParams("Copy of Default", 1));

        Handler.WasSent(@"{
    ""action"": ""cloneDeckConfigId"",
    ""version"": 6,
    ""params"": {
        ""name"": ""Copy of Default"",
        ""cloneFrom"": 1
    }
}");
    }

    [Fact]
    public async Task CloneDeckConfigIdAsync_ShouldParseRequest_WhenCloneFromOmitted()
    {
        Handler.Returns("{}");

        await Target.CloneDeckConfigIdAsync(new CloneDeckConfigIdParams("Copy of Default"));

        Handler.WasSent(@"{
    ""action"": ""cloneDeckConfigId"",
    ""version"": 6,
    ""params"": {
        ""name"": ""Copy of Default""
    }
}");
    }

    [Fact]
    public async Task CloneDeckConfigIdAsync_ShouldParseResponse_WhenIdReturned()
    {
        Handler.Returns("{\"result\":1502972374573,\"error\":null}");

        var result = await Target.CloneDeckConfigIdAsync(new CloneDeckConfigIdParams());

        Assert.NotNull(result);
        Assert.Equal(1502972374573ul, result);
    }

    [Fact]
    public async Task CloneDeckConfigIdAsync_ShouldParseResponse_WhenFalseReturned()
    {
        Handler.Returns("{\"result\":false,\"error\":null}");

        // var result = await Target.CloneDeckConfigIdAsync(new CloneDeckConfigIdParams());

        // TODO: Assert something
        await Task.CompletedTask;
    }

    [Fact]
    public async Task RemoveDeckConfigIdAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.RemoveDeckConfigIdAsync(1502972374573ul);

        Handler.WasSent(@"{
    ""action"": ""removeDeckConfigId"",
    ""version"": 6,
    ""params"": {
        ""configId"": 1502972374573
    }
}");
    }

    [Fact]
    public async Task RemoveDeckConfigIdAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.RemoveDeckConfigIdAsync(0ul);

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task GetDeckStatsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetDeckStatsAsync(new DecksParams("Japanese::JLPT N5", "Easy Spanish"));

        Handler.WasSent(@"{
    ""action"": ""getDeckStats"",
    ""version"": 6,
    ""params"": {
        ""decks"": [""Japanese::JLPT N5"", ""Easy Spanish""]
    }
}");
    }

    [Fact]
    public async Task GetDeckStatsAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": {
        ""1651445861967"": {
            ""deck_id"": 1651445861967,
            ""name"": ""Japanese::JLPT N5"",
            ""new_count"": 20,
            ""learn_count"": 0,
            ""review_count"": 0,
            ""total_in_deck"": 1506
        },
        ""1651445861960"": {
            ""deck_id"": 1651445861960,
            ""name"": ""Easy Spanish"",
            ""new_count"": 26,
            ""learn_count"": 10,
            ""review_count"": 5,
            ""total_in_deck"": 852
        }
    },
    ""error"": null
}");

        var result = await Target.GetDeckStatsAsync(new DecksParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Contains(1651445861967ul, result);
        Assert.Equal(1651445861967ul, result[1651445861967ul].DeckId);
        Assert.Equal("Japanese::JLPT N5", result[1651445861967ul].Name);
        Assert.Equal(20, result[1651445861967ul].NewCount);
        Assert.Equal(0, result[1651445861967ul].LearnCount);
        Assert.Equal(0, result[1651445861967ul].ReviewCount);
        Assert.Equal(1506, result[1651445861967ul].TotalInDeck);
        Assert.Contains(1651445861960ul, result);
        Assert.Equal(1651445861960ul, result[1651445861960ul].DeckId);
        Assert.Equal("Easy Spanish", result[1651445861960ul].Name);
        Assert.Equal(26, result[1651445861960ul].NewCount);
        Assert.Equal(10, result[1651445861960ul].LearnCount);
        Assert.Equal(5, result[1651445861960ul].ReviewCount);
        Assert.Equal(852, result[1651445861960ul].TotalInDeck);
    }
}
