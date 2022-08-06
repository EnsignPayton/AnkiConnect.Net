using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

[UsesVerify]
public class AnkiCardsTests : AnkiClientTestsBase<IAnkiCards>
{
    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetEaseFactorsAsync(new CardsParams(1483959291685ul, 1483959293217ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[4100, 3900],\"error\":null}");
        var result = await Target.GetEaseFactorsAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.SetEaseFactorsAsync(new SetEaseFactorsParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul},
            EaseFactors = new[] {4100, 3900}
        });
        await VerifyRequest();
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[true, true],\"error\":null}");
        var result = await Target.SetEaseFactorsAsync(new SetEaseFactorsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams
        {
            Card = 1483959291685ul,
            Keys = new[] {"flags", "odue"},
            NewValues = new[] {"1", "-100"}
        });
        await VerifyRequest();
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseRequest_WithWarningCheck()
    {
        Handler.Returns("{}");
        await Target.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams
        {
            Card = 1483959291685ul,
            Keys = new[] {"flags", "odue"},
            NewValues = new[] {"1", "-100"},
            WarningCheck = true
        });
        await VerifyRequest();
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[true, true],\"error\":null}");
        var result = await Target.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.SuspendAsync(new CardsParams(1483959291685ul, 1483959293217ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.SuspendAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.UnsuspendAsync(new CardsParams(1483959291685ul, 1483959293217ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.UnsuspendAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task SuspendedAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.SuspendedAsync(1483959293217ul);
        await VerifyRequest();
    }

    [Fact]
    public async Task SuspendedAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");
        var result = await Target.SuspendedAsync(new SuspendedParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.AreSuspendedAsync(new CardsParams(1483959291685ul, 1483959293217ul, 1234567891234ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[false, true, null],\"error\":null}");
        var result = await Target.AreSuspendedAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task AreDueAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.AreDueAsync(new CardsParams(1483959291685ul, 1483959293217ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task AreDueAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[false, true],\"error\":null}");
        var result = await Target.AreDueAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GetIntervalsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetIntervalsAsync(new CardsParams(1483959291685ul, 1483959293217ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task GetIntervalsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[-14400, 3],\"error\":null}");
        var result = await Target.GetIntervalsAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GetIntervalsCompleteAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetIntervalsCompleteAsync(new CardsParams(1483959291685ul, 1483959293217ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task GetIntervalsCompleteAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [
        [-120, -180, -240, -300, -360, -14400],
        [-120, -180, -240, -300, -360, -14400, 1, 3]
    ],
    ""error"": null
}");

        var result = await Target.GetIntervalsCompleteAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task FindCardsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.FindCardsAsync("deck:current");
        await VerifyRequest();
    }

    [Fact]
    public async Task FindCardsAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1494723142483, 1494703460437, 1494703479525],
    ""error"": null
}");

        var result = await Target.FindCardsAsync(new QueryParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task CardsToNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.CardsToNotesAsync(new CardsParams(1502098034045ul, 1502098034048ul, 1502298033753ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task CardsToNotesAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1502098029797, 1502298025183],
    ""error"": null
}");

        var result = await Target.CardsToNotesAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task CardsModTimeAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.CardsModTimeAsync(new CardsParams(1498938915662ul, 1502098034048ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task CardsModTimeAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [
        {
            ""cardId"": 1498938915662,
            ""mod"": 1629454092
        }
    ],
    ""error"": null
}");

        var result = await Target.CardsModTimeAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task CardsInfoAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.CardsInfoAsync(new CardsParams(1498938915662ul, 1502098034048ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task CardsInfoAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [
        {
            ""answer"": ""back content"",
            ""question"": ""front content"",
            ""deckName"": ""Default"",
            ""modelName"": ""Basic"",
            ""fieldOrder"": 1,
            ""fields"": {
                ""Front"": {""value"": ""front content"", ""order"": 0},
                ""Back"": {""value"": ""back content"", ""order"": 1}
            },
            ""css"":""p {font-family:Arial;}"",
            ""cardId"": 1498938915662,
            ""interval"": 16,
            ""note"":1502298033753,
            ""ord"": 1,
            ""type"": 0,
            ""queue"": 0,
            ""due"": 1,
            ""reps"": 1,
            ""lapses"": 0,
            ""left"": 6,
            ""mod"": 1629454092
        },
        {
            ""answer"": ""back content"",
            ""question"": ""front content"",
            ""deckName"": ""Default"",
            ""modelName"": ""Basic"",
            ""fieldOrder"": 0,
            ""fields"": {
                ""Front"": {""value"": ""front content"", ""order"": 0},
                ""Back"": {""value"": ""back content"", ""order"": 1}
            },
            ""css"":""p {font-family:Arial;}"",
            ""cardId"": 1502098034048,
            ""interval"": 23,
            ""note"":1502298033753,
            ""ord"": 1,
            ""type"": 0,
            ""queue"": 0,
            ""due"": 1,
            ""reps"": 1,
            ""lapses"": 0,
            ""left"": 6
        }
    ],
    ""error"": null
}");

        var result = await Target.CardsInfoAsync(new CardsParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task ForgetCardsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ForgetCardsAsync(new CardsParams(1498938915662ul, 1502098034048ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task ForgetCardsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.ForgetCardsAsync(new CardsParams());
    }

    [Fact]
    public async Task RelearnCardsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.RelearnCardsAsync(new CardsParams(1498938915662ul, 1502098034048ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task RelearnCardsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.RelearnCardsAsync(new CardsParams());
    }
}
