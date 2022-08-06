using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

[UsesVerify]
public class AnkiModelsTests : AnkiClientTestsBase<IAnkiModels>
{
    [Fact]
    public async Task ModelNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ModelNamesAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task ModelNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"Basic\", \"Basic (and reversed card)\"],\"error\":null}");
        var result = await Target.ModelNamesAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task ModelNamesAndIdsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ModelNamesAndIdsAsync();
        await VerifyRequest();
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
        await VerifyResponse(result);
    }

    [Fact]
    public async Task ModelFieldNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ModelFieldNamesAsync("Basic");
        await VerifyRequest();
    }

    [Fact]
    public async Task ModelFieldNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"Front\",\"Back\"],\"error\":null}");
        var result = await Target.ModelFieldNamesAsync(new ModelNameParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task ModelFieldsOnTemplatesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ModelFieldsOnTemplatesAsync("Basic (and reversed card)");
        await VerifyRequest();
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
        await VerifyResponse(result);
    }

    [Fact]
    public async Task ModelTemplatesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ModelTemplatesAsync("Basic (and reversed card)");
        await VerifyRequest();
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
        await VerifyResponse(result);
    }

    [Fact]
    public async Task ModelStylingAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ModelStylingAsync("Basic (and reversed card)");
        await VerifyRequest();
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
        await VerifyResponse(result);
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
        await VerifyRequest();
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
        await VerifyRequest();
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
        await VerifyRequest();
    }

    [Fact]
    public async Task FindAndReplaceInModelsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":1,\"error\":null}");

        var result = await Target.FindAndReplaceInModelsAsync(new FindAndReplaceInModelsParams());
        await VerifyResponse(result);
    }
}
