namespace Typstio.Core.Services.Strategies;

public class ArgumentGenerateStrategy : ContentGenerateStrategy
{
    public ArgumentGenerateStrategy(CodeGenerator generator) : base(generator)
    {
    }

    protected override string KeywordOrNamePrefix => string.Empty;
}