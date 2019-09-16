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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        List<Termek> termekek;

        public Form1()
        {
            termekek = new List<Termek>();
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EladasUrlap eurlap = new EladasUrlap(termekek);
            if (eurlap.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                foreach (Termek item in termekek)
                {
                    listBox1.Items.Add(item);
                }
            }            
        }

        private void Button2_Click(object sender, EventArgs e)
        {            
            BinaryWriter writer = new BinaryWriter(File.Create("Adat.dat"));
            foreach (Termek termek in termekek)
            {
                if (termek.GetType() == typeof(Ital))
                {
                    writer.Write(termek.GetType().ToString());
                    if (((Ital)termek).SzensavasE)
                    {
                        writer.Write(true);
                    }
                    else
                    {
                        writer.Write(false);
                    }
                    if (((Ital)termek).AlkoholosE)
                    {
                        writer.Write(true);
                    }
                    else
                    {
                        writer.Write(false);
                    }
                }
                else
                {
                    writer.Write(termek.GetType().ToString());
                    writer.Write(((Etel)termek).EtelTipusa.ToString());
                }
                writer.Write(termek.Egysegar);
                writer.Write(termek.Megnevezes);
                writer.Write(termek.Mennyiseg);
            }
            writer.Flush();
            writer.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            termekek = new List<Termek>();
            BinaryReader br = new BinaryReader(File.OpenRead("Adat.dat"));
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                if (br.ReadString() == typeof(Ital).ToString())
                {
                    Ital it = new Ital();
                    if (br.ReadBoolean())
                    {
                        it.SzensavasE = true;
                    }
                    if (br.ReadBoolean())
                    {
                        it.AlkoholosE = true;
                    }
                    it.Egysegar = br.ReadInt32();
                    it.Megnevezes = br.ReadString();
                    it.Mennyiseg = br.ReadDecimal();
                    termekek.Add(it);
                }
                else
                {
                    Etel et = new Etel();
                    string temp = br.ReadString();
                    et.Egysegar = br.ReadInt32();
                    et.Megnevezes = br.ReadString();
                    et.Mennyiseg = br.ReadDecimal();
                    termekek.Add(et);
                }                
            }

            listBox1.Items.Clear();
            foreach (Termek item in termekek)
            {
                listBox1.Items.Add(item);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Termek item in termekek)
            {
                if (item.GetType() == typeof(Etel))
                {
                    if (((Etel)item).EtelTipusa == EtelTipus.Zoldseg)
                    {
                        listBox1.Items.Add(item);
                        listBox1.Items.Add(item.Mennyiseg * item.Egysegar);
                    }
                }
            }
        }
    }
}
