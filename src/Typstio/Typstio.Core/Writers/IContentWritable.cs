namespace Typstio.Core.Writers;

public interface IContentWritable
{
    void WriteToContent(ContentWriter writer, object? context = null);
}