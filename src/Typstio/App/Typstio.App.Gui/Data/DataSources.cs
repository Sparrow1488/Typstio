using System.Collections.ObjectModel;
using Typstio.App.Gui.Contracts;

namespace Typstio.App.Gui.Data;

public class DataSources : IDataSources
{
    public ObservableCollection<IDataSource> Sources { get; } = new();
}