namespace Typstio.Core;

public class Title : Container
{
    public Title(string text, int level)
    {
        Text = text;
        Level = level;
    }
    
    public string Text { get; }
    public int Level { get; }
    
    public override string ToTypst()
    {
        return string.Join("", Enumerable.Range(1, Level).Select(_ => "=")) + " " + Text;
    }
}