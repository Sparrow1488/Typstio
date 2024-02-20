using Typstio.Core.Functions;
using Typstio.Core.Writers;

var document = new ContentWriter();

new Heading(1, content => content.WriteString("Introduction")).WriteToDocument(document);

document.WriteEmptyBlock();

new Text(WriteTextContent).WriteToDocument(document);

Console.WriteLine(document);

void WriteTextContent(ContentWriter textContent)
{
    textContent.WriteString("Hello, ");
    textContent.Write(new Strong(c => c.WriteString("world")));
}
