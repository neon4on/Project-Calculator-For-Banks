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
            this.Hide();
            Main3Deposit Main3Deposit = new Main3Deposit();
            Main3Deposit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main3Withdraw Main3Main3Withdraw = new Main3Withdraw();
            Main3Main3Withdraw.Show();
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
