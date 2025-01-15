using System.Globalization;
using System.Xml.Linq;

XElement Moore = XElement.Load(@"../../../Moore.xml"); //Mein Filesystem verwendet normale Slashes, nicht Backslashes
XElement Bestellungen = XElement.Load(@"../../../kundenbestellungen.xml");

//1.
Console.WriteLine("1:");
List<string> result1 = Moore.Descendants("Movie")
    .Where(m=> (int)m.Element("Year")>1995)
    .Select(m=> m.Element("Title").Value)
    .ToList();
result1.ForEach(r =>
{
    Console.WriteLine(r);
});

//2.
Console.WriteLine("\n2:");
var result2 = Moore.Descendants("Actor")
    .Select(e=> "Name=" +
        e.Element("Name").Element("FirstName").Value + " " +
        e.Element("Name").Element("LastName").Value + "     Anzahl=" + 
        e.Descendants("Filmography").Elements("Movie").Count()
        ).ToList();
result2.ForEach(r =>
{
    Console.WriteLine(r);
});

//3.
Console.WriteLine("\n3:");
var result3 = Bestellungen.Descendants("Kunden")
    .GroupBy(k=> (string?)k.Attribute("Land"))
    .OrderBy(k=> k.Key)
    .ToList();
result3.ForEach(r =>
{
    foreach (var xElement in r)
    {
        Console.WriteLine($"Land={r.Key}    Firma={(string?)xElement.Attribute("Firma")}");
    }
});

//4.
Console.WriteLine("\n4:");
var result4 = Bestellungen.Descendants("Kunden")
    .GroupBy(k => (string?)k.Attribute("Firma"))
    .ToList();
result4.ForEach(r =>
{
    foreach (var xElement in r)
    {
        Console.WriteLine(
            $"Firma={r.Key}   Kosten={Math.Round(xElement.Elements("Bestellungen").ToList().Sum(b => Double.TryParse(b.Element("Frachtkosten").Value, CultureInfo.GetCultureInfo("de"), out double frachtkosten) ? frachtkosten : 0),2)}");
    }
});

//5.
Console.WriteLine("\n5:");
var result5 = 
    from k in Bestellungen.Descendants("Kunden")
    from b in k.Descendants("Bestellungen")
    group b by (int)k.Element("Personal_Nr") into output
    select new
    {
        Personal_Nr = output.Key,
        Bestellanzahl = output.Count()
    };
result5.ToList().ForEach(r=>{
    Console.WriteLine($"Personal_Nr={r.Personal_Nr}     Bestellanzahl={r.Bestellanzahl}");
});

//6.
Console.WriteLine("\n6:");
try
{
    Moore.Descendants("Movie")
        .FirstOrDefault(m 
            => (string)m.Element("Title") == "Live and Let Die")
        .Element("Year")
        .SetValue("1972");
    Moore.Save(@"../../../Moore.xml");
    Console.WriteLine("Done successfully!");
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

