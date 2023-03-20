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
            label15.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            label15.Visible = false;
            label19.Visible = true;

        }

        private void label7_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = label7.Text;
            groupBox1.Visible = false;
            button2.Visible = true;
            label15.Text = "3";
            label19.Visible = false;
            

        }

        private void label8_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = label8.Text;
            label19.Visible = false;
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
            groupBox3.Visible = true;
            label19.Visible = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = label10.Text;
            groupBox1.Visible = false;
            label19.Visible = false;
            button2.Visible = true;
            label15.Text = "12";
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label12.Visible = true;
            label12.Text = label11.Text;
            groupBox1.Visible = false;
            button2.Visible = true;
            label19.Visible = false;
            label15.Text = "24";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double  proc, monthproc;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите начальную сумму");
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




            int time = Convert.ToInt32(label15.Text);

            monthproc = (proc / 12);

            for (int i = 0; i < time; i++)
            {
                sum = sum * (1 + monthproc / 100) + popsum;

            }
            textBox6.Text = sum.ToString();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label15.Visible = true;
            groupBox2.Visible = false;
            label19.Visible = false;
            label15.Text = label13.Text;

        }

        private void label14_Click(object sender, EventArgs e)
        {
            label15.Visible = true;
            groupBox2.Visible = false;
            label19.Visible = false;
            label15.Text = label14.Text;
            groupBox2.Visible = false;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > e.OldValue)
            {
                
                label7.Top -= (e.NewValue-e.OldValue);
                label8.Top -= (e.NewValue - e.OldValue);
                label9.Top -= (e.NewValue - e.OldValue);
                label10.Top -= (e.NewValue - e.OldValue);
                label11.Top -= (e.NewValue - e.OldValue);

            }
            if (e.NewValue < e.OldValue)
            {
                label7.Top += (e.OldValue - e.NewValue);
                label8.Top += (e.OldValue - e.NewValue);
                label9.Top += (e.OldValue - e.NewValue);
                label10.Top += (e.OldValue - e.NewValue);
                label11.Top += (e.OldValue - e.NewValue);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            label15.Visible = true;
            groupBox2.Visible = false;
            label19.Visible = false;
            label15.Text = label13.Text;
            label19.Visible = false;
            groupBox2.Visible = false;
        }

        private void label18_Click(object sender, EventArgs e)
        {
            label15.Visible = true;
            groupBox2.Visible = false;
            label19.Visible = false;
            label15.Text = label14.Text;
            label19.Visible = false;
            groupBox2.Visible = false;
        }

        private void label23_Click(object sender, EventArgs e)
        {
            label15.Text = label23.Text;
            groupBox3.Visible = false;
            label19.Visible = false;
            groupBox3.Visible = false;
        }

        private void label21_Click(object sender, EventArgs e)
        {
            label15.Text = label23.Text;
            groupBox3.Visible = false;
            label19.Visible = false;
            groupBox3.Visible = false;
        }

        private void label22_Click(object sender, EventArgs e)
        {
            label15.Text = label22.Text;
            groupBox3.Visible = false;
            label19.Visible = false;
            groupBox3.Visible = false;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            label15.Text = label22.Text;
            groupBox3.Visible = false;
            label19.Visible = false;
            groupBox3.Visible = false;
        }
        Point lastPoint;

        private void Main5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Main5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            label15.Visible = true;
            groupBox2.Visible = false;
            label19.Visible = false;
            label15.Text = label13.Text;
            label19.Visible = false;
            groupBox2.Visible = false;
        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }
    }
}
