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



        private void Manage_Clients_Form_Load(object sender, EventArgs e)
        {
            dataGridViewClient.DataSource = client.GetClients();
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            String firstName = textBoxFirstName.Text;
            String lastName = textBoxLastName.Text;
            String phoneNumber = textBoxPhoneNumber.Text;
            String country = textBoxCountry.Text;

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

        private void buttonEditClient_Click(object sender, EventArgs e)
        {
            int id;
            String firstName = textBoxFirstName.Text;
            String lastName = textBoxLastName.Text;
            String phoneNumber = textBoxPhoneNumber.Text;
            String country = textBoxCountry.Text;

            try
            {
                id = Convert.ToInt32(textBoxID.Text);

                if (firstName.Trim().Equals("") || lastName.Trim().Equals("") || phoneNumber.Trim().Equals(""))
                {
                    MessageBox.Show("Empty Fields - First name, Last name and Phone number", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Boolean insertClient = client.editClient(id, firstName, lastName, phoneNumber, country);

                    if (insertClient)
                    {
                        dataGridViewClient.DataSource = client.GetClients();
                        MessageBox.Show("Client Data Updated Successfuly", "Client Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something goes wrong!!!", " Client Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message, "ID Error moja wina", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    

        /// <summary>
        /// Displey selected data from DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridViewClient.CurrentRow.Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridViewClient.CurrentRow.Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridViewClient.CurrentRow.Cells[2].Value.ToString();
            textBoxPhoneNumber.Text = dataGridViewClient.CurrentRow.Cells[3].Value.ToString();
            textBoxCountry.Text = dataGridViewClient.CurrentRow.Cells[4].Value.ToString();
        }

        private void buttonRemoveClient_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);


                if(client.removeClient(id))
                {
                    dataGridViewClient.DataSource = client.GetClients();
                    MessageBox.Show("Client Data Removed Successfuly", "Client Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Something goes wrong!!!", " Client Remove", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
