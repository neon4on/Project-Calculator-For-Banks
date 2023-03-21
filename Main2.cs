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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp1
{
    public partial class Main2 : Form
    {
        public Main2()
        {
            InitializeComponent();


            DB db = new DB();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT `money2` FROM `users` WHERE `login` = @ID", db.getConnection());

            command.Parameters.AddWithValue("@ID", ID.A);
            MySqlDataReader da = command.ExecuteReader();
            while (da.Read())
            {
                label3.Text = da.GetValue(0).ToString();
            }

            da.Close();
            db.closeConnection();
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main4 calc = new Main4();
            calc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox1.Text) != "")
            {
                if (Convert.ToInt32(textBox1.Text) > 0)
                {

                    DB db = new DB();

                    MySqlCommand command = new MySqlCommand("UPDATE `users`  SET `money2` = `money2` + @money2 WHERE `login` = @ID", db.getConnection());

                    command.Parameters.AddWithValue("@money2", textBox1.Text);

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

                    command = new MySqlCommand("SELECT `money2` FROM `users` WHERE `login` = @ID", db.getConnection());

                    command.Parameters.AddWithValue("@ID", ID.A);

                    MySqlDataReader moneybro = command.ExecuteReader();

                    while (moneybro.Read())
                    {
                        label3.Text = moneybro.GetValue(0).ToString();
                    }

                    moneybro.Close();

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(textBox2.Text) != "")
            {
                if (Convert.ToInt32(textBox2.Text) > 0)
                {
                    if (Convert.ToDouble(textBox2.Text) <= Convert.ToDouble(label3.Text))
                    {
                        DB db = new DB();

                        MySqlCommand command = new MySqlCommand("UPDATE `users` SET `money2` = `money2` - @money2 WHERE `login` = @ID", db.getConnection());

                        command.Parameters.AddWithValue("@money2", textBox2.Text);

                        command.Parameters.AddWithValue("@ID", ID.A);

                        db.openConnection();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Сумма выведена");
                            textBox2.Text = "";
                        }

                        else
                        {
                            MessageBox.Show("Невозможно вывести");
                        }

                        db.closeConnection();

                        db = new DB();

                        db.openConnection();

                        command = new MySqlCommand("SELECT `money2` FROM `users` WHERE `login` = @ID", db.getConnection());

                        command.Parameters.AddWithValue("@ID", ID.A);

                        MySqlDataReader moneybro = command.ExecuteReader();

                        while (moneybro.Read())
                        {
                            label3.Text = moneybro.GetValue(0).ToString();
                        }

                        moneybro.Close();

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

        private void closebutton_MouseEnter(object sender, EventArgs e)
        {
            closebutton.ForeColor = Color.Red;
        }

        private void closebutton_MouseLeave(object sender, EventArgs e)
        {
            closebutton.ForeColor = Color.White;
        }

        Point lastPoint;

        private void Main2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Main2_MouseDown(object sender, MouseEventArgs e)
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