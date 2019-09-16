using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    enum Eteltipusok
    {
        //(zöldség, gyümölcs, édes árú, húskészítmény, száraz áru) 
        Zoldseg,
        Gyumolcs,
        Desszert,
        Hus,
        SzarazAru
    }

    class Etel : Arucikk
    {
        public Eteltipusok Eteltipus { get; set; }

        public override string ToString()
        {
            return base.ToString() + Eteltipus.ToString();
        }
    }
}
