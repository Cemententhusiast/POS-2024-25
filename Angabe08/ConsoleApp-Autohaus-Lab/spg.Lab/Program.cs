using spg.Lab6.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Xml.Linq;

namespace spg.Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
           
            Verwaltung vw = new Verwaltung();
            Console.WriteLine("============= Dienstleistungen ===================");
            foreach (Dienstleistung d in vw.Dienstleistungen)
            {
                Console.WriteLine(d.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("============= Kunden ===================");
            foreach (Kunde k in vw.Kunden)
            {
                Console.WriteLine(k.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("============= Termine ===================");
            foreach (Termin t in vw.Termine)
            {
                Console.WriteLine(t.ToString());
                Console.WriteLine();
            }

            vw.XmlAusgabe();
            
            Console.WriteLine("============= Übungsabfragen ================");
            Console.WriteLine("Alle nicht TestPerson Kunden:");
            var output1 = vw.Kunden.Where(k => k is not TestPerson)
                .OrderBy(k => k.Name).ToList();
            output1.ForEach(t => Console.WriteLine("    "+t.Name.ToString()));
            
            Console.WriteLine("Vera Russwurm Termine:");
            var output2 = (from term in vw.Termine
                .Where(t => t.Kunde.Name == "Vera Russwurm") 
                select new { term.Date, term.Leistungen, term.Leistungen.Count}).ToList();
            output2.ForEach(t => Console.WriteLine("    " + t));
            
            Console.WriteLine("Alle Termine mit Daten, Kosten etc");
            var output3 = (from t in vw.Termine 
                select new{t.Date, 
                    t.Kunde.Name, 
                    Kosten = t.Leistungen
                        .Sum(l => t.Kunde.Kosten(l))})
                .ToList(); 
            output3.ForEach(t => Console.WriteLine("    " + t));
            
            Console.WriteLine("Kunden gruppieren nach anzahl an Terminen");
            var output5 = vw.Termine
                .GroupBy(t=> t.Kunde.Name)
                .Select(t => new
                {
                    Kunde = t.Key, 
                    Datum = t.Select(k => k.Date)
                        .ToList()
                })
                .ToList();
            output5.ForEach(t => Console.WriteLine("    " + t));
            
            Console.WriteLine("Kunden gruppieren nach anzahl an Terminen");
            var output4 = vw.Termine
                .GroupBy(t=> t.Kunde.Name)
                .Select(t => new { Kunde = t.Key, Count = t.Count() })
                .OrderByDescending(t => t.Count)
                .ToList();
            output4.ForEach(t => Console.WriteLine("    " + t));
            
            Console.WriteLine("Teuerste Dienstleistung");
            var output6 = from k in vw.Termine select new
            {
                Kosten = k.Leistungen.Max(l => k.Kunde.Kosten(l))
            }.ToString();
            Console.WriteLine(output6);
            
            Console.WriteLine("Kunden dienstleistung");
            var output7 = (from s in vw.Termine
                where s.Kunde.Name.Equals("Vera Russwurm")
                orderby s.Kunde ascending
                select new {s.Kunde.Name, s.Kunde.Adresse }).ToList();
            output7.ForEach(t => Console.WriteLine("    " + t));
        }
    }
}
