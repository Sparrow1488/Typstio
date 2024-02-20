namespace Typstio.Core.Types;

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

    private string? Value { get; }
    
    public override string ToString()
    {
        return $"\"{Value}\"";
    }
}
