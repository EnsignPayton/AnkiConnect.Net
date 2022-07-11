using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiCardsTests : AnkiClientTestsBase<IAnkiCards>
{
    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetEaseFactorsAsync(new CardsParams(1483959291685ul, 1483959293217ul));

        Handler.WasSent(@"{
    ""action"": ""getEaseFactors"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[4100, 3900],\"error\":null}");

        var result = await Target.GetEaseFactorsAsync(new CardsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(4100, result[0]);
        Assert.Equal(3900, result[1]);
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

        Handler.WasSent(@"{
    ""action"": ""setEaseFactors"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217],
        ""easeFactors"": [4100, 3900]
    }
}");
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[true, true],\"error\":null}");

        var result = await Target.SetEaseFactorsAsync(new SetEaseFactorsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.True(result[0]);
        Assert.True(result[1]);
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

        Handler.WasSent(@"{
    ""action"": ""setSpecificValueOfCard"",
    ""version"": 6,
    ""params"": {
        ""card"": 1483959291685,
        ""keys"": [""flags"", ""odue""],
        ""newValues"": [""1"", ""-100""]
    }
}");
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseRequestWithWarningCheck()
    {
        Handler.Returns("{}");

        await Target.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams
        {
            Card = 1483959291685ul,
            Keys = new[] {"flags", "odue"},
            NewValues = new[] {"1", "-100"},
            WarningCheck = true
        });

        Handler.WasSent(@"{
    ""action"": ""setSpecificValueOfCard"",
    ""version"": 6,
    ""params"": {
        ""card"": 1483959291685,
        ""keys"": [""flags"", ""odue""],
        ""newValues"": [""1"", ""-100""],
        ""warning_check"": true
    }
}");
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[true, true],\"error\":null}");

        var result = await Target.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.True(result[0]);
        Assert.True(result[1]);
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SuspendAsync(new CardsParams(1483959291685ul, 1483959293217ul));

        Handler.WasSent(@"{
    ""action"": ""suspend"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.SuspendAsync(new CardsParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.UnsuspendAsync(new CardsParams(1483959291685ul, 1483959293217ul));

        Handler.WasSent(@"{
    ""action"": ""unsuspend"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.UnsuspendAsync(new CardsParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task SuspendedAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SuspendedAsync(1483959293217ul);

        Handler.WasSent(@"{
    ""action"": ""suspended"",
    ""version"": 6,
    ""params"": {
        ""card"": 1483959293217
    }
}");
    }

    [Fact]
    public async Task SuspendedAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.SuspendedAsync(new SuspendedParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.AreSuspendedAsync(new CardsParams(1483959291685ul, 1483959293217ul, 1234567891234ul));

        Handler.WasSent(@"{
    ""action"": ""areSuspended"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217, 1234567891234]
    }
}");
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[false, true, null],\"error\":null}");

        var result = await Target.AreSuspendedAsync(new CardsParams());

        Assert.NotNull(result);
        Assert.Equal(3, result!.Count);
        Assert.False(result[0]);
        Assert.True(result[1]);
        Assert.Null(result[2]);
    }

    [Fact]
    public async Task AreDueAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.AreDueAsync(new CardsParams(1483959291685ul, 1483959293217ul));

        Handler.WasSent(@"{
    ""action"": ""areDue"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task AreDueAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[false, true],\"error\":null}");

        var result = await Target.AreDueAsync(new CardsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.False(result[0]);
        Assert.True(result[1]);
    }

    [Fact]
    public async Task GetIntervalsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetIntervalsAsync(new CardsParams(1483959291685ul, 1483959293217ul));

        Handler.WasSent(@"{
    ""action"": ""getIntervals"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}");
    }

    [Fact]
    public async Task GetIntervalsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[-14400, 3],\"error\":null}");

        var result = await Target.GetIntervalsAsync(new CardsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(-14400, result[0]);
        Assert.Equal(3, result[1]);
    }

    [Fact]
    public async Task GetIntervalsCompleteAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetIntervalsCompleteAsync(new CardsParams(1483959291685ul, 1483959293217ul));

        Handler.WasSent(@"{
    ""action"": ""getIntervals"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217],
        ""complete"": true
    }
}");
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

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(6, result[0].Count);
        Assert.Equal(-120, result[0][0]);
        Assert.Equal(-180, result[0][1]);
        Assert.Equal(-240, result[0][2]);
        Assert.Equal(-300, result[0][3]);
        Assert.Equal(-360, result[0][4]);
        Assert.Equal(-14400, result[0][5]);
        Assert.Equal(8, result[1].Count);
        Assert.Equal(-120, result[1][0]);
        Assert.Equal(-180, result[1][1]);
        Assert.Equal(-240, result[1][2]);
        Assert.Equal(-300, result[1][3]);
        Assert.Equal(-360, result[1][4]);
        Assert.Equal(-14400, result[1][5]);
        Assert.Equal(1, result[1][6]);
        Assert.Equal(3, result[1][7]);
    }

    [Fact]
    public async Task FindCardsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.FindCardsAsync("deck:current");

        Handler.WasSent(@"{
    ""action"": ""findCards"",
    ""version"": 6,
    ""params"": {
        ""query"": ""deck:current""
    }
}");
    }

    [Fact]
    public async Task FindCardsAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1494723142483, 1494703460437, 1494703479525],
    ""error"": null
}");

        var result = await Target.FindCardsAsync(new FindCardsParams());

        Assert.NotNull(result);
        Assert.Equal(3, result!.Count);
        Assert.Equal(1494723142483ul, result[0]);
        Assert.Equal(1494703460437ul, result[1]);
        Assert.Equal(1494703479525ul, result[2]);
    }

    [Fact]
    public async Task CardsToNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.CardsToNotesAsync(new CardsParams(1502098034045ul, 1502098034048ul, 1502298033753ul));

        Handler.WasSent(@"{
    ""action"": ""cardsToNotes"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1502098034045, 1502098034048, 1502298033753]
    }
}");
    }

    [Fact]
    public async Task CardsToNotesAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1502098029797, 1502298025183],
    ""error"": null
}");

        var result = await Target.CardsToNotesAsync(new CardsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(1502098029797ul, result[0]);
        Assert.Equal(1502298025183ul, result[1]);
    }

    [Fact]
    public async Task CardsModTimeAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.CardsModTimeAsync(new CardsParams(1498938915662ul, 1502098034048ul));

        Handler.WasSent(@"{
    ""action"": ""cardsModTime"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1498938915662, 1502098034048]
    }
}");
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

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Equal(1498938915662ul, result[0].CardId);
        Assert.Equal(1629454092ul, result[0].Mod);
    }

    [Fact]
    public async Task CardsInfoAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.CardsInfoAsync(new CardsParams(1498938915662ul, 1502098034048ul));

        Handler.WasSent(@"{
    ""action"": ""cardsInfo"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1498938915662, 1502098034048]
    }
}");
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

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal("back content", result[0].Answer);
        Assert.Equal("front content", result[0].Question);
        Assert.Equal("Default", result[0].DeckName);
        Assert.Equal("Basic", result[0].ModelName);
        Assert.Equal(1, result[0].FieldOrder);
        Assert.Equal(2, result[0].Fields.Count);
        Assert.Contains("Front", result[0].Fields);
        Assert.Equal("front content", result[0].Fields["Front"].Value);
        Assert.Equal(0, result[0].Fields["Front"].Order);
        Assert.Contains("Back", result[0].Fields);
        Assert.Equal("back content", result[0].Fields["Back"].Value);
        Assert.Equal(1, result[0].Fields["Back"].Order);
        Assert.Equal("p {font-family:Arial;}", result[0].Css);
        Assert.Equal(1498938915662ul, result[0].CardId);
        Assert.Equal(16, result[0].Interval);
        Assert.Equal(1502298033753ul, result[0].Note);
        Assert.Equal(1, result[0].Ord);
        Assert.Equal(0, result[0].Type);
        Assert.Equal(0, result[0].Queue);
        Assert.Equal(1, result[0].Due);
        Assert.Equal(1, result[0].Reps);
        Assert.Equal(0, result[0].Lapses);
        Assert.Equal(6, result[0].Left);
        Assert.Equal(1629454092ul, result[0].Mod);
        Assert.Equal("back content", result[1].Answer);
        Assert.Equal("front content", result[1].Question);
        Assert.Equal("Default", result[1].DeckName);
        Assert.Equal("Basic", result[1].ModelName);
        Assert.Equal(0, result[1].FieldOrder);
        Assert.Equal(2, result[1].Fields.Count);
        Assert.Contains("Front", result[0].Fields);
        Assert.Equal("front content", result[0].Fields["Front"].Value);
        Assert.Equal(0, result[0].Fields["Front"].Order);
        Assert.Contains("Back", result[0].Fields);
        Assert.Equal("back content", result[0].Fields["Back"].Value);
        Assert.Equal(1, result[0].Fields["Back"].Order);
        Assert.Equal("p {font-family:Arial;}", result[1].Css);
        Assert.Equal(1502098034048ul, result[1].CardId);
        Assert.Equal(23, result[1].Interval);
        Assert.Equal(1502298033753ul, result[1].Note);
        Assert.Equal(1, result[1].Ord);
        Assert.Equal(0, result[1].Type);
        Assert.Equal(0, result[1].Queue);
        Assert.Equal(1, result[1].Due);
        Assert.Equal(1, result[1].Reps);
        Assert.Equal(0, result[1].Lapses);
        Assert.Equal(6, result[1].Left);
        Assert.Equal(0ul, result[1].Mod);
    }

    [Fact]
    public async Task ForgetCardsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ForgetCardsAsync(new CardsParams(1498938915662ul, 1502098034048ul));

        Handler.WasSent(@"{
    ""action"": ""forgetCards"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1498938915662, 1502098034048]
    }
}");
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

        Handler.WasSent(@"{
    ""action"": ""relearnCards"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1498938915662, 1502098034048]
    }
}");
    }

    [Fact]
    public async Task RelearnCardsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.RelearnCardsAsync(new CardsParams());
    }
}
