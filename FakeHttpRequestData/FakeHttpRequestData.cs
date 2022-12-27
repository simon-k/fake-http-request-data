﻿using System.Net;
using System.Security.Claims;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace FakeHttpRequestData;

public class FakeHttpRequestData
    : HttpRequestData
{
    public FakeHttpRequestData(
        FunctionContext functionContext,
        Stream? body = null,
        string method = "GET",
        string? url = null)
        : base(functionContext)
    {
        Body = body ?? new MemoryStream();
        Headers = new HttpHeadersCollection();
        Cookies = new List<IHttpCookie>();
        Url = new Uri(url ?? "https://localhost");
        Identities = new List<ClaimsIdentity>();
        Method = method;
    }

    public override Stream Body { get; }

    public override HttpHeadersCollection Headers { get; }

    public override IReadOnlyCollection<IHttpCookie> Cookies { get; }

    public override Uri Url { get; }

    public override IEnumerable<ClaimsIdentity> Identities { get; }

    public override string Method { get; }

    public override HttpResponseData CreateResponse()
    {
        return new FakeHttpResponseData(FunctionContext, HttpStatusCode.OK);
    }
}
