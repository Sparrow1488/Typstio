namespace Typstio.Core.Foundations;

public readonly record struct Arr(IEnumerable<object> Items)
{
    public override string ToString()
    {
        var inline = string.Join(", ", Items);
        return $"({inline})";
    }
}