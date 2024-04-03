using System.IO;

namespace Typstio.App.Gui.Data;

public record JsonDataSource(string FilePath) : IDataSource
{
    public async Task<IData> ProvideAsync() 
        => new JsonData(await File.ReadAllTextAsync(FilePath));
}