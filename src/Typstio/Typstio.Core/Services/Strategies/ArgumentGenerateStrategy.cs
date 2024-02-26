using System.Text;
using Typstio.Core.Models;

namespace Typstio.Core.Services.Strategies;

public class ArgumentGenerateStrategy : ContentGenerateStrategy
{
    public ArgumentGenerateStrategy(CodeGenerator generator) : base(generator)
    {
    }

    public override void WriteFuncName(StringBuilder builder, TypstFunction function)
    {
        builder.Append(function.Name);
    }
}