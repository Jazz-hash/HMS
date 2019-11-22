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
    public partial class Login : Form
    {
        database db = new database();
        public static int user_id;

        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string Email = textBox1.Text;
                string Password = textBox2.Text;

                Manager obj = db.Managers.Where(x => x.email == Email && x.password == Password).FirstOrDefault();
                Owner obj1 = db.Owners.Where(x => x.email == Email && x.password == Password).FirstOrDefault();

                if (obj != null)
                {
                    MessageBox.Show("Welcome Manager !!");
                    DashboardManager db_o = new DashboardManager();
                    db_o.Show();
                    
                    user_id = obj.Id; 
                    this.Hide();

                }
                else if (obj1 != null)
                {
                    MessageBox.Show("Welcome Owner !!");
                    DashboardOwner db_m = new DashboardOwner();
                    db_m.Show();
                    user_id = obj1.Id;

                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Wrong password");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register obj = new Register();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
