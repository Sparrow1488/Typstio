using Typstio.Core.Contracts;

namespace Typstio.Core.Functions.Text;

public class Lorem : TypstFunction
{
    public Lorem(int words) : base("lorem")
    {
        Argument(words, required: true);
    }
}