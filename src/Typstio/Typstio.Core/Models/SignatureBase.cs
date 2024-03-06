using Typstio.Core.Contracts;
using Typstio.Core.Scripting;

namespace Typstio.Core.Models;

public abstract class SignatureBase : ISignature
{
    protected SignatureBase(string name)
    {
        Builder = new SignatureBuilder(name);
    }

    public string Name => Builder.Name;
    public IEnumerable<SignatureArgument> Arguments => Builder.Arguments;
    protected SignatureBuilder Builder { get; }
}