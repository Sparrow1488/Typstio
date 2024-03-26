namespace Typstio.App.Gui;

public record DataTemplate(IReadOnlyList<string> Fields);

public interface IData
{
    IReadOnlyDictionary<string, object>? Content { get; }
    Task LoadAsync();
}

public class MockData : IData
{
    public MockData(IReadOnlyDictionary<string, object> content)
    {
        Content = content;
    }

    public IReadOnlyDictionary<string, object>? Content { get; }
    
    public Task LoadAsync()
    {
        return Task.CompletedTask;
    }
}
