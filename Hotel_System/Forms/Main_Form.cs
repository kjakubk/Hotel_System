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
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void manageClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Clients_Form manage_Clients_Form = new Manage_Clients_Form();

            manage_Clients_Form.ShowDialog();
        }

        private void manageReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Reservations_Form manage_Reservations_Form = new Manage_Reservations_Form();

            manage_Reservations_Form.ShowDialog();

        }

        private void manageRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Rooms_From manage_Rooms_Form = new Manage_Rooms_From();
            manage_Rooms_Form.ShowDialog();
        }
    }
}
