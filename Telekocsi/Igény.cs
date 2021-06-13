using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    class Igény
    {
        public string Azonosító { get; set; }
        public string Indulás { get; set; }
        public string Cél { get; set; }
        public int Személyek { get; set; }

        public Igény(string sor)
        {
            string[] Splitted = sor.Split(';');
            Azonosító = Splitted[0];
            Indulás = Splitted[1];
            Cél = Splitted[2];
            Személyek = int.Parse(Splitted[3]);
        }
    }
}
