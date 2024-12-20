﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUebung1
{
    internal class SampleData
    {
        public static List<Schueler> Schuelers = new List<Schueler>();
        // Jeder Schüler hat eine Liste von Prüfungen. Wir speichern zusätzlich alle Prüfungen 
        // noch in dieser Liste, damit wir sie leichter abfragen könen.
        public static List<Pruefung> Pruefungen = new List<Pruefung>();

        public static void GenerateData()
        {
            Schuelers.Add(new Schueler() { Id = 1000, Name = "Elt", Vorname = "Célia", Geschlecht = "w", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1001, Name = "Mattack", Vorname = "Loïca", Geschlecht = "m", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1002, Name = "Nayshe", Vorname = "Eliès", Geschlecht = "m", Klasse = "3BHIF" });
            Schuelers.Add(new Schueler() { Id = 1003, Name = "Domanek", Vorname = "Noémie", Geschlecht = "m", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1004, Name = "Avramovitz", Vorname = "Chloé", Geschlecht = "m", Klasse = "3BHIF" });
            Schuelers.Add(new Schueler() { Id = 1005, Name = "Curtin", Vorname = "Maëline", Geschlecht = "m", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1006, Name = "Riseborough", Vorname = "Lauréna", Geschlecht = "m", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1007, Name = "Kynge", Vorname = "Valérie", Geschlecht = "m", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1008, Name = "Dibden", Vorname = "Maéna", Geschlecht = "m", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1009, Name = "Pinder", Vorname = "Jú", Geschlecht = "m", Klasse = "3BHIF" });
            Schuelers.Add(new Schueler() { Id = 1010, Name = "Cuseick", Vorname = "Cléa", Geschlecht = "w", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1011, Name = "Calladine", Vorname = "Clémence", Geschlecht = "m", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1012, Name = "Stiff", Vorname = "Maéna", Geschlecht = "w", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1013, Name = "Elbourn", Vorname = "Josée", Geschlecht = "m", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1014, Name = "Fosdike", Vorname = "Kallisté", Geschlecht = "w", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1015, Name = "Wilton", Vorname = "Lèi", Geschlecht = "m", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1016, Name = "Billson", Vorname = "Eléa", Geschlecht = "m", Klasse = "3BHIF" });
            Schuelers.Add(new Schueler() { Id = 1017, Name = "Dunstall", Vorname = "Lyséa", Geschlecht = "m", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1018, Name = "Santori", Vorname = "Céline", Geschlecht = "m", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1019, Name = "Sharpe", Vorname = "Béatrice", Geschlecht = "m", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1020, Name = "Minerdo", Vorname = "Laurélie", Geschlecht = "w", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1021, Name = "Gianulli", Vorname = "Léonie", Geschlecht = "m", Klasse = "3BHIF" });
            Schuelers.Add(new Schueler() { Id = 1022, Name = "Works", Vorname = "Styrbjörn", Geschlecht = "m", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1023, Name = "Dixon", Vorname = "Personnalisée", Geschlecht = "m", Klasse = "3BHIF" });
            Schuelers.Add(new Schueler() { Id = 1024, Name = "Browne", Vorname = "Esbjörn", Geschlecht = "m", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1025, Name = "Clearley", Vorname = "Åsa", Geschlecht = "m", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1026, Name = "Jeandin", Vorname = "Maïté", Geschlecht = "m", Klasse = "3BHIF" });
            Schuelers.Add(new Schueler() { Id = 1027, Name = "McComiskey", Vorname = "Léa", Geschlecht = "w", Klasse = "3CHIF" });
            Schuelers.Add(new Schueler() { Id = 1028, Name = "Castellan", Vorname = "Léa", Geschlecht = "m", Klasse = "3AHIF" });
            Schuelers.Add(new Schueler() { Id = 1029, Name = "Spurnier", Vorname = "Stéphanie", Geschlecht = "w", Klasse = "3CHIF" });

            Pruefungen.Add(Schuelers[0].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 4, Datum = new DateTime(2018, 5, 12) }));
            Pruefungen.Add(Schuelers[1].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 2, Datum = new DateTime(2018, 3, 10) }));
            Pruefungen.Add(Schuelers[1].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 1, Datum = new DateTime(2018, 4, 18) }));
            Pruefungen.Add(Schuelers[1].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 4, Datum = new DateTime(2018, 4, 21) }));
            Pruefungen.Add(Schuelers[1].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2018, 1, 28) }));
            Pruefungen.Add(Schuelers[1].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 5, Datum = new DateTime(2017, 11, 28) }));
            Pruefungen.Add(Schuelers[10].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 2, Datum = new DateTime(2018, 2, 2) }));
            Pruefungen.Add(Schuelers[10].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 2, Datum = new DateTime(2018, 4, 2) }));
            Pruefungen.Add(Schuelers[10].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 4, Datum = new DateTime(2018, 2, 16) }));
            Pruefungen.Add(Schuelers[11].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 5, Datum = new DateTime(2017, 9, 12) }));
            Pruefungen.Add(Schuelers[11].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 3, Datum = new DateTime(2018, 3, 24) }));
            Pruefungen.Add(Schuelers[11].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2018, 2, 13) }));
            Pruefungen.Add(Schuelers[12].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 4, Datum = new DateTime(2018, 5, 22) }));
            Pruefungen.Add(Schuelers[12].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 5, Datum = new DateTime(2018, 6, 18) }));
            Pruefungen.Add(Schuelers[13].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 3, Datum = new DateTime(2018, 2, 4) }));
            Pruefungen.Add(Schuelers[13].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 1, Datum = new DateTime(2017, 9, 20) }));
            Pruefungen.Add(Schuelers[13].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 1, Datum = new DateTime(2017, 11, 26) }));
            Pruefungen.Add(Schuelers[14].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 4, Datum = new DateTime(2018, 6, 22) }));
            Pruefungen.Add(Schuelers[15].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2017, 12, 9) }));
            Pruefungen.Add(Schuelers[16].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 4, Datum = new DateTime(2018, 4, 14) }));
            Pruefungen.Add(Schuelers[17].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 4, Datum = new DateTime(2017, 9, 3) }));
            Pruefungen.Add(Schuelers[17].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 5, Datum = new DateTime(2017, 10, 24) }));
            Pruefungen.Add(Schuelers[19].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 2, Datum = new DateTime(2017, 12, 10) }));
            Pruefungen.Add(Schuelers[19].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2017, 10, 13) }));
            Pruefungen.Add(Schuelers[2].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 2, Datum = new DateTime(2017, 12, 8) }));
            Pruefungen.Add(Schuelers[2].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 5, Datum = new DateTime(2017, 12, 21) }));
            Pruefungen.Add(Schuelers[2].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 1, Datum = new DateTime(2018, 3, 31) }));
            Pruefungen.Add(Schuelers[2].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 3, Datum = new DateTime(2018, 3, 27) }));
            Pruefungen.Add(Schuelers[2].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 4, Datum = new DateTime(2018, 6, 19) }));
            Pruefungen.Add(Schuelers[2].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2017, 11, 27) }));
            Pruefungen.Add(Schuelers[20].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 3, Datum = new DateTime(2018, 3, 29) }));
            Pruefungen.Add(Schuelers[20].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 5, Datum = new DateTime(2018, 5, 3) }));
            Pruefungen.Add(Schuelers[22].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "NAI", Note = 3, Datum = new DateTime(2018, 1, 13) }));
            Pruefungen.Add(Schuelers[22].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 1, Datum = new DateTime(2018, 5, 22) }));
            Pruefungen.Add(Schuelers[23].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 4, Datum = new DateTime(2017, 11, 11) }));
            Pruefungen.Add(Schuelers[23].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2017, 9, 12) }));
            Pruefungen.Add(Schuelers[23].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 3, Datum = new DateTime(2017, 12, 4) }));
            Pruefungen.Add(Schuelers[24].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 1, Datum = new DateTime(2018, 1, 12) }));
            Pruefungen.Add(Schuelers[24].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 5, Datum = new DateTime(2018, 6, 9) }));
            Pruefungen.Add(Schuelers[24].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 1, Datum = new DateTime(2017, 9, 20) }));
            Pruefungen.Add(Schuelers[24].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 3, Datum = new DateTime(2018, 3, 26) }));
            Pruefungen.Add(Schuelers[24].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2017, 9, 19) }));
            Pruefungen.Add(Schuelers[25].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 5, Datum = new DateTime(2017, 10, 29) }));
            Pruefungen.Add(Schuelers[25].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 1, Datum = new DateTime(2018, 4, 15) }));
            Pruefungen.Add(Schuelers[25].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 2, Datum = new DateTime(2018, 4, 1) }));
            Pruefungen.Add(Schuelers[25].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 2, Datum = new DateTime(2017, 10, 27) }));
            Pruefungen.Add(Schuelers[26].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 4, Datum = new DateTime(2018, 6, 2) }));
            Pruefungen.Add(Schuelers[26].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 2, Datum = new DateTime(2018, 3, 6) }));
            Pruefungen.Add(Schuelers[26].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 2, Datum = new DateTime(2018, 6, 18) }));
            Pruefungen.Add(Schuelers[26].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 1, Datum = new DateTime(2018, 3, 23) }));
            Pruefungen.Add(Schuelers[26].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2018, 2, 18) }));
            Pruefungen.Add(Schuelers[27].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "NAI", Note = 1, Datum = new DateTime(2017, 10, 22) }));
            Pruefungen.Add(Schuelers[27].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 4, Datum = new DateTime(2017, 10, 29) }));
            Pruefungen.Add(Schuelers[27].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2018, 1, 14) }));
            Pruefungen.Add(Schuelers[28].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 4, Datum = new DateTime(2018, 4, 3) }));
            Pruefungen.Add(Schuelers[28].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 1, Datum = new DateTime(2018, 6, 8) }));
            Pruefungen.Add(Schuelers[28].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 4, Datum = new DateTime(2018, 5, 28) }));
            Pruefungen.Add(Schuelers[28].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 5, Datum = new DateTime(2017, 9, 28) }));
            Pruefungen.Add(Schuelers[29].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 1, Datum = new DateTime(2017, 12, 30) }));
            Pruefungen.Add(Schuelers[29].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "NAI", Note = 5, Datum = new DateTime(2018, 5, 18) }));
            Pruefungen.Add(Schuelers[3].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 1, Datum = new DateTime(2018, 1, 22) }));
            Pruefungen.Add(Schuelers[3].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 4, Datum = new DateTime(2018, 2, 11) }));
            Pruefungen.Add(Schuelers[3].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 4, Datum = new DateTime(2018, 6, 18) }));
            Pruefungen.Add(Schuelers[3].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 5, Datum = new DateTime(2017, 12, 12) }));
            Pruefungen.Add(Schuelers[3].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 5, Datum = new DateTime(2018, 4, 6) }));
            Pruefungen.Add(Schuelers[3].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 1, Datum = new DateTime(2018, 6, 13) }));
            Pruefungen.Add(Schuelers[4].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 3, Datum = new DateTime(2018, 4, 5) }));
            Pruefungen.Add(Schuelers[4].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "NAI", Note = 2, Datum = new DateTime(2017, 12, 23) }));
            Pruefungen.Add(Schuelers[4].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 5, Datum = new DateTime(2017, 12, 11) }));
            Pruefungen.Add(Schuelers[5].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 3, Datum = new DateTime(2017, 11, 30) }));
            Pruefungen.Add(Schuelers[5].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 2, Datum = new DateTime(2017, 12, 25) }));
            Pruefungen.Add(Schuelers[5].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 3, Datum = new DateTime(2018, 6, 6) }));
            Pruefungen.Add(Schuelers[5].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 2, Datum = new DateTime(2017, 10, 4) }));
            Pruefungen.Add(Schuelers[6].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 1, Datum = new DateTime(2017, 10, 19) }));
            Pruefungen.Add(Schuelers[6].AddPruefung(new Pruefung() { Fach = "AM", Pruefer = "KY", Note = 1, Datum = new DateTime(2018, 2, 4) }));
            Pruefungen.Add(Schuelers[6].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 2, Datum = new DateTime(2017, 12, 30) }));
            Pruefungen.Add(Schuelers[7].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 3, Datum = new DateTime(2017, 12, 27) }));
            Pruefungen.Add(Schuelers[7].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 4, Datum = new DateTime(2017, 11, 3) }));
            Pruefungen.Add(Schuelers[7].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 4, Datum = new DateTime(2018, 5, 15) }));
            Pruefungen.Add(Schuelers[7].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 4, Datum = new DateTime(2018, 5, 17) }));
            Pruefungen.Add(Schuelers[8].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 4, Datum = new DateTime(2017, 12, 5) }));
            Pruefungen.Add(Schuelers[8].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 4, Datum = new DateTime(2018, 3, 20) }));
            Pruefungen.Add(Schuelers[8].AddPruefung(new Pruefung() { Fach = "DBI", Pruefer = "FZ", Note = 5, Datum = new DateTime(2017, 12, 3) }));
            Pruefungen.Add(Schuelers[8].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 1, Datum = new DateTime(2018, 2, 14) }));
            Pruefungen.Add(Schuelers[8].AddPruefung(new Pruefung() { Fach = "E", Pruefer = "FAV", Note = 4, Datum = new DateTime(2018, 4, 2) }));
            Pruefungen.Add(Schuelers[8].AddPruefung(new Pruefung() { Fach = "POS", Pruefer = "SZ", Note = 4, Datum = new DateTime(2018, 4, 16) }));
            Pruefungen.Add(Schuelers[9].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 2, Datum = new DateTime(2018, 4, 8) }));
            Pruefungen.Add(Schuelers[9].AddPruefung(new Pruefung() { Fach = "D", Pruefer = "KY", Note = 5, Datum = new DateTime(2018, 1, 4) }));
        }
    }
}

