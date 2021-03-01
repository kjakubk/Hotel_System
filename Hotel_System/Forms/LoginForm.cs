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

namespace Hotel_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Connect connect = new Connect();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();

            string query = "SELECT * FROM `user` WHERE `username`=@usn AND `password`=@pass";

            command.CommandText = query;
            command.Connection = connect.GetConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            //if username and password exist

            if(dataTable.Rows.Count > 0)
            {
                this.Hide();

                Main_Form main_Form = new Main_Form();
                main_Form.Show();

                //MessageBox.Show("YES");
            }
            else
            {
                if(textBoxUsername.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter your username to login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(textBoxPassword.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter your password to password", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Wrong username or password", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    } 
}
