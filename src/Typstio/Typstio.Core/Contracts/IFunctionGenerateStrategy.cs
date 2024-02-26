using System.Text;
using Typstio.Core.Models;
using Typstio.Core.Scripting;

namespace Typstio.Core.Contracts;

public interface IFunctionGenerateStrategy
{
    void WriteFuncName(StringBuilder builder, TypstFunction function);
    bool WriteFuncArgument(StringBuilder builder, FunctionArgument arg, TypstFunction function);
}