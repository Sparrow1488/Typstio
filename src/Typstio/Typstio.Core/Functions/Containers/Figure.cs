using Typstio.Core.Extensions;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Containers;

public class Figure : TypstFunction
{
    public Figure(Content content, Content caption) : base("figure")
    {
        Builder.Argument("caption", caption);
        Builder.Content(content);
    }

    public Figure(TypstFunction function, string text) : this(c => c.Write(function), cap => cap.WriteString(text))
    {
        
    }
}