using Microsoft.Azure.Functions.Worker.Http;

namespace FakeHttpRequestData.Extensions;

public static class HttpResponseDataExtensions
{
    public static string ReadHttpResponseData(this HttpResponseData response)
    {
        var stream = response.Body;
        if (stream is not MemoryStream)
        {
            return string.Empty;
        }

        stream.Position = 0;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
