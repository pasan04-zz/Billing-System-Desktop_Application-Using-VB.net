using BillingSystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        loginDAL ld = new loginDAL();
        loginBill lb = new loginBill();


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lb.username = username.Text.Trim();
            lb.password = password.Text.Trim();
            lb.usertype = userType.Text.Trim();

            bool success = ld.loginCheck(lb);

            if(success == true)
            {
                try
                {
                    AdminDashboard adm = new AdminDashboard();
                    adm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                    clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid login details");
                clear();

            }


  
        }

        public void clear()
        {

            username.Text = "";
            password.Text = "";
            userType.Text = "";
        }
    }
}
