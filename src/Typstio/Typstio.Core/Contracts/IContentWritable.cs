using Typstio.Core.Writers;

namespace Typstio.Core.Contracts;

public interface IContentWritable
{
    void WriteToContent(ContentWriter writer, object? context = null);
}