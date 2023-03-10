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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            userNameField.Text = "Введите имя";
            userNameField.ForeColor = Color.Gray;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
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

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя"){
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }   
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введите имя";
                userNameField.ForeColor = Color.Gray;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя")
            {
                MessageBox.Show("Введите имя");
                return;
            }

            if (userSurnameField.Text == "")
            {
                MessageBox.Show("Введите surname");
                return;
            }

            if (Login.Text == "")
            {
                MessageBox.Show("Введите login");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите pass");
                return;
            }

            //if (isUserExists())
            //{
            //    return;
            //}

            //DB db = new DB();
            //MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`) VALUES (@login, @pass, @name, @surname)", db.getConnection());

            //command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Login.Text;
            //command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox2.Text;
            //command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
            //command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userSurnameField.Text;

            //db.openConnection();

            //if (command.ExecuteNonQuery() == 1)
            //    MessageBox.Show("Acc create");
            //else
            //    MessageBox.Show("Acc not create");

            //db.closeConnection();
        }

        //public Boolean isUserExists()
        //{
        //    DB db = new DB();

        //    DataTable table = new DataTable();

        //    MySqlDataAdapter adapter = new MySqlDataAdapter();

        //    MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection()); ;

        //    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Login.Text;

        //    adapter.SelectCommand = command;
        //    adapter.Fill(table);

        //    if (table.Rows.Count > 0)
        //    {
        //        MessageBox.Show("Такой логин уже есть, введите другой");
        //        return true;
        //    }

        //    else
        //    {
        //        return false;
        //    }
        //}

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
