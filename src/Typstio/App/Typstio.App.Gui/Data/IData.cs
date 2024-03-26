namespace Typstio.App.Gui.Data;

public record DataTemplate(IReadOnlyList<string> Fields);

public interface IData
{
    IReadOnlyDictionary<string, object?>? Content { get; }
    Task<LoadResult> LoadAsync(string[] keys);
}

public record LoadResult(bool Ok, string[] Failures);