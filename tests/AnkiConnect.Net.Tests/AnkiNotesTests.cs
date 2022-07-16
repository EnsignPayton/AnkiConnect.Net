using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

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

        Handler.WasSent(@"{
    ""action"": ""addTags"",
    ""version"": 6,
    ""params"": {
        ""notes"": [1483959289817, 1483959291695],
        ""tags"": ""european-languages""
    }
}");
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

        Handler.WasSent(@"{
    ""action"": ""removeTags"",
    ""version"": 6,
    ""params"": {
        ""notes"": [1483959289817, 1483959291695],
        ""tags"": ""european-languages""
    }
}");
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

        Handler.WasSent("{\"action\":\"getTags\",\"version\":6}");
    }

    [Fact]
    public async Task GetTagsAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"european-languages\", \"idioms\"],\"error\":null}");

        var result = await Target.GetTagsAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal("european-languages", result[0]);
        Assert.Equal("idioms", result[1]);
    }

    [Fact]
    public async Task ClearUnusedTagsAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ClearUnusedTagsAsync();

        Handler.WasSent("{\"action\":\"clearUnusedTags\",\"version\":6}");
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

        Handler.WasSent(@"{
    ""action"": ""replaceTags"",
    ""version"": 6,
    ""params"": {
        ""notes"": [1483959289817, 1483959291695],
        ""tag_to_replace"": ""european-languages"",
        ""replace_with_tag"": ""french-languages""
    }
}");
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

        Handler.WasSent(@"{
    ""action"": ""replaceTagsInAllNotes"",
    ""version"": 6,
    ""params"": {
        ""tag_to_replace"": ""european-languages"",
        ""replace_with_tag"": ""french-languages""
    }
}");
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

        Handler.WasSent(@"{
    ""action"": ""findNotes"",
    ""version"": 6,
    ""params"": {
        ""query"": ""deck:current""
    }
}");
    }

    [Fact]
    public async Task FindNotesAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": [1483959289817, 1483959291695],
    ""error"": null
}");

        var result = await Target.FindNotesAsync(new QueryParams());

        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal(1483959289817ul, result[0]);
        Assert.Equal(1483959291695ul, result[1]);
    }

    [Fact]
    public async Task NotesInfoAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.NotesInfoAsync(new NotesParams(1502298033753ul));

        Handler.WasSent(@"{
    ""action"": ""notesInfo"",
    ""version"": 6,
    ""params"": {
        ""notes"": [1502298033753]
    }
}");
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

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Equal(1502298033753ul, result[0].NoteId);
        Assert.Equal("Basic", result[0].ModelName);
        Assert.Equal(2, result[0].Fields.Count);
        Assert.True(result[0].Fields.ContainsKey("Front"));
        Assert.Equal("front content", result[0].Fields["Front"].Value);
        Assert.Equal(0, result[0].Fields["Front"].Order);
        Assert.True(result[0].Fields.ContainsKey("Back"));
        Assert.Equal("back content", result[0].Fields["Back"].Value);
        Assert.Equal(1, result[0].Fields["Back"].Order);
    }

    [Fact]
    public async Task DeleteNotesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.DeleteNotesAsync(new NotesParams(1502298033753ul));

        Handler.WasSent(@"{
    ""action"": ""deleteNotes"",
    ""version"": 6,
    ""params"": {
        ""notes"": [1502298033753]
    }
}");
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

        Handler.WasSent("{\"action\":\"removeEmptyNotes\",\"version\":6}");
    }

    [Fact]
    public async Task RemoveEmptyNotesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.RemoveEmptyNotesAsync();
    }
}
