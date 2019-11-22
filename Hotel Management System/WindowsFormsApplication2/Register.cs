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
    public partial class Register : Form
    {
        database db = new database();

        public Register()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                Manager userregister = new Manager()
                {
                    name = textBox1.Text,
                    email = textBox2.Text,
                    password = textBox3.Text,
                    phone = textBox4.Text
                };
                db.Managers.Add(userregister);
                db.SaveChanges();
                MessageBox.Show("Chal bhai hogya register");

                Login form = new Login();
                form.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
