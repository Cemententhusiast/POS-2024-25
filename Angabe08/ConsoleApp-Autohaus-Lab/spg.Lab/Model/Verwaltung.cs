using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace spg.Lab6.Model
{
    public class Verwaltung
    {
        public List<Dienstleistung> Dienstleistungen { set; get; } = new List<Dienstleistung>();
        public List<Kunde> Kunden { set; get; } = new List<Kunde>();
        public List<Termin> Termine { set; get; } = new List<Termin>();
        public Verwaltung()
        {
            Init();
        }
        /// <summary>
        /// ES gibt KEIN pruefen auf falsche Eintraege -> Exceptions!!!
        /// TODO: Umbauen auf sicheres einlesen d.h. Fehler melden (z.B. Telefonnummer fehlt).
        /// </summary>
        public void Init()
        {
            // Achtung: Autohaus.txt hat CopyToOutput... gesetzt!!!
            string[] lines = File.ReadAllLines("Autohaus.txt", Encoding.UTF8);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] split = line.Split(";");
                    switch (split[0])
                    {
                        case "Promi":
                            if (split.Length != 7)
                            {
                                throw new FormatException("Format is invalid.");
                            }
                            Kunden.Add(new Prominent(Int32.Parse(split[6]), split[5], split[2], split[4], split[1], split[3]));
                            break;
                        case "Normal":
                            if (split.Length != 7)
                            {
                                throw new FormatException("Format is invalid.");
                            }
                            Intervall? intervall = null;
                            if (split.Length > 6 && Enum.TryParse<Intervall>(split[6], true, out Intervall intervallFile))
                            {
                                intervall = intervallFile;
                            }
                            Kunden.Add(new Normal(split[2], split[4], split[1], split[3], split[5], intervall));
                            break;
                        case "TestPerson":
                            if (split.Length != 7)
                            {
                                throw new FormatException("Format is invalid.");
                            }
                            Kunden.Add(new TestPerson(split[2], split[4], split[1], split[3], split[5], decimal.Parse(split[6])));
                            break;
                        case "Dienstleistung":
                            if (split.Length != 4)
                            {
                                throw new FormatException("Format is invalid.");
                            }
                            Dienstleistungen.Add(new Dienstleistung(split[1], Decimal.Parse(split[2]), Double.Parse(split[3])));
                            break;
                        case "Termin":
                            if (split.Length != 4)
                            {
                                throw new FormatException("Format is invalid.");
                            }
                            Kunde kunde = null!; //split[1], keine Pruefung!!!
                            foreach (Kunde k in Kunden)
                            {
                                if (split[1].Equals(k.Name))
                                    kunde = k;
                            }
                            LinkedList<Dienstleistung> leistungen = new LinkedList<Dienstleistung>(); //split[2]
                            string[] l = split[2].Split(" ");
                            
                            Termin t = new Termin(DateTime.ParseExact(split[3], "dd.MM.yy H:mm", null), kunde);
                            
                            foreach (string leistung in l)
                            {
                                foreach (Dienstleistung d in Dienstleistungen)
                                {
                                    if (leistung.Equals(d.Leistung))
                                    {
                                        t.AddLeisung(d);
                                    }
                                }
                            }
                            
                            Termine.Add(t);
                            break;
                        default:
                            throw new Exception("Unknown verwaltung type: " + split[0]);
                    }
                }
            }
            Sort();
        }
        public void Sort()
        {
            SortDienstleistungen();
            SortKunden();
            SortTermine();
        }
        public void SortDienstleistungen()
        {
            // Anonymous delegate
            Dienstleistungen.Sort(delegate (Dienstleistung dl1, Dienstleistung dl2)
            {
                return dl1.Leistung.CompareTo(dl2.Leistung);
            });
        }
        public void SortKunden()
        {
            // Delegate
            Kunden.Sort((x, y) => x.Name.CompareTo(y.Name));
        }
        public void SortTermine()
        {
            // IComparable
            Termine.Sort();
        }
        public void SortKundenMail()
        {
            // Comparer
            Kunden.Sort(new SortMail());
        }

        /// <summary>
        /// Das Delegate "besser" wird auf sämtliche Termine der "Termine" Collection angewendet.
        /// </summary>
        /// <param name="besser"></param>
        /// <returns>Den besten Termin</returns>
        public Termin BesterTermin(Func<Termin, Termin, Termin> besser)
        {
            return Termine.Aggregate(besser);
        }

        /// <summary>
        /// Das Delegate ausgeben wird auf sämtliche Kunden der "Kunden" Collection angewendet.
        /// </summary>
        /// <param name="ausgeben"></param>
        public void Ausgeben(Action<Kunde> ausgeben)
        {
            Kunden.ForEach(k => ausgeben(k));
        }

        public void XmlAusgabe()
        {
            var data = from d in Dienstleistungen
                select new XElement("Dienstleistung", 
                    new XAttribute("Leistung", d.Leistung),
                    new XElement("Preis", d.Preis),
                    new XElement("Aufwand", d.ZeitAufwand)
                );
            var root = new XElement("Dienstleistungen", data);
            Console.WriteLine(root);
            
            var data1 = from k in Kunden 
                select new XElement("Kunde", 
                    new XAttribute("Name", k.Name),
                    new XElement("Email", k.Email),
                    new XElement("Tel", k.Telefonnummer),
                    new XElement("Addresse", k.Adresse)
                    );
            var root1 = new XElement("Kunden", data1);
            Console.WriteLine(root1);

            var data2 = from t in Termine
                select new XElement("Termin",
                    new XAttribute("Kunde", t.Kunde.Name),
                    new XElement("Leistungen", t.Leistungen),
                    new XElement("Date", t.Date)
                    );
            var root2 = new XElement("Termine", data2);
            Console.WriteLine(root2);
        }

    }

    class SortMail : Comparer<Kunde>
    {
        public override int Compare(Kunde? x, Kunde? y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            return x!.Email.CompareTo(y!.Email);
        }
    }
}
