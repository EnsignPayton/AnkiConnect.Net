namespace AnkiConnect.Net;

public class AnkiClientTests : AnkiClientTestsBase<IAnkiClient>
{
    [Fact]
    public async Task RequestPermissionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.RequestPermissionAsync();

        Handler.WasSent("{\"action\":\"requestPermission\",\"version\":6}");
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldParseResponse_WhenGranted()
    {
        Handler.Returns(@"{
    ""result"": {
        ""permission"": ""granted"",
        ""requireApiKey"": false,
        ""version"": 6
    },
    ""error"": null
}");

        var result = await Target.RequestPermissionAsync();

        Assert.NotNull(result);
        Assert.Equal("granted", result!.Permission);
        Assert.False(result.RequireApiKey);
        Assert.Equal(6, result.Version);
    }

    [Fact]
    public async Task RequestPermissionAsync_ShouldParseResponse_WhenDenied()
    {
        Handler.Returns(@"{
    ""result"": {
        ""permission"": ""denied""
    },
    ""error"": null
}");

        var result = await Target.RequestPermissionAsync();

        Assert.NotNull(result);
        Assert.Equal("denied", result!.Permission);
    }

    [Fact]
    public async Task VersionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.VersionAsync();

        Handler.WasSent("{\"action\":\"version\",\"version\":6}");
    }

    [Fact]
    public async Task VersionAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":6,\"error\":null}");

        var result = await Target.VersionAsync();

        Assert.NotNull(result);
        Assert.Equal(6, result);
    }

    [Fact]
    public async Task SyncAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.SyncAsync();

        Handler.WasSent("{\"action\":\"sync\",\"version\":6}");
    }

    [Fact]
    public async Task SyncAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.SyncAsync();
    }

    [Fact]
    public async Task GetProfilesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetProfilesAsync();

        Handler.WasSent("{\"action\":\"getProfiles\",\"version\":6}");
    }

    [Fact]
    public async Task GetProfilesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"User 1\"],\"error\":null}");

        var result = await Target.GetProfilesAsync();

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Equal("User 1", result[0]);
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ReloadCollectionAsync();

        Handler.WasSent("{\"action\":\"reloadCollection\",\"version\":6}");
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.ReloadCollectionAsync();
    }

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

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetNumCardsReviewedTodayAsync();

        Handler.WasSent("{\"action\":\"getNumCardsReviewedToday\",\"version\":6}");
    }

    [Fact]
    public async Task GetNumCardsReviewedTodayAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":6,\"error\":null}");

        var result = await Target.GetNumCardsReviewedTodayAsync();

        Assert.NotNull(result);
        Assert.Equal(6, result);
    }
}
