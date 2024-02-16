
using Typstio.Core;
using Typstio.Core.Contracts;
using Typstio.Core.Elements;

var root = new Component();

root.AddElement(new Title("Introduction", 1));

root.AddElement(new Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat"));

root.AddElement(
    new List()
        .AddItem(new ListItem("Alex", ItemStyle.Numeric)
            .Add(new ListItem("Alex-2", ItemStyle.Line))
            .Add(new ListItem("Alex-3", ItemStyle.Line))
        )
        .AddItem(new ListItem("Bob", ItemStyle.Numeric)
            .Add(new ListItem("Bob-2", ItemStyle.Line)
                .Add(new ListItem("Bob-2-1", ItemStyle.Dot))
            )
        )
);

var data = new List<Dictionary<string, object>>
{
    new()
    {
        { "Id", "1" },
        { "Name", "Alex" }
    },
    new()
    {
        { "Id", "2" },
        { "Name", "Bob" }
    },
    new()
    {
        { "Id", "3" },
        { "Name", "Clark" }
    }
};
root.AddElement(new Table(new[] { "Id", "Name" }, data));

Console.WriteLine(TypstGenerator.Generate(root));