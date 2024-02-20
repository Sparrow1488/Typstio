namespace Typstio.Core.Writers;

public interface IContentWritable
{
    void WriteToDocument(ContentWriter writer);
}