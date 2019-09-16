using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class Arucikk
    {
        public string Megnevezes { get; set; }

        public int Egysegar { get; set; }

        public decimal Mennyiseg { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1} darab {2} HUF)",
                Megnevezes, Mennyiseg, Egysegar);
        }
    }
}
