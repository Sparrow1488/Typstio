using Typstio.Core.Extensions;
using Typstio.Core.Models;

namespace Typstio.Core.Functions.Text;

public class Lorem : TypstFunction
{
    public Lorem(int words) : base("lorem")
    {
        Builder.Argument(words, required: true);
    }
}