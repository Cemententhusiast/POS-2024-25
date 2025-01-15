using System;
using System.Xml.Linq;
using LinqInAction.LinqBooks.Common;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
                        
            Console.WriteLine("Happy coding!");
            
            Console.WriteLine("------------------------------------------------");
            var result1 = SampleData.Books.Where(book => book.Authors.Any(a => (a.Birthdate-new DateTime(1980, 1, 1)<TimeSpan.Zero))).ToList().Sum(book => book.Sold);
            Console.WriteLine(result1);
            
            
            Console.WriteLine("------------------------------------------------");
            var result2 = SampleData.Books.Where(b => b.Reviews.Average(r => r.Rating) > 3).ToList();
            result2.ForEach(b => Console.WriteLine($"Title={b}"));
            
            Console.WriteLine("------------------------------------------------");
            var result3 = SampleData.Books.OrderByDescending(b=> b.Reviews.Average(r=> r.Rating)).ToList();
            result3.ForEach(b => Console.WriteLine($"Title={b}  Durch={Math.Round(b.Reviews.Average(r => r.Rating),2)}"));
            Console.WriteLine("------------------------------------------------");
            
            
            Console.WriteLine("\nCreate XML");
            var xml = new XElement("Octavio",
                new XElement("Title", new XAttribute("Isbn", "0-111-77777-2"), new XText("LINQ rules")),
                new XElement("Title", new XAttribute("Isbn", "0-222-77777-2"), new XText("C# on Rails")),
                new XElement("Title", new XAttribute("Isbn", "0-444-77777-2"), new XText("Bonjour mon Amour")));
            Console.WriteLine(xml);
        }
    }
}
