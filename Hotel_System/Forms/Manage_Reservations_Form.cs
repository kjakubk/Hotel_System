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
    public partial class Manage_Reservations_Form : Form
    {
        Room room = new Room();

        public Manage_Reservations_Form()
        {
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";
            comboBoxRoomType.ValueMember = "Category_id";
            
        }

        private void buttonAddReservation_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemoveReservation_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditReservation_Click(object sender, EventArgs e)
        {

        }

        private void buttonClearFields_Click(object sender, EventArgs e)
        {
            textBoxClientID.Text = "";
            textBoxResID.Text = "";
            comboBoxRoomType.SelectedItem = 0 ;
            comboBoxRoomNumber.SelectedItem = 0;
            dateTimePickerDateIn.Value = DateTime.Now;
            dateTimePickerDateOut.Value = DateTime.Now;

        }
    }
}
