using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Ital : Arucikk
    {
        public bool SzensavasE { get; set; }

        public bool AlkoholosE { get; set; }
        public override string ToString()
        {
            string temp = base.ToString();
            if (SzensavasE)
            {
                temp += "Szénsavas";
            }
            if (AlkoholosE)
            {
                temp += "Alkoholos";
            }
            return temp;
        }
    }
}
