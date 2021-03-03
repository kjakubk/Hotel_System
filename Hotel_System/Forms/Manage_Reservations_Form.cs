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
            int reservationID = 0;
            int clientID = Convert.ToInt32(textBoxClientID.Text);
            int roomNumber = Convert.ToInt32(comboBoxRoomNumber.SelectedValue);
            DateTime dateIN = dateTimePickerDateIn.Value;
            DateTime dateOUT = dateTimePickerDateOut.Value;
            try

            {
                
                if(dateIN < DateTime.Now)
                {
                    MessageBox.Show("The Date In must be = or > TodayDate", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (dateOUT < dateIN)
                {
                    MessageBox.Show("The Date OUT must be = or > DateIN", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (reservation.addtReservation(reservationID,roomNumber, clientID, dateIN, dateOUT))
                    {
                        //set the room Available column to NO after add reservation
                        dataGridViewClient.DataSource = reservation.getReservation();

                        room.setRoomAvailable(roomNumber,"NO");

                        MessageBox.Show("Reservation added successfuly", "Reservation added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("SOMETHING WENT WRONG", "RESERVATION ADD ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }        
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }  
        }

        private void buttonRemoveReservation_Click(object sender, EventArgs e)
        {
            try
            {
                int reservationID = Convert.ToInt32(textBoxResID.Text);
                int roomNumber = Convert.ToInt32(comboBoxRoomNumber.SelectedValue);
                if (reservation.removeReservation(reservationID))
                {
                    dataGridViewClient.DataSource = reservation.getReservation();

                    room.setRoomAvailable(roomNumber, "YES");
                    MessageBox.Show("Remove success", "Remove data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("REMOVEING ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void buttonEditReservation_Click(object sender, EventArgs e)
        {
            int reservationID = Convert.ToInt32(textBoxResID.Text);
            int clientID = Convert.ToInt32(textBoxClientID.Text);
            int roomNumber = Convert.ToInt32(comboBoxRoomNumber.SelectedValue);
            DateTime dateIN = dateTimePickerDateIn.Value;
            DateTime dateOUT = dateTimePickerDateOut.Value;
            try
            {
                
                if (dateIN < DateTime.Now)
                {
                    dataGridViewClient.DataSource = reservation.getReservation();

                    MessageBox.Show("The Date In must be = or > TodayDate", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dateOUT < dateIN)
                {
                    MessageBox.Show("The Date OUT must be = or > DateIN", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (reservation.editReservation(reservationID,roomNumber, clientID, dateIN, dateOUT))
                    {
                        //set the room Available column to NO after add reservation
                        dataGridViewClient.DataSource = reservation.getReservation();
                        

                        MessageBox.Show("Reservation edited successfuly", "Reservation edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("SOMETHING WENT WRONG", "RESERVATION EDIT ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

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

            int roomType = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            comboBoxRoomNumber.DataSource = room.roomByTypeList(roomType);
            comboBoxRoomNumber.DisplayMember = "RoomNumber";
            comboBoxRoomNumber.ValueMember = "RoomNumber";

            //show all reservation in the data grindview

            dataGridViewClient.DataSource = reservation.getReservation();

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
            textBoxResID.Text = dataGridViewClient.CurrentRow.Cells[0].Value.ToString();

            int roomID = Convert.ToInt32(dataGridViewClient.CurrentRow.Cells[1].Value.ToString());

            comboBoxRoomType.SelectedValue = room.getRoomByTypeList(roomID);

            comboBoxRoomNumber.SelectedValue = roomID;

            textBoxClientID.Text = dataGridViewClient.CurrentRow.Cells[2].Value.ToString();




            
        }
    }
}


// Foreign key for roomrype ALTER TABLE rooms add CONSTRAINT fk_RoomTypeID FOREIGN KEY (RoomType) REFERENCES rooms_category(Category_id) ON UPDATE CASCADE on DELETE CASCADE;

//foreign key for room id ALTER TABLE reservation add CONSTRAINT fk_RoomNumber FOREIGN KEY (RoomNumber) REFERENCES rooms(RoomNumber) ON UPDATE CASCADE on DELETE CASCADE;

//for client ALTER TABLE reservation add CONSTRAINT fk_RoomNumber FOREIGN KEY (ClientID) REFERENCES client(ID) ON UPDATE CASCADE on DELETE CASCADE;