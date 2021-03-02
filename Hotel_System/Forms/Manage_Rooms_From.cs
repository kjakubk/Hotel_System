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
    public partial class Manage_Rooms_From : Form
    {
        public Manage_Rooms_From()
        {
            InitializeComponent();
        }

        Room room = new Room();

        private void Manage_Rooms_From_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "Label";
            comboBoxRoomType.ValueMember = "Category_id";

            dataGridViewClient.DataSource = room.GetRooms();

        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            
            int roomType = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            String phoneNumber = textBoxPhoneNumber.Text;
            String isAvailable = "";

            try
            {
                int roomNumber = Convert.ToInt32(textBoxRoomNumber.Text);
                if (radioButtonYes.Checked)
                {
                    isAvailable = "YES";
                }
                else if (radioButtonNo.Checked)
                {
                    isAvailable = "NO";
                }

                if (room.insertRoom(roomNumber, roomType, phoneNumber, isAvailable))
                {
                    MessageBox.Show("Room added successfully", "Add room", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridViewClient.DataSource = room.GetRooms();
                }
                else
                {
                    MessageBox.Show("Something goes wrong", "Add room error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message, "ROOM NUMBER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void buttonClearFields_Click(object sender, EventArgs e)
        {
            textBoxRoomNumber.Text = "";
            comboBoxRoomType.SelectedValue = 0;
            textBoxPhoneNumber.Text = "";
            radioButtonYes.Checked = true;
        }

        private void dataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxRoomNumber.Text = dataGridViewClient.CurrentRow.Cells[0].Value.ToString();
            comboBoxRoomType.SelectedValue = dataGridViewClient.CurrentRow.Cells[1].Value;
            textBoxPhoneNumber.Text = dataGridViewClient.CurrentRow.Cells[2].Value.ToString();
            String isAvailable= dataGridViewClient.CurrentRow.Cells[3].Value.ToString();


            if(isAvailable.Equals("YES"))
            {
                radioButtonYes.Checked = true;
            }
            else if(isAvailable.Equals("NO"))
            {
                radioButtonNo.Checked = false;
            }
            dataGridViewClient.DataSource = room.GetRooms();
        }

        private void buttonEditRoom_Click(object sender, EventArgs e)
        {
            
            int roomType = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            String phoneNumber = textBoxPhoneNumber.Text;
            String isAvailable = "";
            try
            {
                int roomNumber = Convert.ToInt32(textBoxRoomNumber.Text);
                if (radioButtonYes.Checked)
                {
                    isAvailable = "YES";
                }
                else if (radioButtonNo.Checked)
                {
                    isAvailable = "NO";
                }

                if (room.editRoom(roomNumber, roomType, phoneNumber, isAvailable))
                {
                    MessageBox.Show("You successfuly edit room", "Room edit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridViewClient.DataSource = room.GetRooms();
                }
                else
                {
                    MessageBox.Show("Something went wrong", "Room edit error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ROOM NUMBER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }

        private void buttonRemoveRoom_Click(object sender, EventArgs e)
        {
            try
            {
                int roomNumber = Convert.ToInt32(textBoxRoomNumber.Text);

                if (room.removeRoom(roomNumber))
                {
                    MessageBox.Show("Room remove successfully", "Remove room", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridViewClient.DataSource = room.GetRooms();
                }
                else
                {
                    MessageBox.Show("Something went wrong", "Remove room error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ROOM NUMBER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
