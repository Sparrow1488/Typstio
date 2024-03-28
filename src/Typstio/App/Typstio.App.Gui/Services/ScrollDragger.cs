using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Typstio.App.Gui.Services;

public class ScrollDragger : IDisposable
{
    readonly ScrollViewer _scrollViewer;
    readonly UIElement _content;
    Point _scrollMousePoint;
    double _verticalOffset;
    double _horizontalOffset;

    ScrollDragger(UIElement content, ScrollViewer scrollViewer)
    {
        _scrollViewer = scrollViewer;
        _content = content;
        content.PreviewMouseLeftButtonDown += MouseLeftButtonDown;
        content.PreviewMouseMove += PreviewMouseMove;
    }

    public static IDisposable Subscribe(UIElement content, ScrollViewer scrollViewer)
    {
        return new ScrollDragger(content, scrollViewer);
    }

    void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _scrollMousePoint = e.GetPosition(_scrollViewer);
        _verticalOffset = _scrollViewer.VerticalOffset;
        _horizontalOffset = _scrollViewer.HorizontalOffset;
    }

    void PreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton != MouseButtonState.Pressed) return;
        
        var newOffset = _verticalOffset + (_scrollMousePoint.Y - e.GetPosition(_scrollViewer).Y);
        _scrollViewer.ScrollToVerticalOffset(newOffset);
            
        newOffset = _horizontalOffset + (_scrollMousePoint.X - e.GetPosition(_scrollViewer).X);
        _scrollViewer.ScrollToHorizontalOffset(newOffset);
    }

    public void Dispose()
    {
        _content.PreviewMouseLeftButtonDown -= MouseLeftButtonDown;
        _content.PreviewMouseMove -= PreviewMouseMove;
    }
}