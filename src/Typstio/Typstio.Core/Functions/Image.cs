using Typstio.Core.Contracts;
using Typstio.Core.Scripting;
using Typstio.Core.Types;
using Typstio.Core.Writers;

namespace Typstio.Core.Functions;

public class Image : ElementFunction, IContentWritable
{
    private const string Name = "image";
    private const string WidthArg = "width";
    private const string HeightArg = "height";
    
    private readonly string _str;
    private readonly string? _width;
    private readonly string? _height;
    
    /// <summary>
    /// Функция изображения
    /// </summary>
    /// <param name="str">Путь до изображения</param>
    /// <param name="width">Ширина (auto, relative)</param>
    /// <param name="height">Высота (auto, relative)</param>
    public Image(string str, string? width = null, string? height = null)
    {
        _str = str;
        _width = width;
        _height = height;
    }
    
    public void WriteToContent(ContentWriter writer)
    {
        writer.WriteFunction(
            new FunctionBuilder(Name)
                .WithArg(new PositionalArg(new Str(_str), IsRequired: true))
                .WithArg(new NamedArg(WidthArg, _width))
                .WithArg(new NamedArg(HeightArg, _height))
        );
    }
}