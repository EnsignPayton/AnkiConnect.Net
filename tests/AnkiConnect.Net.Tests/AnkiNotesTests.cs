using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

[UsesVerify]
public class AnkiNotesTests : AnkiClientTestsBase<IAnkiNotes>
{
    [Fact]
    public async Task AddTagsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.AddTagsAsync(new NoteTagsParams
        {
            Notes = new[] {1483959289817ul, 1483959291695ul},
            Tags = "european-languages"
        });
        await VerifyRequest();
    }

    [Fact]
    public async Task AddTagsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.AddTagsAsync(new NoteTagsParams());
    }

    [Fact]
    public async Task RemoveTagsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.RemoveTagsAsync(new NoteTagsParams
        {
            Notes = new[] {1483959289817ul, 1483959291695ul},
            Tags = "european-languages"
        });
        await VerifyRequest();
    }

    [Fact]
    public async Task RemoveTagsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.RemoveTagsAsync(new NoteTagsParams());
    }

    [Fact]
    public async Task GetTagsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetTagsAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task GetTagsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"european-languages\", \"idioms\"],\"error\":null}");
        var result = await Target.GetTagsAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task ClearUnusedTagsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ClearUnusedTagsAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task ClearUnusedTagsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.ClearUnusedTagsAsync();
    }

    [Fact]
    public async Task ReplaceTagsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ReplaceTagsAsync(new ReplaceTagsParams
        {
            Notes = new[] {1483959289817ul, 1483959291695ul},
            TagToReplace = "european-languages",
            ReplaceWithTag = "french-languages"
        });
        await VerifyRequest();
    }

    [Fact]
    public async Task ReplaceTagsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.ReplaceTagsAsync(new ReplaceTagsParams());
    }

    [Fact]
    public async Task ReplaceTagsInAllNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ReplaceTagsInAllNotesAsync(new ReplaceTagsInAllNotesParams
        {
            TagToReplace = "european-languages",
            ReplaceWithTag = "french-languages"
        });
        await VerifyRequest();
    }

    [Fact]
    public async Task ReplaceTagsInAllNotesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.ReplaceTagsInAllNotesAsync(new ReplaceTagsInAllNotesParams());
    }

    [Fact]
    public async Task FindNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.FindNotesAsync("deck:current");
        await VerifyRequest();
    }

    [Fact]
    public async Task FindNotesAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1483959289817, 1483959291695],
    ""error"": null
}");

        var result = await Target.FindNotesAsync(new QueryParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task NotesInfoAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.NotesInfoAsync(new NotesParams(1502298033753ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task NotesInfoAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [
        {
            ""noteId"":1502298033753,
            ""modelName"": ""Basic"",
            ""tags"":[""tag"",""another_tag""],
            ""fields"": {
                ""Front"": {""value"": ""front content"", ""order"": 0},
                ""Back"": {""value"": ""back content"", ""order"": 1}
            }
        }
    ],
    ""error"": null
}");

        var result = await Target.NotesInfoAsync(new NotesParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task DeleteNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.DeleteNotesAsync(new NotesParams(1502298033753ul));
        await VerifyRequest();
    }

    [Fact]
    public async Task DeleteNotesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.DeleteNotesAsync(new NotesParams());
    }

    [Fact]
    public async Task RemoveEmptyNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.RemoveEmptyNotesAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task RemoveEmptyNotesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.RemoveEmptyNotesAsync();
    }
}
