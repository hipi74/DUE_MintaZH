using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        List<Arucikk> aruim;

        public Form1()
        {
            aruim = new List<Arucikk>();
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AruBevitelUrlap abv = new AruBevitelUrlap(aruim);
            if (abv.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                foreach (Arucikk item in aruim)
                {
                    listBox1.Items.Add(item);
                }
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.Create("adat.dat"));
            foreach (Arucikk item in aruim)
            {
                bw.Write(item.GetType().ToString());
                bw.Write(item.Megnevezes);
                bw.Write(item.Egysegar);
                bw.Write(item.Mennyiseg);
                if (item.GetType() == typeof(Ital))
                {
                    bw.Write(((Ital)item).SzensavasE);
                    bw.Write(((Ital)item).AlkoholosE);
                }
                else
                {
                    bw.Write(((Etel)item).Eteltipus.ToString());
                }
            }
            bw.Flush();
            bw.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            aruim = new List<Arucikk>();
            BinaryReader br = new BinaryReader(File.OpenRead("adat.dat"));
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                if (br.ReadString() == typeof(Ital).ToString())
                {
                    Ital it = new Ital();
                    it.Megnevezes = br.ReadString();
                    it.Egysegar = br.ReadInt32();
                    it.Mennyiseg = br.ReadDecimal();
                    it.SzensavasE = br.ReadBoolean();
                    it.AlkoholosE = br.ReadBoolean();
                    aruim.Add(it);
                }
                else
                {
                    Etel et = new Etel();
                    et.Megnevezes = br.ReadString();
                    et.Egysegar = br.ReadInt32();
                    et.Mennyiseg = br.ReadDecimal();
                    et.Eteltipus =
                       (Eteltipusok)Enum.Parse(typeof(Eteltipusok), br.ReadString());
                    aruim.Add(et);
                }
            }
            br.Close();
            listBox1.Items.Clear();
            foreach (Arucikk item in aruim)
            {
                listBox1.Items.Add(item);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Arucikk item in aruim)
            {
                if (item.GetType() == typeof(Etel) &&
                    (((Etel)item).Eteltipus == Eteltipusok.Zoldseg ||
                    ((Etel)item).Eteltipus == Eteltipusok.Gyumolcs))
                {
                    listBox1.Items.Add(item);
                    listBox1.Items.Add(item.Mennyiseg * item.Egysegar);
                }
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            decimal osszesen = 0;
            foreach (Arucikk item in aruim)
            {
                if (item.GetType() == typeof(Ital) && ((Ital)item).AlkoholosE)
                {
                    osszesen += item.Egysegar * item.Mennyiseg * (decimal)1.1;
                }
                else
                {
                    osszesen += item.Egysegar * item.Mennyiseg;
                }
            }
            listBox1.Items.Add(osszesen);
        }
    }
}
