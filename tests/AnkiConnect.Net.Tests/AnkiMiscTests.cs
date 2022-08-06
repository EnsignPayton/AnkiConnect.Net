using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

[UsesVerify]
public class AnkiMiscTests : AnkiClientTestsBase<IAnkiMisc>
{
    [Fact]
    public async Task RequestPermissionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.RequestPermissionAsync();
        await VerifyRequest();
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
        await VerifyResponse(result);
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
        await VerifyResponse(result);
    }

    [Fact]
    public async Task VersionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.VersionAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task VersionAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":6,\"error\":null}");

        var result = await Target.VersionAsync();
        await VerifyResponse(result);
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
        await VerifyRequest();
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
        await VerifyResponse(result);
    }

    [Fact]
    public async Task SyncAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.SyncAsync();
        await VerifyRequest();
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
        await VerifyRequest();
    }

    [Fact]
    public async Task GetProfilesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"User 1\"],\"error\":null}");

        var result = await Target.GetProfilesAsync();
        await VerifyResponse(result);
    }

    [Fact]
    public async Task LoadProfileAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.LoadProfileAsync("user1");
        await VerifyRequest();
    }

    [Fact]
    public async Task LoadProfileAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.LoadProfileAsync(new NameParams());
        await VerifyResponse(result);
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
        await VerifyRequest();
    }

    [Fact]
    public async Task ExportPackageAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.ExportPackageAsync(new ExportPackageParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task ImportPackageAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ImportPackageAsync("/data/Deck.apkg");
        await VerifyRequest();
    }

    [Fact]
    public async Task ImportPackageAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":true,\"error\":null}");

        var result = await Target.ImportPackageAsync(new PathParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.ReloadCollectionAsync();
        await VerifyRequest();
    }

    [Fact]
    public async Task ReloadCollectionAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.ReloadCollectionAsync();
    }
}
