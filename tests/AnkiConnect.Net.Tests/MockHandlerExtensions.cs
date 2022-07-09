using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace AnkiConnect.Net.Tests;

public static class MockHandlerExtensions
{
    public static void Returns(this Mock<HttpMessageHandler> target, string value)
    {
        target.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(value, Encoding.UTF8, "application/json")
            });
    }

    public static void Returns(this Mock<HttpMessageHandler> target, HttpStatusCode statusCode)
    {
        target.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(statusCode));
    }

    public static void WasSent(this Mock<HttpMessageHandler> target, string value)
    {
        target.Protected()
            .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(),
                ItExpr.Is<HttpRequestMessage>(x => x.Content!.ReadAsStringAsync().Result == value),
                ItExpr.IsAny<CancellationToken>());
    }
}
