using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1234
{
    public class Avto
    {
        public int id { get; set; }
        public string Znamka { get; set; }
        public string Model { get; set; }

        public int cena { get; set; }

        public enum Nov {da,ne};
        public Nov nov { get; set; }

        public Avto() { }

        public Avto(int id, string znamka, string model, int cena, Nov nov)
        {
            this.id = id;
            Znamka = znamka;
            Model = model;
            this.cena = cena;
            this.nov = nov;
        }
    }
}
