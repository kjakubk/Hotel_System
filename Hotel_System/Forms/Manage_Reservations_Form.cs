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

            InitializeComponent();
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

        private void Manage_Reservations_Form_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";
            comboBoxRoomType.ValueMember = "Category_id";
        }

        private void comboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int roomType = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
                comboBoxRoomNumber.DataSource = room.roomByTypeList(roomType);
                comboBoxRoomNumber.DisplayMember = "RoomNumber";
                comboBoxRoomNumber.ValueMember = "RoomNumber";
            }
            catch (Exception ex)
            {

                
            }
           
        }
    }
}
