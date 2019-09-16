using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public enum EtelTipus
    {
        // zöldség, gyümölcs, édes árú, húskészítmény, száraz áru
        Zoldseg,
        Gyumolcs,
        Desszert,
        Hus,
        SzarazAru
    }

    class Etel :Termek
    {
        public EtelTipus EtelTipusa { get; set; }

        public override string ToString()
        {
            return base.ToString() + EtelTipusa.ToString();
        }

    }
}
