using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Typstio.App.Gui.Views.Controls;

// https://www.youtube.com/watch?v=ddVXKMpWGME
public class Highlight : Adorner
{
    const double Out = 2.5;
    
    readonly Rectangle _rect;
    readonly VisualCollection _visuals;

    public Highlight(UIElement element) : base(element)
    {
        _visuals = new VisualCollection(this);

        _rect = new Rectangle { Stroke = Brushes.Black, StrokeThickness = 1, StrokeDashArray = { 3, 2 }};
        element.Focus();

        _visuals.Add(_rect);
    }
    
    protected override int VisualChildrenCount => _visuals.Count;

    protected override Visual GetVisualChild(int index)
    {
        return _visuals[index];
    }

    protected override Size MeasureOverride(Size constraint)
    {
        _rect.Measure(constraint);
        return _rect.DesiredSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        _rect.Arrange(new Rect(-Out, -Out, AdornedElement.DesiredSize.Width + Out*2, AdornedElement.DesiredSize.Height + Out*2));
        return _rect.RenderSize;
    }
}