// See https://aka.ms/new-console-template for more information

using System.Xml;
using System.Xml.Linq;

XElement html = new XElement("html",
    new XElement("head", new XAttribute("style", "...")),
    new XElement("body", new XElement("h1"), new XElement("h2"))
    );
Console.WriteLine(html.ToString());