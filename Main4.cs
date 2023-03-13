using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main4 : Form
    {
        public Main4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n, proc, time, rper, monthproc;
            double sum = Convert.ToInt32(textBox1.Text)/*  */, popsum = Convert.ToInt32(textBox4.Text);

            proc = Convert.ToDouble(textBox3.Text);
            time = Convert.ToDouble(textBox2.Text);
            rper = Convert.ToDouble(textBox5.Text);

            time = (time * 12) / rper;
            monthproc = (proc / 12);

            for (int i = 0; i < time; i++)
            {
                sum = sum * (1 + monthproc / 100) + popsum;

            }
            textBox6.Text = sum.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Main3 f2;
        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            f2 = new Main3();
            f2.Show();
        }
    }
}
