using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AnkiConnect.Net.Models;
using Xunit;

namespace AnkiConnect.Net;

public class AnkiCardsTests : AnkiClientTestsBase<IAnkiCards>
{
    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetEaseFactorsAsync(new GetEaseFactorsParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""getEaseFactors"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task GetEaseFactorsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[4100, 3900],\"error\":null}");

        var result = await Target.GetEaseFactorsAsync(new GetEaseFactorsParams());

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

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""setEaseFactors"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217],
        ""easeFactors"": [4100, 3900]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task SetEaseFactorsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[true, true],\"error\":null}");

        var result = await Target.SetEaseFactorsAsync(new SetEaseFactorsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(true, result[0]);
        Assert.Equal(true, result[1]);
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

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""setSpecificValueOfCard"",
    ""version"": 6,
    ""params"": {
        ""card"": 1483959291685,
        ""keys"": [""flags"", ""odue""],
        ""newValues"": [""1"", ""-100""]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task SetSpecificValueOfCardAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[true, true],\"error\":null}");

        var result = await Target.SetSpecificValueOfCardAsync(new SetSpecificValueOfCardParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(true, result[0]);
        Assert.Equal(true, result[1]);
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SuspendAsync(new SuspendParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""suspend"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task SuspendAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.SuspendAsync(new SuspendParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.UnsuspendAsync(new UnsuspendParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""unsuspend"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task UnsuspendAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.UnsuspendAsync(new UnsuspendParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task SuspendedAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SuspendedAsync(new SuspendedParams
        {
            Card = 1483959293217ul
        });

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""suspended"",
    ""version"": 6,
    ""params"": {
        ""card"": 1483959293217
    }
}", @"\s+", string.Empty));
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

        await Target.AreSuspendedAsync(new AreSuspendedParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul, 1234567891234ul}
        });

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""areSuspended"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217, 1234567891234]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task AreSuspendedAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[false, true, null],\"error\":null}");

        var result = await Target.AreSuspendedAsync(new AreSuspendedParams());

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

        await Target.AreDueAsync(new AreDueParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""areDue"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task AreDueAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[false, true],\"error\":null}");

        var result = await Target.AreDueAsync(new AreDueParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.False(result[0]);
        Assert.True(result[1]);
    }

    [Fact]
    public async Task GetIntervalsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetIntervalsAsync(new GetIntervalsParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""getIntervals"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217]
    }
}", @"\s+", string.Empty));
    }

    [Fact]
    public async Task GetIntervalsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[-14400, 3],\"error\":null}");

        var result = await Target.GetIntervalsAsync(new GetIntervalsParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(-14400, result[0]);
        Assert.Equal(3, result[1]);
    }

    [Fact]
    public async Task GetIntervalsCompleteAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetIntervalsCompleteAsync(new GetIntervalsCompleteParams
        {
            Cards = new[] {1483959291685ul, 1483959293217ul}
        });

        Handler.WasSent(Regex.Replace(@"{
    ""action"": ""getIntervals"",
    ""version"": 6,
    ""params"": {
        ""cards"": [1483959291685, 1483959293217],
        ""complete"": true
    }
}", @"\s+", string.Empty));
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

        var result = await Target.GetIntervalsCompleteAsync(new GetIntervalsCompleteParams());

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
}
