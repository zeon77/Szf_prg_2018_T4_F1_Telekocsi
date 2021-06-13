﻿using System;
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

        }
    }
}
