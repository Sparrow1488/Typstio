using Typstio.Core.Contracts;
using Typstio.Core.Functions.Text;
using Typstio.Core.Writers;

namespace Typstio.Core.Extensions;

public static class ContentWriterExtensions
{
    public static ContentWriter Linebreak(this ContentWriter writer, bool pretty = true)
    {
        return !pretty ? writer.Write(new Linebreak()) : writer.WriteString(" \\ ");
    }
    
    public static ContentWriter Write(this ContentWriter writer, IContentWritable writable, object? context = null)
    {
        writable.WriteToContent(writer, context);
        return writer;
    }
}