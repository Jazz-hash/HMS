using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2.Model;

namespace WindowsFormsApplication2
{
    public partial class DashboardManager : MaterialForm
    {
        database data = new database();

        public DashboardManager()
        {
            InitializeComponent();
            dataload();
            materialTabControl1.SelectedTab = tabPage4;
            metroGrid3.DataSource = data.Customers.ToList();
           

        }

        private void dataload()
        {
            metroComboBox1.DataSource = data.Customers.ToList();
            metroComboBox1.DisplayMember = "Name";
            metroComboBox1.ValueMember = "Id";
            var availableRooms = from item in data.Rooms
                                 where item.status == "Inactive"
                                 select item;
            metroGrid1.DataSource = availableRooms.ToList();
            var userData = (from x in data.Rooms select x).Count();
            rooms_count.Text = userData.ToString();

            metroGrid2.DataSource = data.HotelFacilities.ToList();





            var single = from item in data.HotelFacilities
                         where item.category == "Single"
                         select item;
            dataGridView1.DataSource = single.ToList();



            var Double = from item in data.HotelFacilities
                         where item.category == "Double"
                         select item;
            dataGridView1.DataSource = single.ToList();

            var King = from item in data.HotelFacilities
                       where item.category == "King"
                       select item;
            dataGridView1.DataSource = single.ToList();

            var Queen = from item in data.HotelFacilities
                        where item.category == "Queen"
                        select item;
            dataGridView1.DataSource = single.ToList();


        }

        DialogResult dr = new DialogResult();
        private void Dashboard_manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            dr = MessageBox.Show("Are you sure you want to logout ?", "Notification", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                e.Cancel = (dr == DialogResult.No);
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage1;
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage4;

        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage3;

        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage2;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            metroGrid3.DataSource = data.Customers.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please fill out all the details !!");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please fill out all the details !!");
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please fill out all the details !!");
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please fill out all the details !!");
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Please fill out all the details !!");
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Please fill out all the details !!");
            }
            else
            {

                Customer cusData = new Customer()
                {
                    Name = textBox1.Text,
                    nic = textBox1.Text,
                    phone = textBox1.Text,
                    email = textBox1.Text,
                    nationality = textBox1.Text,
                    martialstatus = textBox1.Text,
                    registered_by = Login.user_id,
                };
                data.Customers.Add(cusData);
                data.SaveChanges();
                dataload();
                MessageBox.Show("Guest Registered");
            }

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dr = MessageBox.Show("Are you sure you want to logout ?", "Notification", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                return;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dr = MessageBox.Show("Are you sure you want to logout ?", "Notification", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            else
            {
                return;
            }
        }

        private void metroGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string room_number = metroGrid1.CurrentRow.Cells[1].Value.ToString();
            metroTextBox1.Text = room_number;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price = 0;
            int room_id = Convert.ToInt32(metroGrid1.CurrentRow.Cells[0].Value.ToString());
            Room room = data.Rooms.Where(x => x.Id == room_id).FirstOrDefault();
            price = Convert.ToDouble(room.price);
           
            string total_price = (Convert.ToDouble(metroTextBox2.Text) * price).ToString();

            if (metroTextBox2.Text == "")
            {
                MessageBox.Show("Please enter the timespan of room");
            }
            else if (metroTextBox1.Text == "")
            {
                MessageBox.Show("Please select any one of the room listed above");

            }
            else
            {
                roomRegister roomData = new roomRegister()
                {
                    roomNo = metroTextBox1.Text,
                    guestName = metroComboBox1.Text,
                    time = metroTextBox2.Text,
                    price = total_price,
                };
                data.RoomRegisters.Add(roomData);
                data.SaveChanges();
                MessageBox.Show("Room reserved !!");
            }
        }
    }
}
