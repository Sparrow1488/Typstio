using System.Text;
using Typstio.Core.Context;
using Typstio.Core.Contracts;
using static Typstio.Core.Defaults.Tokens;

namespace Typstio.Core.Writers;

public class CodeGenerator
{
    private readonly StringBuilder _builder = new();
    
    public void WriteContent(GenContext context, ContentWriter content)
    {
        var contentWithOneElement = content.Elements.Count == 1;
        var contentCanBeSimplified = contentWithOneElement || context is DocumentContext;

        if (!contentCanBeSimplified)
        {
            context = new ContentContext();
            _builder.Append(OpenBracket);
        }
        
        foreach (var element in content.Elements)
        {
            if (element is TypstFunction function)
                WriteFunction(context, function);
            if (element is string @string)
                WriteString(@string, contentWithOneElement);
        }
        
        if (!contentCanBeSimplified)
            _builder.Append(CloseBracket);
    }

    private void WriteString(string @string, bool simplifyContentToString)
    {
        if (simplifyContentToString)
        {
            _builder.Append('"').Append(@string).Append('"');
        }
        else
        {
            _builder.Append(@string);
        }
    }

    public void WriteFunction(GenContext context, TypstFunction function)
    {
        IContentGenerateStrategy strategy = new DefaultGenerateStrategy(this);
        
        if (context is ArgumentContext)
        {
            strategy = new ArgumentGenerateStrategy(this);
        }
        
        strategy.WriteFuncName(_builder, function);

        _builder.Append(OpenParen);
        
        var args = function.Args.ToList();

        foreach (var argument in args)
        {
            var handled = strategy.WriteFuncArgument(_builder, argument, function);
            
            var nextArgIndex = args.IndexOf(argument) + 1;
            var hasNext = nextArgIndex < args.Count;
            
            if (hasNext && args[nextArgIndex].HasValue && handled)
                _builder.Append(Comma).Append(Space);
        }
        
        _builder.Append(CloseParen);
    }

    public override string ToString()
    {
        return _builder.ToString();
    }
}