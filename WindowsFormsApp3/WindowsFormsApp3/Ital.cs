using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Ital : Termek
    {
        public bool AlkoholosE { get; set; }

        public bool SzensavasE { get; set; }

        public override string ToString()
        {
            string temp = base.ToString();
            if (AlkoholosE)
            {
                temp += "Alkoholos";
            }

            if (SzensavasE)
            {
                temp += "Szénsavas";
            }
            return temp;
        }
    }
}
