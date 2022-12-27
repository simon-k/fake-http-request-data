﻿using Microsoft.Azure.Functions.Worker;

namespace FakeHttpRequestData;

class DefaultTraceContext : TraceContext
{
    public DefaultTraceContext(string traceParent, string traceState)
    {
        TraceParent = traceParent;
        TraceState = traceState;
    }

    public override string TraceParent { get; }

    public override string TraceState { get; }
}