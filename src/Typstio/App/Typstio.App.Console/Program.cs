using System.Diagnostics;
using Typstio.Core;
using Typstio.Core.Extensions;
using Typstio.Core.Functions;
using Typstio.Core.Functions.Colors;
using Typstio.Core.Functions.Containers;
using Typstio.Core.Functions.Text;
using Typstio.Core.Models;
using Typstio.Core.Services;

var document = new ContentWriter();

document.SetRuleLine(new TextRule(size: "18pt", font: "Atkinson Hyperlegible"));
document.SetRuleLine(new BoxRule(inset: "15pt"));
document.SetRuleLine(SetRule.FromElementFunction(new Table(ArraySegment<string>.Empty, ArraySegment<Content>.Empty, align: "horizon", inset: "10pt")));
document.NextLine();

document.Write(new Box(c => c.WriteString("Hello, Typst!"), new Rgb("#ff4136")));
document.WriteBlock();

document.Write(CreateUserTable());
document.WriteBlock();

// document.Write(CreateTemplateCard("Иван Иванов", "03.12.2003", "89531357830", "ivan@gmail.com"));
// document.WriteBlock();

Console.WriteLine(CodeGenerator.ToCode(document));

Console.WriteLine("Saving local");

const string output = "./code.pdf";
await new TypstCompiler().PdfAsync(document, "./code.txt", output);

Process.Start("explorer", Path.GetFullPath(output));

Console.WriteLine("OK");

void WriteTextContent(ContentWriter textContent)
{
    textContent.WriteString("Hello, ");
    textContent.Write(new Strong(c => c.WriteString("world")));
}

IEnumerable<Content> GetItems()
{
    return new Content[]
    {
        c => c.Write(new Image("profile.jpg", width: "20%")),
        c => c.WriteString("Two"),
        c => c.WriteString("Three")
    };
}

ITypstFunction CreateUserTable()
{
    var items = new Content[]
    {
        _ => { },
        c => c.Write(new Strong("Name")),
        c => c.Write(new Strong("Phone")),
        
        c => c.WriteString("1"),
        c => c.WriteString("Sparrow"),
        c => c.WriteString("+79531345309").Linebreak()
              .WriteString("+89231365311")
    };
    
    return new Table(("auto", "1fr", "1fr"), items, inset: "10pt", align: "horizon");
}

ITypstFunction CreateTemplateCard(string name, string birth, string phone, string email)
{
    return new Box(main =>
    {
        // Header
        main.Write(new Box(h => h.WriteString(name), color: Colors.Red, width: "100%"));
        
        // Body
        main.Write(
            new Box(body => body.Write(
                new Padding(pd => pd.Write(
                    new Grid(new Content[]
                    {
                        // Column 1
                        gridCol => gridCol
                            .WriteString("Birth").Linebreak()
                            .WriteString("Phone").Linebreak()
                            .WriteString("Email").Linebreak(),

                        // Column 2
                        gridCol => gridCol
                            .WriteString(birth).Linebreak()
                            .WriteString(phone).Linebreak()
                            .WriteString(email.Replace("@", "\\@")).Linebreak(),

                        // Column 3
                        gridCol => gridCol
                            .Write(new Image("profile.jpg", height: "auto"))

                    }, columns: ("15%", "50%", "auto"))), top: "-10pt")
                )
            )
        );
    }, Colors.Gray, width: "100%", inset: "0pt");
}