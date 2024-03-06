using Typstio.Core;
using Typstio.Core.Extensions;
using Typstio.Core.Functions;
using Typstio.Core.Functions.Colors;
using Typstio.Core.Functions.Containers;
using Typstio.Core.Functions.Text;
using Typstio.Core.Models;

var document = new ContentWriter();

document.SetRule(new TextRule(size: "16pt", font: "Atkinson Hyperlegible"));
document.WriteEmptyBlock();

document.Write(new Box(c => c.WriteString("Hello, Typst!"), new Luma(50)));
document.WriteEmptyBlock();

document.Write(CreateUserTable());
document.WriteEmptyBlock();

document.Write(CreateTemplateCard("Иван Иванов", "03.12.2003", "89531357830", "ivan@gmail.com"));
document.WriteEmptyBlock();

Console.WriteLine(CodeGenerator.ToCode(document));

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

Table CreateUserTable()
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

TypstFunction CreateTemplateCard(string name, string birth, string phone, string email)
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