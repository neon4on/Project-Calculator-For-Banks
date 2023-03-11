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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main1 Main1Form = new Main1();
            Main1Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main2 Main2Form = new Main2();
            Main2Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main3 Main3Form = new Main3();
            Main3Form.Show();
        }
    }
}
