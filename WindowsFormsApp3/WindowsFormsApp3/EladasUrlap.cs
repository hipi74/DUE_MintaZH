using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class EladasUrlap : Form
    {
        List<Termek> term;

        public EladasUrlap(List<Termek> t)
        {
            term = t;
            InitializeComponent();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel2.Enabled = true;
                panel1.Enabled = false;
            }
            else
            {
                panel1.Enabled = true;
                panel2.Enabled = false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Etel et = new Etel();
                et.Megnevezes = textBox1.Text;
                et.Mennyiseg = decimal.Parse(textBox2.Text);
                et.Egysegar = (int)numericUpDown1.Value;
                // et.EtelTipusa = EtelTipus
                term.Add(et);
            }
            else
            {
                Ital it = new Ital();
                it.Megnevezes = textBox1.Text;
                it.Mennyiseg = decimal.Parse(textBox2.Text);
                it.Egysegar = (int)numericUpDown1.Value;
                if (checkBox1.Checked)
                {
                    it.SzensavasE = true;
                }
                if (checkBox2.Checked)
                {
                    it.AlkoholosE = true;
                }

                term.Add(it);
            }

        }
    }
}
