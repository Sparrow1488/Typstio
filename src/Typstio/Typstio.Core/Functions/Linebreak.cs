using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Linebreak : ElementFunction, IContentWritable
{
    public void WriteToContent(ContentWriter writer)
    {
        writer.WriteFunction(new FunctionBuilder("linebreak"));
    }
}