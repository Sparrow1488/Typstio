namespace Typstio.App.Gui.Data;

public class MockData : IData
{
    public MockData(IReadOnlyDictionary<string, object> content)
    {
        Content = content;
    }

    public IReadOnlyDictionary<string, object>? Content { get; }
    
    public Task<LoadResult> LoadAsync(string[] keys)
    {
        return Task.FromResult(new LoadResult(true, Array.Empty<string>()));
    }
}