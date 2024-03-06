using System.Text;
using Typstio.Core.Contracts;
using Typstio.Core.Defaults;
using Typstio.Core.Models;
using Typstio.Core.Scripting;
using Typstio.Core.Services.Strategies;
using static Typstio.Core.Defaults.Tokens;

namespace Typstio.Core;

public class CodeGenerator
{
    private readonly StringBuilder _builder = new();

    public static string ToCode(ContentWriter document)
    {
        var generator = new CodeGenerator();
        generator.WriteContent(DocumentContext.Value, document);
        
        return generator.ToString();
    }
    
    public void WriteContent(GenContext context, ContentWriter content)
    {
        var contentWithOneElement = content.Elements.Count == 1;
        var contentCanBeSimplified = contentWithOneElement || context is DocumentContext;

        if (!contentCanBeSimplified)
        {
            context = ContentContext.Value;
            _builder.Append(OpenBracket);
        }
        
        foreach (var element in content.Elements)
        {
            if (element is ITypstFunction function)
                WriteFunction(context, function);
            if (element is ISetRule setRule)
                WriteSetRule(context, setRule);
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

    public void WriteFunction(GenContext context, ITypstFunction function)
    {
        WriteSignature(GetGenerateStrategy(context), function);
    }

    private void WriteSetRule(GenContext context, ISetRule rule)
    {
        RequireNoContent(rule);

        var strategy = GetGenerateStrategy(context);
        
        strategy.WriteKeyword(_builder, SetKeyword);
        WriteSignature(strategy, rule);
    }

    private void WriteSignature(ISignatureGenerateStrategy strategy, ISignature signature)
    {
        strategy.WriteName(_builder, signature);

        _builder.Append(OpenParen);
        
        var args = signature.Arguments.ToList();

        foreach (var argument in args)
        {
            var handled = strategy.WriteArgument(_builder, argument, signature);
            
            var nextArgIndex = args.IndexOf(argument) + 1;
            var hasNext = nextArgIndex < args.Count;
            
            if (hasNext && args[nextArgIndex].HasValue && handled)
                _builder.Append(Comma).Append(Space);
        }
        
        _builder.Append(CloseParen);
    }
    
    private ISignatureGenerateStrategy GetGenerateStrategy(GenContext context)
    {
        ISignatureGenerateStrategy strategy = new ContentGenerateStrategy(this);
        
        if (context is ArgumentContext)
        {
            strategy = new ArgumentGenerateStrategy(this);
        }

        return strategy;
    }

    private static void RequireNoContent(ISignature signature)
    {
        foreach (var argument in signature.Arguments)
        {
            if (argument is ContentArgument or ContentArgumentWithName)
            {
                throw new InvalidOperationException("This implementation should be without content argument");
            }
        }
    }

    public override string ToString()
    {
        return _builder.ToString();
    }
}