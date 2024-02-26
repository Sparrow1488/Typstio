namespace Typstio.Core.Defaults;

public record GenContext;

public record ArgumentContext : GenContext
{
    public static readonly ArgumentContext Value = new();
}

public record ContentContext : GenContext
{
    public static readonly ContentContext Value = new();
}

public record DocumentContext : GenContext
{
    public static readonly DocumentContext Value = new();
}