using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Telekocsi
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. feladat
            List<Járat> járatok = new List<Járat>();
            foreach (var sor in File.ReadAllLines("autok.csv").Skip(1))
            {
                járatok.Add(new Járat(sor));
            }

            // 2.feladat
            // A szokásoshoz képest nem az összeset, hanem azt kell kiírni, hogy hány hirdető van a fájlban...
            // Tehát hány különböző (Distinct)
            // (Ennek ellenére nincs két egyforma hirdető, vagyis egy autó csak egy útvonalon közlekedik...)
            Console.WriteLine($"2. feladat\n\t{járatok.GroupBy(x => x.Rendszám).Count()} autós hirdet fuvart");

            //3. feladat
            Console.WriteLine($"3. feladat\n\tÖsszesen " +
                $"{járatok.Where(x => x.Indulás == "Budapest" && x.Cél == "Miskolc").Sum(x => x.Férőhely)}" +
                $" férőhelyet hirdettek az autósok Budapestről Miskolcra.");

            //4. feladat: Legtöbb férőhely / útvonal
            var MaxFérőhelyPerÚtvonal = járatok
                .GroupBy(x => new { x.Indulás, x.Cél })                                                                 // Csoportosítás két mező szerint
                .Select(g => new { Indulás = g.Key.Indulás, Cél = g.Key.Cél, ÖsszFérőhely = g.Sum(x => x.Férőhely) })   // Férőhelyek összegzése csoportonként
                .OrderBy(x => x.ÖsszFérőhely).Last();                                                                   // Legnagyobb kiválasztása
            Console.WriteLine($"4. feladat\n\tA legtöbb férőhelyet ({MaxFérőhelyPerÚtvonal.ÖsszFérőhely}-et) a " +
                $"{MaxFérőhelyPerÚtvonal.Indulás}-{MaxFérőhelyPerÚtvonal.Cél} útvonalon ajánlották ");

            //5. feladat
            Console.WriteLine($"5. feladat");
            List<Igény> igények = new List<Igény>();
            foreach (var sor in File.ReadAllLines("igenyek.csv").Skip(1))
            {
                igények.Add(new Igény(sor));
            }

            // JOIN query szintaktikával:
            var result = from j in járatok
                         join i in igények
                         on new { j.Indulás, j.Cél } equals new { i.Indulás, i.Cél }
                         select new { i.Azonosító, j.Rendszám };

            result.ToList().ForEach(x => Console.WriteLine($"\t{x.Azonosító} => {x.Rendszám}"));
        }
    }
}
