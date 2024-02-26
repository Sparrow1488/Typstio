using Typstio.Core.Contracts;
using Typstio.Core.Extensions;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions.Containers;

public class Figure : TypstFunction
{
    public Figure(Content content, Content caption) : base("figure")
    {
        Argument("caption", caption);
        Content(content);
    }

    public Figure(TypstFunction function, string text) : this(c => c.Write(function), cap => cap.WriteString(text))
    {
        
    }
}