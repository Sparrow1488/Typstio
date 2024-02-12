using System.Text;

namespace Typstio.Core;

public class Report
{
    private readonly List<Container> _containers = new();
    
    public IReadOnlyCollection<Container> Containers => _containers;

    public Report Add(Container container)
    {
        _containers.Add(container);
        return this;
    }

    public string ConvertToTypst()
    {
        var builder = new StringBuilder();

        foreach (var container in Containers)
        {
            builder.AppendLine(container.ToTypst());
            builder.AppendLine(); // End of container
        }

        return builder.ToString();
    }
}