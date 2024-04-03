namespace Typstio.App.Gui.Data;

public interface IDataSource
{
    Task<IData> ProvideAsync();
}