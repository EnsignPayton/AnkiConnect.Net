using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AnkiConnect.Net;

public class MockHandler : HttpMessageHandler
{
    private string? RequestString { get; set; }

    private HttpResponseMessage? Response { get; set; }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        RequestString = await request.Content!.ReadAsStringAsync(cancellationToken);
        return Response ?? throw new InvalidOperationException("Returns must be called before operation");
    }

    public void Returns(string value)
    {
        Response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(value, Encoding.UTF8, "application/json")
        };
    }

    public void Returns(HttpStatusCode statusCode)
    {
        Response = new HttpResponseMessage(statusCode);
    }

    public void WasSent(string value)
    {
        Assert.Equal(value.NoWhitespace(), RequestString);
    }
}
