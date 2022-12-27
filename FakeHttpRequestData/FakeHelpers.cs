using Azure.Core.Serialization;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace FakeHttpRequestData;

public static class FakeHelpers
{
    public static HttpRequestData CreateHttpRequestData(string? payload = null,
        string? token = null,
        string method = "GET")
    {
        var input = payload ?? string.Empty;
        var functionContext = CreateContext(new NewtonsoftJsonObjectSerializer());
        var request = new FakeHttpRequestData(functionContext, method: method,
            body: new MemoryStream(Encoding.UTF8.GetBytes(input)));
        request.Headers.Add("Content-Type", "application/json");
        if (token != null)
        {
            request.Headers.Add("Authorization", $"Bearer {token}");
        }
        return request;
    }

    private static FunctionContext CreateContext(ObjectSerializer? serializer = null)
    {
        var context = new FakeFunctionContext();

        var services = new ServiceCollection();
        services.AddOptions();
        services.AddFunctionsWorkerCore();

        services.Configure<WorkerOptions>(c =>
        {
            c.Serializer = serializer;
        });

        context.InstanceServices = services.BuildServiceProvider();

        return context;
    }
}
