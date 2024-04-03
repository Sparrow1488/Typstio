using System.Collections.ObjectModel;
using Typstio.App.Gui.Data;

namespace Typstio.App.Gui.Contracts;

public interface IDataSources
{
    ObservableCollection<IDataSource> Sources { get; }
}