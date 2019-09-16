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

        public AruBevitelUrlap(List<Arucikk> aruk)
        {
            aruim = aruk;
            InitializeComponent();
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
            if (radioButton1.Checked)
            {
                Etel et = new Etel();
                et.Megnevezes = textBox1.Text;
                et.Egysegar = int.Parse(textBox2.Text);
                et.Mennyiseg = decimal.Parse(textBox3.Text);
                // et.Eteltipus ToDo
                aruim.Add(et);
            }
            else
            {
                Ital it = new Ital();
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
                aruim.Add(it);
            }
        }
    }
}
