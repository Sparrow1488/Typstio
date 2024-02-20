namespace Typstio.Core.Types;

public record struct Str(string Value)
{
    public override string ToString()
    {
        return $"\"{Value}\"";
    }
}
