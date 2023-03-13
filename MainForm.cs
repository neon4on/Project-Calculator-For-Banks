using MySqlX.XDevAPI.Common;
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


        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main3 mainForm = new Main3();
            mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        LoginForm f2;
        private void button4_Click(object sender, EventArgs e)
        {
            var result=MessageBox.Show("Нажмите да, если хотите и нет в ином случае", "Вы точно хотите выйти?" ,MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                f2 = new LoginForm();
                f2.Show();
            }
        }
    }
}
