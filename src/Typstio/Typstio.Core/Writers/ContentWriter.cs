using System.Text;
using Typstio.Core.Context;
using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using static Typstio.Core.Defaults.Tokens;

namespace Typstio.Core.Writers;

public class ContentWriter
{
    private readonly StringBuilder _builder;

    public ContentWriter()
    {
        _builder = new StringBuilder();
    }

    public ContentWriter WriteString(string str)
    {
        _builder.Append(str);
        return this;
    }

    public ContentWriter Write(IContentWritable writable)
    {
        writable.WriteToContent(this);
        return this;
    }

    public ContentWriter WriteFunction(object? context, FunctionBuilder function)
    {
        context ??= new ContentContext();

        if (context is ContentContext)
            _builder.Append(Hash);
        
        _builder.Append(function.Name).Append(OpenParen);

        var currentIndex = 0;
        var args = function.Args.ToArray();
        foreach (var arg in args)
        {
            var unhandledArgument = false;

            if (arg is NamedArg {Value: { }} namedArg)
            {
                _builder.Append(namedArg.Name).Append(Colon).Append(Space);

                if (namedArg is ContentNamedArg)
                {
                    _builder.Append(OpenBracket).Append(namedArg.Value).Append(CloseBracket);
                }
                else if (namedArg is FunctionNamedArg funcArg)
                {
                    funcArg.Function?.WriteToContent(this, new ArgumentContext());
                }
                else
                {
                    _builder.Append(namedArg.Value);
                }
            }
            else if (arg is ContentArg contentArg)
            {
                _builder.Append(OpenBracket).Append(contentArg.Value).Append(CloseBracket);
            }
            else if (arg is PositionalArg positionalArg)
            {
                _builder.Append(positionalArg.Value);
            }
            else
            {
                unhandledArgument = true;
            }

            currentIndex++;
            var hasNext = currentIndex < args.Length;
            
            if (hasNext && args[currentIndex].HasValue && !unhandledArgument)
                _builder.Append(Comma).Append(Space);
        }
        
        _builder.Append(CloseParen);

        return this;
    }

    public ContentWriter WriteEmptyBlock()
    {
        _builder.AppendLine();
        _builder.AppendLine();
        return this;
    }

    public override string ToString()
    {
        return _builder.ToString();
    }
}