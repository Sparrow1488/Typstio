namespace Typstio.App.Gui;

public interface IDataBindable
{
    void Bind(DataTemplate template, IEnumerable<IData> data);
}