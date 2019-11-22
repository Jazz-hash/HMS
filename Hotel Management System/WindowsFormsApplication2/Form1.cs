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
    public partial class Form1 : Form
    {
        database db = new database();

        public Form1()
        {
            InitializeComponent();

            //comboBox1.DataSource = db.RoomCats.ToList();
            //comboBox1.DisplayMember = "CatName";
            //comboBox1.ValueMember = "Id";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            RoomCat rc = new RoomCat()
            {
                CatName = textBox1.Text

            };


            db.RoomCats.Add(rc);
            db.SaveChanges();

            dataGridView1.DataSource = db.RoomCats.ToList();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Facility obj = new Facility()
            {
                Name = txtfac.Text,
                Description = txtdesc.Text,
                RoomCat_Id = int.Parse(comboBox1.SelectedValue.ToString())

            };



            db.Facilities.Add(obj);
            db.SaveChanges();


            var ovj = from item in db.Facilities.ToList()
                      select new { Name = item.Name, decription = item.Description, RoomCatName = item.RoomCat.CatName };
            dataGridView2.DataSource = ovj.ToList();


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
         



        }
    }
}