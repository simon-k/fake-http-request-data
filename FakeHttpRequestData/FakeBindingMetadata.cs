using Microsoft.Azure.Functions.Worker;

namespace FakeHttpRequestData;

public class FakeBindingMetadata : BindingMetadata
{
    public FakeBindingMetadata(string type, BindingDirection direction)
    {
        Type = type;
        Direction = direction;
    }

    public override string Name { get; }
    public override string Type { get; }

    public override BindingDirection Direction { get; }
}
