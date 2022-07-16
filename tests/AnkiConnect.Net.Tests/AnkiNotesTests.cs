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
            Notes = new[] { 1483959289817ul,1483959291695ul},
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
            Notes = new[] { 1483959289817ul,1483959291695ul},
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
