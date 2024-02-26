using Typstio.Core.Models;

namespace Typstio.Core.Contracts;

public interface IContentWritable
{
    void WriteToContent(ContentWriter writer);
}