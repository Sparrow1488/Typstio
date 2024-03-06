using Typstio.Core.Scripting;

namespace Typstio.Core.Contracts;

public interface ISignature
{
    string Name { get; }
    IEnumerable<SignatureArgument> Arguments { get; }
}