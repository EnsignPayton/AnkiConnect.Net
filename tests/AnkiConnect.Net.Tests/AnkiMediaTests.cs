using AnkiConnect.Net.Models;

namespace AnkiConnect.Net;

[UsesVerify]
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
        await VerifyRequest();
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
        await VerifyRequest();
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
        await VerifyRequest();
    }

    [Fact]
    public async Task StoreMediaFileAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":\"_hello.txt\",\"error\":null}");

        var result = await Target.StoreMediaFileAsync(new StoreMediaFileParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task RetrieveMediaFileAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.RetrieveMediaFileAsync("_hello.txt");
        await VerifyRequest();
    }

    [Fact]
    public async Task RetrieveMediaFileAsync_ShouldParseResponse_WhenFileExists()
    {
        Handler.Returns(@"{
    ""result"": ""SGVsbG8sIHdvcmxkIQ=="",
    ""error"": null
}");

        var result = await Target.RetrieveMediaFileAsync(new FileNameParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task RetrieveMediaFileAsync_ShouldParseResponse_WhenFileDoesntExist()
    {
        Handler.Returns("{\"result\":false,\"error\":null}");
        var result = await Target.RetrieveMediaFileAsync(new FileNameParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task GetMediaFileNamesAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.GetMediaFileNamesAsync("_hell*.txt");
        await VerifyRequest();
    }

    [Fact]
    public async Task GetMediaFileNamesAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":[\"_hello.txt\"],\"error\":null}");
        var result = await Target.GetMediaFileNamesAsync(new PatternParams());
        await VerifyResponse(result);
    }

    [Fact]
    public async Task DeleteMediaFileAsync_ShouldParseRequest()
    {
        Handler.Returns("{}");
        await Target.DeleteMediaFileAsync("_hello.txt");
        await VerifyRequest();
    }

    [Fact]
    public async Task DeleteMediaFileAsync_ShouldParseResponse()
    {
        Handler.Returns("{\"result\":null,\"error\":null}");

        // Does not throw
        await Target.DeleteMediaFileAsync(new FileNameParams());
    }
}
