using MySql.Data.MySqlClient;
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
    public partial class Main3Withdraw : Form
    {
        public Main3Withdraw()
        {
            InitializeComponent();
            textBox1.Text = "Введите значение:";
            textBox1.ForeColor = Color.Gray;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `money3` = `money3` - @money3", db.getConnection());

            command.Parameters.Add("@money3", MySqlDbType.VarChar).Value = textBox1.Text;

            db.openConnection();

            Main3 f1;

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Не возможно пополнить");
                this.Hide();
                f1 = new Main3();
                f1.Show();
            }
            else
                MessageBox.Show("Сумма снята");

            db.closeConnection();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main3 Main3 = new Main3();
            Main3.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите значение:")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black; 
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите значение:";
                textBox1.ForeColor = Color.Gray;
            }
        }
    }
}
