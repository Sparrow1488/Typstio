using Typstio.Core.Functions;
using Typstio.Core.Functions.Text;
using Typstio.Core.Writers;

namespace Typstio.Core.Extensions;

public static class ContentWriterExtensions
{
    public static ContentWriter Linebreak(this ContentWriter writer)
    {
        return writer.Write(new Linebreak());
    }
}