using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

public class AnkiMediaTests : AnkiClientTestsBase<IAnkiMedia>
{
    [Fact]
    public async Task StoreMediaFileAsync_ShouldParseRequest_WhenDataSpecified()
    {
        Handler.Returns("{}");

        await Target.StoreMediaFileAsync(new StoreMediaFileParams
        {
            FileName = "_hello.txt",
            Data = "SGVsbG8sIHdvcmxkIQ=="
        });

        Handler.WasSent(@"{
    ""action"": ""storeMediaFile"",
    ""version"": 6,
    ""params"": {
        ""filename"": ""_hello.txt"",
        ""data"": ""SGVsbG8sIHdvcmxkIQ==""
    }
}");
    }

    [Fact]
    public async Task StoreMediaFileAsync_ShouldParseRequest_WhenPathSpecified()
    {
        Handler.Returns("{}");

        await Target.StoreMediaFileAsync(new StoreMediaFileParams
        {
            FileName = "_hello.txt",
            Path = "/path/to/file"
        });

        Handler.WasSent(@"{
    ""action"": ""storeMediaFile"",
    ""version"": 6,
    ""params"": {
        ""filename"": ""_hello.txt"",
        ""path"": ""/path/to/file""
    }
}");
    }

    [Fact]
    public async Task StoreMediaFileAsync_ShouldParseRequest_WhenUrlSpecified()
    {
        Handler.Returns("{}");

        await Target.StoreMediaFileAsync(new StoreMediaFileParams
        {
            FileName = "_hello.txt",
            Url = "https://url.to.file"
        });

        Handler.WasSent(@"{
    ""action"": ""storeMediaFile"",
    ""version"": 6,
    ""params"": {
        ""filename"": ""_hello.txt"",
        ""url"": ""https://url.to.file""
    }
}");
    }

    [Fact]
    public async Task StoreMediaFileAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":\"_hello.txt\",\"error\":null}");

        var result = await Target.StoreMediaFileAsync(new StoreMediaFileParams());

        Assert.NotNull(result);
        Assert.Equal("_hello.txt", result);
    }

    [Fact]
    public async Task RetrieveMediaFileAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.RetrieveMediaFileAsync("_hello.txt");

        Handler.WasSent(@"{
    ""action"": ""retrieveMediaFile"",
    ""version"": 6,
    ""params"": {
        ""filename"": ""_hello.txt""
    }
}");
    }

    [Fact]
    public async Task RetrieveMediaFileAsync_ShouldParseResponse_WhenFileExists()
    {
        Handler.Returns(@"{
    ""result"": ""SGVsbG8sIHdvcmxkIQ=="",
    ""error"": null
}");

        var result = await Target.RetrieveMediaFileAsync(new FileNameParams());

        Assert.NotNull(result);
        Assert.Equal("SGVsbG8sIHdvcmxkIQ==", result);
    }

    [Fact]
    public async Task RetrieveMediaFileAsync_ShouldParseResponse_WhenFileDoesntExist()
    {
        Handler.Returns("{\"result\":false,\"error\":null}");

        var result = await Target.RetrieveMediaFileAsync(new FileNameParams());

        Assert.Null(result);
    }

    [Fact]
    public async Task GetMediaFileNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.GetMediaFileNamesAsync("_hell*.txt");

        Handler.WasSent(@"{
    ""action"": ""getMediaFilesNames"",
    ""version"": 6,
    ""params"": {
        ""pattern"": ""_hell*.txt""
    }
}");
    }

    [Fact]
    public async Task GetMediaFileNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"_hello.txt\"],\"error\":null}");

        var result = await Target.GetMediaFileNamesAsync(new PatternParams());

        Assert.NotNull(result);
        Assert.Equal(1, result!.Count);
        Assert.Equal("_hello.txt", result[0]);
    }

    [Fact]
    public async Task DeleteMediaFileAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");

        await Target.DeleteMediaFileAsync("_hello.txt");

        Handler.WasSent(@"{
    ""action"": ""deleteMediaFile"",
    ""version"": 6,
    ""params"": {
        ""filename"": ""_hello.txt""
    }
}");
    }

    [Fact]
    public async Task DeleteMediaFileAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.DeleteMediaFileAsync(new FileNameParams());
    }
}
