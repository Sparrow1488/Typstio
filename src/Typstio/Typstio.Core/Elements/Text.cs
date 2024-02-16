using Typstio.Core.Contracts;

namespace Typstio.Core.Elements;

public abstract class TextElement : Element
{
    protected TextElement(string text)
    {
        Text = text;
    }
    
    public string Text { get; }
}

public class Text : TextElement
{
    public Text(string text) : base(text)
    {
    }
}

public class Title : TextElement
{
    public Title(string text, int level) : base(text)
    {
        Level = level;
    }
    
    public int Level { get; }
}