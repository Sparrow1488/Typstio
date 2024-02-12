using Typstio.Core;

var report = new Report();

report
    .Add(new Title("Sample report", 1))
    .Add(new Title("Sparrow", 2))
    .Add(new Paragraph("#lorem(30)"));
    
var typst = report.ConvertToTypst();
Console.WriteLine(typst);