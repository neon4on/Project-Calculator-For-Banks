using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace WindowsFormsApp1
{
    public partial class Main3 : Form
    {
        public Main3()
        {
            InitializeComponent();

            DB db = new DB();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT `money3` FROM `users` WHERE `login` = @ID", db.getConnection());

            command.Parameters.AddWithValue("@ID", ID.A);
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                label2.Text = da.GetValue(0).ToString();
            }

            da.Close();
            db.closeConnection();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main4 a = new Main4();
            a.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox1.Text) != "")
            {
                if (Convert.ToInt32(textBox1.Text) > 0)
                {

                    DB db = new DB();
                    MySqlCommand command = new MySqlCommand("UPDATE `users`  SET `money3` = `money3` + @money3 WHERE `login` = @ID", db.getConnection());

                    command.Parameters.AddWithValue("@money3", textBox1.Text);

                    command.Parameters.AddWithValue("@ID", ID.A);

                    db.openConnection();



                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Сумма внесена");
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Невозможно пополнить");
                    }
                    db.closeConnection();

                    db = new DB();

                    db.openConnection();

                    command = new MySqlCommand("SELECT `money3` FROM `users` WHERE `login` = @ID", db.getConnection());

                    command.Parameters.AddWithValue("@ID", ID.A);

                    MySqlDataReader da = command.ExecuteReader();

                    while (da.Read())
                    {
                        label2.Text = da.GetValue(0).ToString();
                    }
                    da.Close();
                    db.closeConnection();
                }
                else
                {
                    MessageBox.Show("Введите положительное число");
                }
            }
            else
            {
                MessageBox.Show("Введите положительное число");
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox2.Text) != "")
            {
                if (Convert.ToInt32(textBox2.Text) > 0)


                {

                    if (Convert.ToDouble(textBox2.Text) <= Convert.ToDouble(label2.Text))
                    {


                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("UPDATE `users` SET `money3` = `money3` - @money3 WHERE `login` = @ID", db.getConnection());

                        command.Parameters.AddWithValue("@money3", textBox2.Text);
                        command.Parameters.AddWithValue("@ID", ID.A);
                        db.openConnection();



                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Сумма выведена");
                            textBox2.Text = "";
                        }
                        else
                            MessageBox.Show("Невозможно вывести");

                        db.closeConnection();

                        db = new DB();

                        db.openConnection();

                        command = new MySqlCommand("SELECT `money3` FROM `users` WHERE `login` = @ID", db.getConnection());

                        command.Parameters.AddWithValue("@ID", ID.A);

                        MySqlDataReader da = command.ExecuteReader();

                        while (da.Read())
                        {
                            label2.Text = da.GetValue(0).ToString();
                        }
                        da.Close();
                        db.closeConnection();


                    }
                    else
                    {
                        MessageBox.Show("Недостаточно средств");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Введите положительное число");
                    return;

                }
            }
            else
            {
                MessageBox.Show("Введите положительное число");
            }
        }


        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }
        Point lastPoint;
        private void Main3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Main3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}