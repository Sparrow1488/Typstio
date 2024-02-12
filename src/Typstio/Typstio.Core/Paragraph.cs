namespace Typstio.Core;

public class Paragraph : Container
{
    public Paragraph(string text)
    {
        Text = text;
    }
    
    public string Text { get; }
    
    public override string ToTypst()
    {
        return Text;
    }
}