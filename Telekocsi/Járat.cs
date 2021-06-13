using System;

namespace Telekocsi
{
    class Járat
    {
        public string Indulás { get; set; }
        public string Cél { get; set; }
        public string Rendszám { get; set; }
        public string Telefonszám { get; set; }
        public int Férőhely { get; set; }

        public Járat(string sor)
        {
            string[] Splitted = sor.Split(';');
            Indulás = Splitted[0];
            Cél = Splitted[1];
            Rendszám = Splitted[2];
            Telefonszám = Splitted[3];
            Férőhely = int.Parse(Splitted[4]);
        }
    }
}
