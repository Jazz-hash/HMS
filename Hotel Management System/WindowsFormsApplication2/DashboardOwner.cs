
using MaterialSkin;
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
using WindowsFormsApplication2.Reports;

namespace WindowsFormsApplication2
{
    public partial class DashboardOwner : MaterialForm
    {
        database data = new database();
        MaterialSkinManager skinManager = MaterialSkinManager.Instance;

        public DashboardOwner()
        {
            InitializeComponent();
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
               Primary.Red50, Primary.Red800,
               Primary.Red100, Accent.Red100,
               TextShade.BLACK
           );
            data_Load();

        }

        DialogResult dr = new DialogResult();

        private void Dashboard_owner_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataLoad()
        {

            try
            {
                DataTable tb_data = new DataTable();
                tb_data.Columns.Add("ROOM");
                tb_data.Columns.Add("TYPE");
                tb_data.Columns.Add("DESCRIPTION");
                tb_data.Columns.Add("PRICE");

                var roomData = from item in data.Rooms
                               where item.status == "Inactive"
                               select new
                               {
                                   item.Room_no,
                                   item.type,
                                   item.description,
                                   item.price
                               };
                ;

                foreach (var room in roomData)
                {
                    DataRow row = tb_data.NewRow();
                    row["ROOM"] = room.Room_no;
                    row["TYPE"] = room.type;
                    row["DESCRIPTION"] = room.description;
                    row["PRICE"] = room.price;
                    tb_data.Rows.Add(row);
                    //tb_data.ImportRow(row);
                }

                metroGrid2.DataSource = tb_data;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


            try
            {
                DataTable tb_data2 = new DataTable();
                tb_data2.Columns.Add("ROOM");
                tb_data2.Columns.Add("TYPE");
                tb_data2.Columns.Add("DESCRIPTION");
                tb_data2.Columns.Add("PRICE");

                var roomData2 = from item in data.Rooms
                                where item.status == "active"
                                select new
                                {
                                    item.Room_no,
                                    item.type,
                                    item.description,
                                    item.price
                                };
                ;

                foreach (var room in roomData2)
                {
                    DataRow row = tb_data2.NewRow();
                    row["ROOM"] = room.Room_no;
                    row["TYPE"] = room.type;
                    row["DESCRIPTION"] = room.description;
                    row["PRICE"] = room.price;
                    tb_data2.Rows.Add(row);
                    //tb_data.ImportRow(row);
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }


        }

        private void DashboardManager_Load(object sender, EventArgs e)
        {
            dataLoad();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            expense expData = new expense()
            {
                item = metroTextBox1.Text,
                price = metroTextBox1.Text,
                descripton = metroTextBox1.Text
            };
            data.expenses.Add(expData);
            data.SaveChanges();
            MessageBox.Show("Expense Submitted");
            data_Load();

        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage4;
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage3;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HotelFacility facility = new HotelFacility()
            {
                category = metroComboBox2.Text,
                item = metroTextBox6.Text,
                description = metroTextBox4.Text,
                price = metroTextBox5.Text
            };
            data.HotelFacilities.Add(facility);
            data.SaveChanges();
            MessageBox.Show("Facility Submitted");
            data_Load();

        }

        private void button3_Click(object sender, EventArgs e)
        {



            Customer customer = new Customer()
            {
                Name = metroTextBox7.Text,
                nic = metroTextBox8.Text,
                phone = metroTextBox9.Text,
                email = metroTextBox10.Text,
                nationality = metroTextBox11.Text,
                martialstatus = metroTextBox12.Text,
                registered_by = Login.user_id
            };
            data.Customers.Add(customer);
            data.SaveChanges();
            MessageBox.Show("Customer Added");
            data_Load();


        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {

            materialTabControl1.SelectedTab = tabPage2;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage1;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Room sr = new Room()
            {
                Room_no = metroTextBox13.Text,
                status = metroComboBox1.Text,
                type = metroTextBox14.Text,
                description = metroTextBox16.Text,
                price = metroTextBox17.Text,
            };
            data.Rooms.Add(sr);
            data.SaveChanges();

            MessageBox.Show("Room Saved");
            dataLoad();
            data_Load();
        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage5;
        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(metroComboBox3.Text == "Hotel Facilities")
            {
                FacilityR addFacility = new FacilityR();
                crystalReportViewer1.ReportSource = addFacility;
            }
            else if(metroComboBox3.Text == "Managers")
            {
                ManagerR addManager = new ManagerR();
                crystalReportViewer1.ReportSource = addManager;

            }
            else if (metroComboBox3.Text == "Customers")
            {
                CustomerR addCustomer = new CustomerR();
                crystalReportViewer1.ReportSource = addCustomer;

            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private  void data_Load()
        {
            metroGrid1.DataSource = data.Customers.ToList();
            metroGrid4.DataSource = data.HotelFacilities.ToList();
            metroGrid5.DataSource = data.expenses.ToList();

            metroGrid6.DataSource = data.RoomRegisters.ToList();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
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

        private void materialFlatButton6_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedTab = tabPage7;
        }

        private void metroGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            metroButton2.Enabled = false;
            metroButton1.Enabled = true;
            metroButton5.Enabled = true;
            int cus_id = Convert.ToInt32(metroGrid1.CurrentRow.Cells[0].Value.ToString());
            Customer customer = data.Customers.Where(x => x.Id == cus_id).FirstOrDefault();

            metroTextBox7.Text = customer.Name;
            metroTextBox8.Text = customer.nic;
            metroTextBox9.Text = customer.phone;
            metroTextBox10.Text = customer.email;
            metroTextBox11.Text = customer.nationality;
            metroTextBox12.Text = customer.martialstatus;
            dataLoad();
            data_Load();
            
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            int cus_id = Convert.ToInt32(metroGrid1.CurrentRow.Cells[0].Value.ToString());
            Customer customer = data.Customers.Where(x => x.Id == cus_id).FirstOrDefault();
            customer.Name = metroTextBox7.Text;
            customer.nic = metroTextBox8.Text;
            customer.phone = metroTextBox9.Text;
            customer.email = metroTextBox10.Text;
            customer.nationality = metroTextBox11.Text;
            customer.martialstatus = metroTextBox12.Text;
            data.SaveChanges();
            metroButton2.Enabled = true;
            dataLoad();
            data_Load();
            data_clear_guest();

            metroButton1.Enabled = false;
            metroButton5.Enabled = false;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            int cus_id = Convert.ToInt32(metroGrid1.CurrentRow.Cells[0].Value.ToString());
            Customer customer = data.Customers.Where(x => x.Id == cus_id).FirstOrDefault();
            data.Customers.Remove(customer);
            data.SaveChanges();
            metroButton2.Enabled = true;
            dataLoad();
            data_Load();
            data_clear_guest();

            metroButton1.Enabled = false;
            metroButton5.Enabled = false;
        }
        
        private void data_clear_guest()
        {
            metroTextBox7.Text = metroTextBox8.Text = metroTextBox9.Text = metroTextBox10.Text = metroTextBox11.Text = metroTextBox12.Text = metroTextBox7.Text = metroTextBox7.Text = metroTextBox7.Text = "";
        }
    }
}
