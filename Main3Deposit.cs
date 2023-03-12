using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Main3Deposit : Form
    {
        public Main3Deposit()
        {
            InitializeComponent();
            textBox1.Text = "Введите значение: ";
            textBox1.ForeColor = Color.Gray;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `money3` = (@money3)", db.getConnection());

            command.Parameters.Add("@money3", MySqlDbType.VarChar).Value = textBox1.Text;

            db.openConnection();

            Main3 f1;

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Сумма внесена");
                this.Hide();
                f1 = new Main3();
                f1.Show();
            }
            else
                MessageBox.Show("Не возможно пополнить");

            db.closeConnection();
        }
    }
}
