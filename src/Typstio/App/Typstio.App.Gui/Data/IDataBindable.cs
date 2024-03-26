namespace Typstio.App.Gui.Data;

public interface IDataBindable
{
    void Bind(DataTemplate template, IEnumerable<IData> data);
}