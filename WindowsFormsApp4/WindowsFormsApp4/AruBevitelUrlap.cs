using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class AruBevitelUrlap : Form
    {
        List<Arucikk> aruim;
        Arucikk aru = null;

        public AruBevitelUrlap(List<Arucikk> aruk)
        {
            aruim = aruk;
            InitializeComponent();
            foreach (string item in Enum.GetNames(typeof(Eteltipusok)))
            {
                comboBox1.Items.Add(item);
            }
        }
        public AruBevitelUrlap(List<Arucikk> aruk, Arucikk aru)
        {
            aruim = aruk;
            InitializeComponent();
            foreach (string item in Enum.GetNames(typeof(Eteltipusok)))
            {
                comboBox1.Items.Add(item);
            }
            //radioButton1.Enabled = false; // !
            //radioButton2.Enabled = false; // !
            textBox1.Text = aru.Megnevezes;
            textBox2.Text = aru.Egysegar.ToString();
            textBox3.Text = aru.Mennyiseg.ToString();
            if (aru is Etel)
            {
                radioButton1.Checked = true;
                comboBox1.SelectedIndex = (int)(aru as Etel).Eteltipus;
            }
            if (aru is Ital)
            {
                radioButton2.Checked = true;
                if ((aru as Ital).SzensavasE)
                {
                    checkBox1.Checked = true;
                }
                if ((aru as Ital).AlkoholosE)
                {
                    checkBox2.Checked = true;
                }
            }
            this.aru = aru;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel2.Enabled = false;
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
                panel2.Enabled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool addNew = true;
            if (this.aru != null)
            {
                DialogResult mbr = MessageBox.Show("Felülírod az előzőt?\nIgen => felülír\nNem=> másolatként felvesz", "Kérdés", MessageBoxButtons.YesNo);
                if (mbr == DialogResult.Yes)
                {
                    addNew = false;
                }

            }
            Etel et = null;
            Ital it = null;
            if (radioButton1.Checked)
            {
                et = new Etel();
                et.Megnevezes = textBox1.Text;
                et.Egysegar = int.Parse(textBox2.Text);
                et.Mennyiseg = decimal.Parse(textBox3.Text);
                // et.Eteltipus ToDo
                et.Eteltipus = (Eteltipusok)comboBox1.SelectedIndex;

            }
            else
            {
                it = new Ital();
                it.Megnevezes = textBox1.Text;
                it.Egysegar = int.Parse(textBox2.Text);
                it.Mennyiseg = decimal.Parse(textBox3.Text);
                if (checkBox1.Checked)
                {
                    it.SzensavasE = true;
                }
                if (checkBox2.Checked)
                {
                    it.AlkoholosE = true;
                }

            }
            if (addNew)
            {
                if (et != null)
                {
                    aruim.Add(et);
                }
                if (it != null)
                {
                    aruim.Add(it);
                }
            }
            else
            {
                if (this.aru != null)
                {
                    int index = aruim.FindIndex(x => x == aru);
                    if (et != null)
                    {
                        aruim[index] = et;
                    }
                    if (it != null)
                    {
                        aruim[index] = it;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
