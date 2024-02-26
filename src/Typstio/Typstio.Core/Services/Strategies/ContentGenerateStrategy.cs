using System.Text;
using Typstio.Core.Contracts;
using Typstio.Core.Defaults;
using Typstio.Core.Models;
using Typstio.Core.Scripting;

namespace Typstio.Core.Services.Strategies;

public class ContentGenerateStrategy : IFunctionGenerateStrategy
{
    private readonly CodeGenerator _generator;

    public ContentGenerateStrategy(CodeGenerator generator)
    {
        _generator = generator;
    }
    
    public virtual void WriteFuncName(StringBuilder builder, TypstFunction function)
    {
        builder.Append(Tokens.Hash);
        builder.Append(function.Name);
    }

    public bool WriteFuncArgument(StringBuilder builder, FunctionArgument arg, TypstFunction function)
    {
        var handled = true;

        if (arg is ArgumentWithName {Value: { }} namedArg)
        {
            builder.Append(namedArg.Name).Append(Tokens.Colon).Append(Tokens.Space);

            if (namedArg is ContentArgumentWithName contentNamedArg)
            {
                _generator.WriteContent(ArgumentContext.Value, contentNamedArg.Content);
            }
            else if (namedArg is FunctionArgumentWithName funcArg)
            {
                _generator.WriteFunction(ArgumentContext.Value, funcArg.Function!);
            }
            else
            {
                builder.Append(namedArg.Value);
            }
        }
        else if (arg is ContentArgument contentArg)
        {
            _generator.WriteContent(ArgumentContext.Value, contentArg.Content);
        }
        else if (arg is PositionalArgument positionalArg)
        {
            builder.Append(positionalArg.Value);
        }
        else
        {
            handled = false;
        }

        return handled;
    }
}