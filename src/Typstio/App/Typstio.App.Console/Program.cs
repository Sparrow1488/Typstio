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