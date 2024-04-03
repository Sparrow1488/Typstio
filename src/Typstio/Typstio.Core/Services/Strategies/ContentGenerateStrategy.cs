using System.Text;
using Typstio.Core.Contracts;
using Typstio.Core.Defaults;
using Typstio.Core.Scripting;
using static Typstio.Core.Defaults.Tokens;

namespace Typstio.Core.Services.Strategies;

public class ContentGenerateStrategy : ISignatureGenerateStrategy
{
    readonly CodeGenerator _generator;
    bool _hasKeyword;

    public ContentGenerateStrategy(CodeGenerator generator)
    {
        _generator = generator;
    }

    protected virtual string KeywordOrNamePrefix => Hash;

    public void WriteKeyword(StringBuilder builder, string keyboard)
    {
        _hasKeyword = true;
        
        builder.Append(KeywordOrNamePrefix);
        builder.Append(keyboard);
        builder.Append(Space);
    }

    public virtual void WriteName(StringBuilder builder, ISignature signature)
    {
        if (!_hasKeyword)
        {
            builder.Append(KeywordOrNamePrefix);
        }
        
        builder.Append(signature.Name);
    }

    public bool WriteArgument(StringBuilder builder, SignatureArgument arg, ISignature signature)
    {
        var handled = true;

        if (arg is ArgumentWithName {Value: { }} namedArg)
        {
            builder.Append(namedArg.Name).Append(Colon).Append(Space);

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