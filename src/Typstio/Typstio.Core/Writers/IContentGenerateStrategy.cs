using System.Text;
using Typstio.Core.Context;
using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using static Typstio.Core.Defaults.Tokens;

namespace Typstio.Core.Writers;

public interface IContentGenerateStrategy
{
    void WriteFuncName(StringBuilder builder, TypstFunction function);
    bool WriteFuncArgument(StringBuilder builder, FuncArg arg, TypstFunction function);
}

public class DefaultGenerateStrategy : IContentGenerateStrategy
{
    private readonly CodeGenerator _generator;

    public DefaultGenerateStrategy(CodeGenerator generator)
    {
        _generator = generator;
    }
    
    public virtual void WriteFuncName(StringBuilder builder, TypstFunction function)
    {
        builder.Append(Hash);
        builder.Append(function.Name);
    }

    public bool WriteFuncArgument(StringBuilder builder, FuncArg arg, TypstFunction function)
    {
        var handled = true;

        if (arg is NamedArg {Value: { }} namedArg)
        {
            builder.Append(namedArg.Name).Append(Colon).Append(Space);

            if (namedArg is ContentNamedArg contentNamedArg)
            {
                var oneElement = contentNamedArg.Content.Elements.Count == 1;
                var simplifyToString = contentNamedArg.Content.Elements.FirstOrDefault() is string;
                
                if (oneElement && simplifyToString)
                {
                    builder.Append('"').Append(namedArg.Value).Append('"');
                }
                else
                {
                    builder.Append(OpenBracket).Append(namedArg.Value).Append(CloseBracket);
                }
            }
            else if (namedArg is FunctionNamedArg funcArg)
            {
                _generator.WriteFunction(new ArgumentContext(), funcArg.Function!);
                // funcArg.Function?.WriteToContent(this, new ArgumentContext());
            }
            else
            {
                builder.Append(namedArg.Value);
            }
        }
        else if (arg is ContentArg contentArg)
        {
            _generator.WriteContent(new ArgumentContext(), contentArg.Content);
            // builder.Append(OpenBracket).Append(contentArg.Value).Append(CloseBracket);
        }
        else if (arg is PositionalArg positionalArg)
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

public class ArgumentGenerateStrategy : DefaultGenerateStrategy
{
    public ArgumentGenerateStrategy(CodeGenerator generator) : base(generator)
    {
    }

    public override void WriteFuncName(StringBuilder builder, TypstFunction function)
    {
        builder.Append(function.Name);
    }
}