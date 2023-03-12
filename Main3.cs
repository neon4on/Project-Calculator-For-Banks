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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT money3 FROM `users` WHERE `id` = 3", db.getConnection()); ;
            //MySqlDataReader dr = null;

            //dr = command.ExecuteReader();

            MySqlDataReader myFurer;
            myFurer = command.ExecuteReader();

            while (myFurer.Read())
            {
                Console.WriteLine(myFurer.GetInt32(0) + ", " + myFurer.GetString(1));
            }

            myFurer.Close();


            //command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Login.Text;

            //adapter.SelectCommand = command;
            //adapter.Fill(table);
            db.closeConnection();
        }
    }
}
