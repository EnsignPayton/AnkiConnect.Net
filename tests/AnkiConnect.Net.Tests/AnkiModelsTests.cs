using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiModelsTests : AnkiClientTestsBase<IAnkiModels>
{
    [Fact]
    public async Task ModelNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ModelNamesAsync();

        Handler.WasSent("{\"action\":\"modelNames\",\"version\":6}");
    }

    [Fact]
    public async Task ModelNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"Basic\", \"Basic (and reversed card)\"],\"error\":null}");

        var result = await Target.ModelNamesAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal("Basic", result[0]);
        Assert.Equal("Basic (and reversed card)", result[1]);
    }

    [Fact]
    public async Task ModelNamesAndIdsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ModelNamesAndIdsAsync();

        Handler.WasSent("{\"action\":\"modelNamesAndIds\",\"version\":6}");
    }

    [Fact]
    public async Task ModelNamesAndIdsAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": {
        ""Basic"": 1483883011648,
        ""Basic (and reversed card)"": 1483883011644,
        ""Basic (optional reversed card)"": 1483883011631,
        ""Cloze"": 1483883011630
    },
    ""error"": null
}");

        var result = await Target.ModelNamesAndIdsAsync();

        Assert.NotNull(result);
        Assert.Equal(4, result!.Count);
        Assert.Contains("Basic", result);
        Assert.Equal(1483883011648ul, result["Basic"]);
        Assert.Contains("Basic (and reversed card)", result);
        Assert.Equal(1483883011644ul, result["Basic (and reversed card)"]);
        Assert.Contains("Basic (optional reversed card)", result);
        Assert.Equal(1483883011631ul, result["Basic (optional reversed card)"]);
        Assert.Contains("Cloze", result);
        Assert.Equal(1483883011630ul, result["Cloze"]);
    }

    [Fact]
    public async Task ModelFieldNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ModelFieldNamesAsync("Basic");

        Handler.WasSent(@"{
    ""action"": ""modelFieldNames"",
    ""version"": 6,
    ""params"": {
        ""modelName"": ""Basic""
    }
}");
    }

    [Fact]
    public async Task ModelFieldNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"Front\",\"Back\"],\"error\":null}");

        var result = await Target.ModelFieldNamesAsync(new ModelNameParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal("Front", result[0]);
        Assert.Equal("Back", result[1]);
    }

    [Fact]
    public async Task ModelFieldsOnTemplatesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ModelFieldsOnTemplatesAsync("Basic (and reversed card)");

        Handler.WasSent(@"{
    ""action"": ""modelFieldsOnTemplates"",
    ""version"": 6,
    ""params"": {
        ""modelName"": ""Basic (and reversed card)""
    }
}");
    }

    [Fact]
    public async Task ModelFieldsOnTemplatesAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": {
        ""Card 1"": [[""Front""], [""Back""]],
        ""Card 2"": [[""Back""], [""Front""]]
    },
    ""error"": null
}");

        var result = await Target.ModelFieldsOnTemplatesAsync(new ModelNameParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(2, result["Card 1"].Count);
        Assert.Equal(1, result["Card 1"][0].Count);
        Assert.Equal("Front", result["Card 1"][0][0]);
        Assert.Equal(1, result["Card 1"][1].Count);
        Assert.Equal("Back", result["Card 1"][1][0]);
        Assert.Equal(2, result["Card 2"].Count);
        Assert.Equal(1, result["Card 2"][0].Count);
        Assert.Equal("Back", result["Card 2"][0][0]);
        Assert.Equal(1, result["Card 2"][1].Count);
        Assert.Equal("Front", result["Card 2"][1][0]);
    }
}
