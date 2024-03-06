using Typstio.Core.Contracts;
using Typstio.Core.Models;
using Typstio.Core.Scripting;

namespace Typstio.Core.Services;

public static class SetRule
{
    public static ISetRule FromElementFunction(ITypstFunction function)
    {
        var arguments = function.Arguments.Where(x => x is not ContentArgument or ContentArgumentWithName).ToArray();
        return new SetRuleWrapper(function.Name, arguments);
    }

    private record SetRuleWrapper(string Name, IEnumerable<SignatureArgument> Arguments) : ISetRule;
}