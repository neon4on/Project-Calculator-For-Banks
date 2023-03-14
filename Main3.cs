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

        private void button5_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            String labelBalance = "3";

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT `money3` FROM `users` WHERE `id` = @ID", db.getConnection());

            command.Parameters.AddWithValue("@ID", MySqlDbType.VarChar).Value = labelBalance;

            MySqlDataReader da = command.ExecuteReader();

            while (da.Read())
            {
                label2.Text = da.GetValue(0).ToString();
            }
            button5.Visible = false;
            da.Close();
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) > 0)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE `users` SET `money3` = `money3` + @money3", db.getConnection());

                command.Parameters.Add("@money3", MySqlDbType.VarChar).Value = textBox1.Text;

                db.openConnection();

                Main3 f1;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Невозможно пополнить");
                    this.Hide();
                    f1 = new Main3();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Сумма внесена");
                }
                db.closeConnection();

                String labelBalance = "3";

                db = new DB();

                db.openConnection();

                command = new MySqlCommand("SELECT `money3` FROM `users` WHERE `id` = @ID", db.getConnection());

                command.Parameters.AddWithValue("@ID", MySqlDbType.VarChar).Value = labelBalance;

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox2.Text) > 0)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE `users` SET `money3` = `money3` - @money3", db.getConnection());

                command.Parameters.Add("@money3", MySqlDbType.VarChar).Value = textBox2.Text;

                db.openConnection();

                Main3 f1;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Невозможно вывести");
                    this.Hide();
                    f1 = new Main3();
                    f1.Show();
                }
                else
                    MessageBox.Show("Сумма выведена");

                db.closeConnection();

                String labelBalance = "3";

                db = new DB();

                db.openConnection();

                command = new MySqlCommand("SELECT `money3` FROM `users` WHERE `id` = @ID", db.getConnection());

                command.Parameters.AddWithValue("@ID", MySqlDbType.VarChar).Value = labelBalance;

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main4 a = new Main4();
            a.Show();
        }

        //    DB db = new DB();

        //    MySqlDataAdapter adapter = new MySqlDataAdapter();

        //    String labelBalance = "3";
        //    db.openConnection();
        //        MySqlCommand command = new MySqlCommand("SELECT `money3` FROM `users` WHERE `id` = @ID", db.getConnection());
        //    command.Parameters.AddWithValue("@ID", MySqlDbType.VarChar).Value = labelBalance;
        //        using (MySqlDataReader da = command.ExecuteReader())
        //        while (da.Read())
        //        {
        //            label2.Text = da.GetValue(0).ToString();
        //}
        //db.closeConnection();
    }
}
