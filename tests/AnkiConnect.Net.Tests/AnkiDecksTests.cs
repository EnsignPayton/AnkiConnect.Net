using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

[UsesVerify]
public class AnkiDecksTests : AnkiClientTestsBase<IAnkiDecks>
{
    [Fact]
    public async Task DeckNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.DeckNamesAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task DeckNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"Default\"],\"error\":null}");
        var result = await Target.DeckNamesAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.DeckNamesAndIdsAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task DeckNamesAndIdsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":{\"Default\":1},\"error\":null}");
        var result = await Target.DeckNamesAndIdsAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GetDecksAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetDecksAsync(new CardsParams(1502298036657ul, 1502298033753ul, 1502032366472ul));
        await VerifyRequest();
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
        await VerifyResponse(result);
    }

    [Fact]
    public async Task CreateDeckAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.CreateDeckAsync("Japanese::Tokyo");
        await VerifyRequest();
    }

    [Fact]
    public async Task CreateDeckAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":1519323742721,\"error\":null}");
        var result = await Target.CreateDeckAsync(new DeckParams());
        await VerifyResponse(result);
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
        await VerifyRequest();
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
        await VerifyRequest();
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
        await VerifyRequest();
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
        await VerifyResponse(result);
    }

    [Fact]
    public async Task SaveDeckConfigAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SaveDeckConfigAsync(new DeckConfigParams
        {
            Config = new DeckConfig
            {
                Lapse = new LapseConfig
                {
                    LeechFails = 8,
                    Delays = new[] {10.0},
                    MinInt = 1,
                    LeechAction = 0,
                    Mult = 0
                },
                Dyn = false,
                Autoplay = true,
                Mod = 1502970872ul,
                Id = 1,
                MaxTaken = 60,
                New = new NewConfig
                {
                    Bury = true,
                    Order = 1,
                    InitialFactor = 2500,
                    PerDay = 20,
                    Delays = new[] {1.0, 10.0},
                    Separate = true,
                    Ints = new[] {1, 4, 7}
                },
                Name = "Default",
                Rev = new RevConfig
                {
                    Bury = true,
                    IvlFct = 1,
                    Ease4 = 1.3,
                    MaxIvl = 36500,
                    PerDay = 100,
                    MinSpace = 1,
                    Fuzz = 0.05
                },
                Timer = 0,
                ReplayQ = true,
                Usn = -1
            }
        });

        await VerifyRequest();
    }

    [Fact]
    public async Task SaveDeckConfigAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.SaveDeckConfigAsync(new DeckConfigParams());
        await VerifyResponse(result);
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
        await VerifyRequest();
    }

    [Fact]
    public async Task SetDeckConfigIdAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.SetDeckConfigIdAsync(new SetDeckConfigIdParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task CloneDeckConfigIdAsync_ShouldParseRequest_WhenCloneFromSpecified()
    {
        Handler.Returns("{}");
        await Target.CloneDeckConfigIdAsync(new CloneDeckConfigIdParams("Copy of Default", 1));
        await VerifyRequest();
    }

    [Fact]
    public async Task CloneDeckConfigIdAsync_ShouldParseRequest_WhenCloneFromOmitted()
    {
        Handler.Returns("{}");
        await Target.CloneDeckConfigIdAsync(new CloneDeckConfigIdParams("Copy of Default"));
        await VerifyRequest();
    }

    [Fact]
    public async Task CloneDeckConfigIdAsync_ShouldParseResponse_WhenIdReturned()
    {
        Handler.Returns("{\"result\":1502972374573,\"error\":null}");
        var result = await Target.CloneDeckConfigIdAsync(new CloneDeckConfigIdParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task CloneDeckConfigIdAsync_ShouldParseResponse_WhenFalseReturned()
    {
        Handler.Returns("{\"result\":false,\"error\":null}");
        var result = await Target.CloneDeckConfigIdAsync(new CloneDeckConfigIdParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task RemoveDeckConfigIdAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.RemoveDeckConfigIdAsync(1502972374573ul);
        await VerifyRequest();
    }

    [Fact]
    public async Task RemoveDeckConfigIdAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.RemoveDeckConfigIdAsync(0ul);
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GetDeckStatsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetDeckStatsAsync(new DecksParams("Japanese::JLPT N5", "Easy Spanish"));
        await VerifyRequest();
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
        await VerifyResponse(result);
    }
}
