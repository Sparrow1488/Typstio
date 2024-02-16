using System.Text;

namespace Typstio.Core.Contracts;

public abstract class Function
{
    public abstract void Append(object? context, StringBuilder builder);
}