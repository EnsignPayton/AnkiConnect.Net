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

    [Fact]
    public async Task ModelTemplatesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ModelTemplatesAsync("Basic (and reversed card)");

        Handler.WasSent(@"{
    ""action"": ""modelTemplates"",
    ""version"": 6,
    ""params"": {
        ""modelName"": ""Basic (and reversed card)""
    }
}");
    }

    [Fact]
    public async Task ModelTemplatesAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
            ""result"": {
                ""Card 1"": {
                    ""Front"": ""{{Front}}"",
                    ""Back"": ""{{FrontSide}}\n\n<hr id=answer>\n\n{{Back}}""
                },
                ""Card 2"": {
                    ""Front"": ""{{Back}}"",
                    ""Back"": ""{{FrontSide}}\n\n<hr id=answer>\n\n{{Front}}""
                }
            },
            ""error"": null
        }");

        var result = await Target.ModelTemplatesAsync(new ModelNameParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.True(result.ContainsKey("Card 1"));
        Assert.Equal("{{Front}}", result["Card 1"].Front);
        Assert.Equal("{{FrontSide}}\n\n<hr id=answer>\n\n{{Back}}", result["Card 1"].Back);
        Assert.True(result.ContainsKey("Card 2"));
        Assert.Equal("{{Back}}", result["Card 2"].Front);
        Assert.Equal("{{FrontSide}}\n\n<hr id=answer>\n\n{{Front}}", result["Card 2"].Back);
    }

    [Fact]
    public async Task ModelStylingAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ModelStylingAsync("Basic (and reversed card)");

        Handler.WasSent(@"{
    ""action"": ""modelStyling"",
    ""version"": 6,
    ""params"": {
        ""modelName"": ""Basic (and reversed card)""
    }
}");
    }

    [Fact]
    public async Task ModelStylingAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": {
        ""css"": "".card {\n font-family: arial;\n font-size: 20px;\n text-align: center;\n color: black;\n background-color: white;\n}\n""
    },
    ""error"": null
}");

        var result = await Target.ModelStylingAsync(new ModelNameParams());

        Assert.NotNull(result);
        Assert.Equal(
            ".card {\n font-family: arial;\n font-size: 20px;\n text-align: center;\n color: black;\n background-color: white;\n}\n",
            result!.Css);
    }

    [Fact]
    public async Task UpdateModelTemplatesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.UpdateModelTemplatesAsync(new UpdateModelTemplatesData
        {
            Name = "Custom",
            Templates =
            {
                {
                    "Card 1", new CardTemplate
                    {
                        Front = "{{Question}}?",
                        Back = "{{Answer}}!"
                    }
                }
            }
        });

        Handler.WasSent(@"{
    ""action"": ""updateModelTemplates"",
    ""version"": 6,
    ""params"": {
        ""model"": {
            ""name"": ""Custom"",
            ""templates"": {
                ""Card 1"": {
                    ""Front"": ""{{Question}}?"",
                    ""Back"": ""{{Answer}}!""
                }
            }
        }
    }
}");
    }

    [Fact]
    public async Task UpdateModelTemplatesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.UpdateModelTemplatesAsync(new UpdateModelTemplatesParams());
    }

    [Fact]
    public async Task UpdateModelStylingAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.UpdateModelStylingAsync(new UpdateModelStylingData
        {
            Name = "Custom",
            Css = "p { color: blue; }"
        });

        Handler.WasSent(@"{
    ""action"": ""updateModelStyling"",
    ""version"": 6,
    ""params"": {
        ""model"": {
            ""name"": ""Custom"",
            ""css"": ""p { color: blue; }""
        }
    }
}");
    }

    [Fact]
    public async Task UpdateModelStylingAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.UpdateModelStylingAsync(new UpdateModelStylingParams());
    }

    [Fact]
    public async Task FindAndReplaceInModelsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.FindAndReplaceInModelsAsync(new FindAndReplaceInModelsData
        {
            FindText = "text_to_replace",
            ReplaceText = "replace_with_text",
            Front = true,
            Back = true,
            Css = true
        });

        Handler.WasSent(@"{
    ""action"": ""findAndReplaceInModels"",
    ""version"": 6,
    ""params"": {
        ""model"": {
            ""modelName"": """",
            ""findText"": ""text_to_replace"",
            ""replaceText"": ""replace_with_text"",
            ""front"": true,
            ""back"": true,
            ""css"": true
        }
    }
}");
    }

    [Fact]
    public async Task FindAndReplaceInModelsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":1,\"error\":null}");

        var result = await Target.FindAndReplaceInModelsAsync(new FindAndReplaceInModelsParams());

        Assert.NotNull(result);
        Assert.Equal(1, result);
    }
}
