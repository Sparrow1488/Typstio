using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Typstio.App.Gui.Contracts;
using Typstio.Core.Contracts;
using Typstio.Core.Models;

namespace Typstio.App.Gui.Views.Controls.Content;

public class Text : TextBox, IContentWritable, IProvideFieldName
{
    public Text()
    {
        Background = Brushes.Transparent;
        BorderBrush = Brushes.Transparent;
        BorderThickness = new Thickness(0);
    }
    
    public void WriteToContent(ContentWriter writer)
    {
        new Core.Functions.Text.Text(
            c => c.WriteString(Text)
        ).WriteToContent(writer);
    }

    public string? GetFieldName()
    {
        var match = Regex.Match(Text, @"\[(.*?)\]");
        
        if (match is not {Success: true, Groups.Count: > 0}) 
            return null;
        
        var group = match.Groups[0];
        return group.Value.Replace("[", string.Empty).Replace("]", string.Empty);
    }
}