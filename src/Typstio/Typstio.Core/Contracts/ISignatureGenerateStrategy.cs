using System.Text;
using Typstio.Core.Scripting;

namespace Typstio.Core.Contracts;

public interface ISignatureGenerateStrategy
{
    void WriteKeyword(StringBuilder builder, string keyboard);
    void WriteName(StringBuilder builder, ISignature signature);
    bool WriteArgument(StringBuilder builder, SignatureArgument arg, ISignature signature);
}