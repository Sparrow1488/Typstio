namespace Typstio.Core.Foundations;

public readonly record struct Str
{
    public Str()
    {
        
    }
    
    public Str(string? value)
    {
        Value = value;

        if (value == null)
        {
            this = new Str();
        }
    }

    internal string? Value { get; }
    
    public override string ToString()
    {
        return $"\"{Value}\"";
    }
}
