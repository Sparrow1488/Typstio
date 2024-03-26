using Typstio.Core.Contracts;

namespace Typstio.Core.Models;

public interface ITypstFunction : ISignature, IContentWritable
{
    void IContentWritable.WriteToContent(ContentWriter writer)
    {
        writer.WriteFunction(this);
    }
}

public abstract class TypstFunction : SignatureBase, ITypstFunction
{
    protected TypstFunction(string name) : base(name)
    {
        
    }

    public void WriteToContent(ContentWriter writer)
    {
        ((IContentWritable)this).WriteToContent(writer);
    }
}