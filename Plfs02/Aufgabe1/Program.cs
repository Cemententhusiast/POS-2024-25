// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using Aufgabe1;

namespace Aufgabe1
{
    static class Program
    {
        static double FlaechenSumme(this List<FigurA> figuren)
        {
            figuren.ForEach(f=> Console.WriteLine(f));
            return figuren.Sum(f=>f.Flaeche);
        }

        static void Main(string[] args)
        {
            List<FigurA> figurs = new List<FigurA>();
            figurs.Add(new QuadratA(3));
            double s = figurs.FlaechenSumme();
            Console.WriteLine(s);
        }
    }
}

