using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Typstio.App.Gui.Services;

public class ScrollDragger : IDisposable
{
    private readonly ScrollViewer _scrollViewer;
    private readonly UIElement _content;
    private Point _scrollMousePoint;
    private double _verticalOffset = 1;
    private double _horizontalOffset = 1;

    private ScrollDragger(UIElement content, ScrollViewer scrollViewer)
    {
        _scrollViewer = scrollViewer;
        _content = content;
        content.MouseLeftButtonDown += MouseLeftButtonDown;
        content.PreviewMouseMove += PreviewMouseMove;
        content.PreviewMouseLeftButtonUp += PreviewMouseLeftButtonUp;
    }

    public static IDisposable Subscribe(UIElement content, ScrollViewer scrollViewer)
    {
        return new ScrollDragger(content, scrollViewer);
    }

    private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _content.CaptureMouse();
        _scrollMousePoint = e.GetPosition(_scrollViewer);
        _verticalOffset = _scrollViewer.VerticalOffset;
        _horizontalOffset = _scrollViewer.HorizontalOffset;
    }

    private void PreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (_content.IsMouseCaptured)
        {
            var newOffset = _verticalOffset + (_scrollMousePoint.Y - e.GetPosition(_scrollViewer).Y);
            _scrollViewer.ScrollToVerticalOffset(newOffset);
            
            newOffset = _horizontalOffset + (_scrollMousePoint.X - e.GetPosition(_scrollViewer).X);
            _scrollViewer.ScrollToHorizontalOffset(newOffset);
        }
    }

    private void PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _content.ReleaseMouseCapture();
    }

    public void Dispose()
    {
    }
}