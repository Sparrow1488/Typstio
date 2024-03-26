using Typstio.Core.Foundations;
using Typstio.Core.Models;
using Typstio.Core.Scripting;

namespace Typstio.Core.Extensions;

public static class SignatureBuilderExtensions
{
    public static void Argument(this SignatureBuilder builder, object? value, bool required = false)
    {
        builder.AddArgumentIfValid(new PositionalArgument(value, IsRequired: required), value, required);
    }

    public static void Argument(this SignatureBuilder builder, string name, Str value, bool required = false)
    {
        if (!string.IsNullOrWhiteSpace(value.Value))
        {
            builder.Argument(name, (object)value, required);
        }
    }

    public static void Argument(this SignatureBuilder builder, string name, object? value, bool required = false)
    {
        builder.AddArgumentIfValid(new ArgumentWithName(name, value, IsRequired: required), value, required);
    }

    public static void ArgumentFunc(this SignatureBuilder builder, string name, TypstFunction? func, bool required = false)
    {
        builder.AddArgumentIfValid(new FunctionArgumentWithName(name, func, IsRequired: required), func, required);
    }
    
    public static void Content(this SignatureBuilder builder, Content content)
    {
        builder.WithContent(content);
    }

    public static void Content(this SignatureBuilder builder, IEnumerable<Content> contents)
    {
        builder.WithContents(contents);
    }

    public static void Argument(this SignatureBuilder builder, string name, Content? value, bool required = false)
    {
        var content = new ContentWriter();
        value?.Invoke(content);
        builder.AddArgumentIfValid(new ContentArgumentWithName(name, content, required), value, required);
    }
    
    private static void AddArgumentIfValid(this SignatureBuilder builder, SignatureArgument arg, object? value, bool required)
    {
        Require(value, required);

        if (value is not null)
            builder.WithArgument(arg);
    }

    private static void Require(object? value, bool required)
    {
        if (required && value is null)
            throw new ArgumentException("Value should not be null");
    }
}