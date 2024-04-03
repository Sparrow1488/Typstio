using System.Data;

namespace Typstio.App.Gui.Data;

public interface IData
{
    bool IsLoaded { get; }
    DataTable? Data { get; }
    Task<bool> LoadAsync();
}

public interface IDataRow
{
    public string Name { get; }
    public object? Value { get; }
}