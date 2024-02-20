using Typstio.Core.Extensions;
using Typstio.Core.Functions;
using Typstio.Core.Writers;

var document = new ContentWriter();

new Heading(1, content => content.WriteString("Introduction")).WriteToContent(document);
document.WriteEmptyBlock();

new Text(WriteTextContent).WriteToContent(document);
document.WriteEmptyBlock();

new BulletList(GetItems()).WriteToContent(document);
document.WriteEmptyBlock();

var image = new Image("profile.jpg", width: "20%");

image.WriteToContent(document);
document.WriteEmptyBlock();

new Figure(c => image.WriteToContent(c), cap => cap.WriteString("About me")).WriteToContent(document);
document.WriteEmptyBlock();

CreateUserTable().WriteToContent(document);
document.WriteEmptyBlock();

Console.WriteLine(document);

void WriteTextContent(ContentWriter textContent)
{
    textContent.WriteString("Hello, ");
    textContent.Write(new Strong(c => c.WriteString("world")));
}

IEnumerable<Action<ContentWriter>> GetItems()
{
    return new Action<ContentWriter>[]
    {
        c => c.Write(new Image("profile.jpg", width: "25%")),
        c => c.WriteString("Two"),
        c => c.WriteString("Three")
    };
}

Table CreateUserTable()
{
    var columns = new[] {"auto", "1fr", "1fr"};
    var items = new Action<ContentWriter>[]
    {
        _ => { },
        c => c.Write(new Strong(strong => strong.WriteString("Name"))),
        c => c.Write(new Strong(strong => strong.WriteString("Phone"))),
        
        c => c.WriteString("1"),
        c => c.WriteString("Sparrow"),
        c => c.WriteString("+79531345309").Linebreak()
              .WriteString("+89231365311")
    };
    
    return new Table(columns, items, inset: "10pt", align: "horizon");
}
