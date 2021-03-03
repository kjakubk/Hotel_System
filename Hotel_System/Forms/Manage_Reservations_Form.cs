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
        Reservation reservation = new Reservation();

        public Manage_Reservations_Form()
        {

            InitializeComponent();
        }

        private void buttonAddReservation_Click(object sender, EventArgs e)
        {
           

            try

            {
                int clientID = Convert.ToInt32(textBoxClientID.Text);
                int roomNumber = Convert.ToInt32(comboBoxRoomNumber.SelectedValue);
                DateTime dateIN = dateTimePickerDateIn.Value;
                DateTime dateOUT = dateTimePickerDateOut.Value;
                if(dateIN < DateTime.Now)
                {
                    MessageBox.Show("The Date In must be = or > TodayDate", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (dateOUT<dateIN)
                {
                    MessageBox.Show("The Date In must be = or > DateIN", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
                if (reservation.addtReservation(roomNumber, clientID, dateIN, dateOUT))
                {
                    //set the room Available column to NO after add reservation

                    room.setRoomToNo(roomNumber);
                  
                    MessageBox.Show("Reservation added successfuly", "Reservation added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("SOMETHING WENT WRONG", "RESERVATION ADD ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
          
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

        private void dataGridViewClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxClientID.Text = dataGridViewClient.CurrentRow.Cells[0].Value.ToString();
            textBoxResID.Text= dataGridViewClient.CurrentRow.Cells[1].Value.ToString();
            comboBoxRoomType.SelectedValue = dataGridViewClient.CurrentRow.Cells[2].Value.ToString();
            comboBoxRoomNumber.SelectedValue = dataGridViewClient.CurrentRow.Cells[3].Value.ToString();

            
        }
    }
}


// Foreign key for roomrype ALTER TABLE rooms add CONSTRAINT fk_RoomTypeID FOREIGN KEY (RoomType) REFERENCES rooms_category(Category_id) ON UPDATE CASCADE on DELETE CASCADE;

//foreign key for room id ALTER TABLE reservation add CONSTRAINT fk_RoomNumber FOREIGN KEY (RoomNumber) REFERENCES rooms(RoomNumber) ON UPDATE CASCADE on DELETE CASCADE;

//for client ALTER TABLE reservation add CONSTRAINT fk_RoomNumber FOREIGN KEY (ClientID) REFERENCES client(ID) ON UPDATE CASCADE on DELETE CASCADE;