using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiMiscTests : AnkiClientTestsBase<IAnkiMisc>
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
    public async Task ApiReflectAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ApiReflectAsync(new ApiReflectParams
        {
            Scopes = new[] {"actions", "invalidType"},
            Actions = new[] {"apiReflect", "invalidMethod"}
        });

        Handler.WasSent(@"{
    ""action"": ""apiReflect"",
    ""version"": 6,
    ""params"": {
        ""scopes"": [""actions"", ""invalidType""],
        ""actions"": [""apiReflect"", ""invalidMethod""]
    }
}");
    }

    [Fact]
    public async Task ApiReflectAsync_ShouldParseResponse()
    {
        Handler.Returns(@"{
    ""result"": {
        ""scopes"": [""actions""],
        ""actions"": [""apiReflect""]
    },
    ""error"": null
}");

        var result = await Target.ApiReflectAsync(new ApiReflectParams());

        Assert.NotNull(result);
        Assert.Equal(1, result!.Scopes.Count);
        Assert.Equal("actions", result.Scopes[0]);
        Assert.NotNull(result.Actions);
        Assert.Equal(1, result.Actions!.Count);
        Assert.Equal("apiReflect", result.Actions[0]);
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
    public async Task LoadProfileAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.LoadProfileAsync("user1");

        Handler.WasSent(@"{
    ""action"": ""loadProfile"",
    ""version"": 6,
    ""params"": {
        ""name"": ""user1""
    }
}");
    }

    [Fact]
    public async Task LoadProfileAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.LoadProfileAsync(new NameParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task ExportPackageAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ExportPackageAsync(new ExportPackageParams
        {
            Deck = "Default",
            Path = "/data/Deck.apkg",
            IncludeScheduleData = true
        });

        Handler.WasSent(@"{
    ""action"": ""exportPackage"",
    ""version"": 6,
    ""params"": {
        ""deck"": ""Default"",
        ""path"": ""/data/Deck.apkg"",
        ""includeSched"": true
    }
}");
    }

    [Fact]
    public async Task ExportPackageAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.ExportPackageAsync(new ExportPackageParams());

        Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public async Task ImportPackageAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.ImportPackageAsync("/data/Deck.apkg");

        Handler.WasSent(@"{
    ""action"": ""importPackage"",
    ""version"": 6,
    ""params"": {
        ""path"": ""/data/Deck.apkg""
    }
}");
    }

    [Fact]
    public async Task ImportPackageAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.ImportPackageAsync(new PathParams());

        Assert.NotNull(result);
        Assert.True(result);
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
}
