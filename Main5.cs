using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    public partial class Main5 : Form
    {
        public Main5()
        {
            InitializeComponent();

            DB db = new DB();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT `money3` FROM `users` WHERE `login` = @ID", db.getConnection());

            command.Parameters.AddWithValue("@ID", ID.A);
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                textBox1.Text = da.GetValue(0).ToString();
            }

            da.Close();
            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            groupBox1.Visible = true;

        }

        private void label7_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = label7.Text;
            groupBox1.Visible = false;
            button2.Visible = true;

        }

        private void label8_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = label8.Text;
            groupBox1.Visible = false;
            button2.Visible = true;
            groupBox2.Visible = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = label9.Text;
            groupBox1.Visible = false;
            button2.Visible = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = label10.Text;
            groupBox1.Visible = false;
            button2.Visible = true;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = label11.Text;
            groupBox1.Visible = false;
            button2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n, proc, time, rper, monthproc;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите начальную сумму");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите время удержания в годах");
                return;
            }
            if (label12.Text == "")
            {
                MessageBox.Show("Введите процентную ставку");
                return;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Введите расчетный период вашего банка");
                return;
            }
            double sum = Convert.ToInt32(textBox1.Text), popsum;

            if (textBox4.Text != "")
            {
                popsum = Convert.ToInt32(textBox4.Text);
            }
            else
            {
                popsum = 0;
            }
            proc = Convert.ToDouble(label12.Text);
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

        private void label13_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            textBox2.Text = label13.Text;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            textBox2.Text = label14.Text;
        }
    }
}
