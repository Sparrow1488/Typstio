using System.Text;
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
        writable.WriteToDocument(this);
        return this;
    }

    public ContentWriter WriteFunction(FunctionBuilder function)
    {
        const string prefix = "#";
        
        _builder.Append(prefix).Append(function.Name).Append(OpenParen);

        var currentArg = 1;
        foreach (var arg in function.Args.OrderBy(x => x is PositionalArg))
        {
            var skip = false;

            if (arg is NamedArg {Value: { }} namedArg)
            {
                _builder.Append(namedArg.Name).Append(Colon).Append(Space).Append(namedArg.Value);
            }
            else if (arg is PositionalArg positionalArg)
            {
                _builder.Append(OpenBracket).Append(positionalArg.Value).Append(CloseBracket);
            }
            else
            {
                skip = true;
            }

            currentArg++;
            
            if (skip) continue;
            
            if (currentArg <= function.Args.Count)
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