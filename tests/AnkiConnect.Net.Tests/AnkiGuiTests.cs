namespace AnkiConnect.Net;

public class AnkiGuiTests : AnkiClientTestsBase<IAnkiGui>
{
    [Fact]
    public async Task GuiBrowseAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiBrowseAsync("deck:current");

        Handler.WasSent(@"{
    ""action"": ""guiBrowse"",
    ""version"": 6,
    ""params"": {
        ""query"": ""deck:current""
    }
}");
    }

    [Fact]
    public async Task GuiBrowseAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1494723142483, 1494703460437, 1494703479525],
    ""error"": null
}");

        var result = await Target.GuiBrowseAsync("");

        Assert.NotNull(result);
        Assert.Equal(3, result!.Count);
        Assert.Equal(1494723142483ul, result[0]);
        Assert.Equal(1494703460437ul, result[1]);
        Assert.Equal(1494703479525ul, result[2]);
    }

    [Fact]
    public async Task GuiSelectedNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GuiSelectedNotesAsync();

        Handler.WasSent("{\"action\":\"guiSelectedNotes\",\"version\":6}");
    }

    [Fact]
    public async Task GuiSelectedNotesAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1494723142483, 1494703460437, 1494703479525],
    ""error"": null
}");

        var result = await Target.GuiSelectedNotesAsync();

        Assert.NotNull(result);
        Assert.Equal(3, result!.Count);
        Assert.Equal(1494723142483ul, result[0]);
        Assert.Equal(1494703460437ul, result[1]);
        Assert.Equal(1494703479525ul, result[2]);
    }
}
