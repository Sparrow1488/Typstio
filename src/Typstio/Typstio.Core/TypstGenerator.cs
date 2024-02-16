using System.Text;
using Typstio.Core.Contracts;
using Typstio.Core.Elements;
using Typstio.Core.Functions;

namespace Typstio.Core;

public static class TypstGenerator
{
    public static string Generate(Component rootComponent)
    {
        var builder = new StringBuilder();

        foreach (var element in rootComponent.Elements)
        {
            if (element is Title title)
            {
                var lines = string.Concat(Enumerable.Range(1, title.Level).Select(_ => "="));
                builder.AppendLine(lines + " " + title.Text);
            }

            if (element is Text text)
            {
                builder.AppendLine(text.Text);
            }

            if (element is List list)
            {
                var listBuilder = new StringBuilder();
                AppendItems(0, list.Items, listBuilder);
                builder.AppendLine(listBuilder.ToString());
            }

            if (element is Table table)
            {
                var function = new TableFunction(table);
                function.Append(null, builder);
            }

            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static void AppendItems(int nestedLevel, IEnumerable<ListItem> items, StringBuilder builder)
    {
        foreach (var item in items)
        {
            var tabs = string.Concat(Enumerable.Range(0, nestedLevel).Select(_ => Tokens.Tab));
            var style = item.Style switch
            {
                ItemStyle.Numeric => "*",
                ItemStyle.Line => "--",
                ItemStyle.Dot => "-"
            };
            builder.AppendLine(tabs + style + " " + item.Text);
            AppendItems(nestedLevel + 1, item.Nested, builder);
        }
    }
}