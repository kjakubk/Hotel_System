using Hotel_System.Class;
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
    public partial class Manage_Clients_Form : Form
    {

        Client client = new Client();


        public Manage_Clients_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonClearFields_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxPhoneNumber.Text = "";
            textBoxCountry.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string phoneNumber = textBoxPhoneNumber.Text;
            string country = textBoxCountry.Text;

            if (firstName.Trim().Equals("") || lastName.Trim().Equals("") || phoneNumber.Trim().Equals(""))
            {
                MessageBox.Show("Empty Fields - First name, Last name and Phone number", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                Boolean insertClient = client.insertClient(firstName, lastName, phoneNumber, country);

                if (insertClient)
                {
                    dataGridViewClient.DataSource = client.GetClients();
                    MessageBox.Show("New Client Added Successfuly", "Client Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Something goes wrong!!!", " Client Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           


        }

        private void Manage_Clients_Form_Load(object sender, EventArgs e)
        {
            dataGridViewClient.DataSource = client.GetClients();
        }
    }
}
