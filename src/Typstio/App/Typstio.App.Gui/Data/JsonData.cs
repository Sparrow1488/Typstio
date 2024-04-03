using System.Data;
using Newtonsoft.Json;

namespace Typstio.App.Gui.Data;

public class JsonData : IData
{
    readonly string _json;

    public JsonData(string json)
    {
        _json = json;
    }

    public bool IsLoaded => Data is not null;
    public DataTable? Data { get; private set; }
    
    public Task<bool> LoadAsync()
    {
        Data = JsonConvert.DeserializeObject<DataTable>(_json);
        return Task.FromResult(Data is not null);
    }

    public IDataRow[] GetRows()
    {
        if (!IsLoaded || Data is null) throw new Exception();
        
        using var reader = Data.CreateDataReader();
        var rows = new List<IDataRow>();

        if (!reader.HasRows) 
            return rows.ToArray();
        
        while (reader.Read())
            for (var i = 0; i < reader.FieldCount; i++)
                rows.Add(new DataRow(reader.GetName(i), reader.GetValue(i)));

        return rows.ToArray();
    }
}

public record DataRow(string Name, object? Value) : IDataRow;