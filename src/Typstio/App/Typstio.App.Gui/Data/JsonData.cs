using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Typstio.App.Gui.Data;

public class JsonData : IData
{
    readonly string _jsonPath;

    public JsonData(string jsonPath)
    {
        _jsonPath = jsonPath;
    }
    
    public IReadOnlyDictionary<string, object?>? Content { get; private set; }
    
    public async Task<LoadResult> LoadAsync(string[] keys)
    {
        var dict = new Dictionary<string, object?>();
        
        var json = await File.ReadAllTextAsync(_jsonPath);
        var jArray = new JArray(JsonConvert.DeserializeObject(json)!).ToArray();

        for (var i = 0; i < jArray.Length; i++)
        {
            var token = jArray[0][i];
            var phone = token["Phones"];
            var a = phone?[0];
        }

        Content = dict;

        return new LoadResult(true, Array.Empty<string>());
    }
}