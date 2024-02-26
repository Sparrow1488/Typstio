using Typstio.Core.Contracts;
using Typstio.Core.Functions.Text;
using Typstio.Core.Models;

namespace Typstio.Core.Extensions;

public static class ContentWriterExtensions
{
    public static ContentWriter Linebreak(this ContentWriter writer, bool pretty = true)
    {
        return !pretty ? writer.Write(new Linebreak()) : writer.WriteString(" \\ ");
    }
    
    public static ContentWriter Write(this ContentWriter writer, IContentWritable writable)
    {
        writable.WriteToContent(writer);
        return writer;
    }
}