using System.Windows;
using System.Windows.Controls;
using Typstio.App.Gui.Views.Controls;

namespace Typstio.App.Gui.Services;

public abstract class ControlEditor<TControl> 
    where TControl : UIElement
{
    private const double FontSize = 25;
    
    private StackPanel? _main;

    public void Edit(TControl control)
    {
        _main = new StackPanel();
        
        PrepareFields(control);
    }
    
    protected abstract void PrepareFields(TControl control);
    protected abstract void OnEdit(TControl control);

    protected void AddField<T>(string name, T startValue, Action<T> callback)
    {
        if (_main is null) throw new Exception();

        var row = new StackPanel { Orientation = Orientation.Horizontal };
        
        // Field name
        row.Children.Add(new TextBlock
        {
            Text = name,
            FontSize = FontSize
        });

        row.Children.Add(CreateTypeEditor(typeof(T), startValue));
        
        foreach (FrameworkElement element in row.Children)
        {
            element.VerticalAlignment = VerticalAlignment.Center;
        }
        
        _main.Children.Add(row);
    }

    private static FrameworkElement CreateTypeEditor(Type type, object? startValue)
    {
        if (type == typeof(string))
        {
            return new TextBox
            {
                FontSize = FontSize,
                Text = startValue?.ToString()
            };
        }

        throw new NotImplementedException();
    }
}

public class TextEditor : ControlEditor<Text>
{
    protected override void PrepareFields(Text control)
    {
        AddField("Текст", control.Text, text => control.Text = text);
    }

    protected override void OnEdit(Text control)
    {
        throw new NotImplementedException();
    }
}