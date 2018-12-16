using BillingSystem.Bill;
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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        UserBill u = new UserBill();
        userDAL userdal = new userDAL();
        const int NAME_MAX_CHARACTERS = 4;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = userdal.Select();
            dgv.DataSource = dt;


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (validation() == true)
            {

                //getting data from UI
                u.first_name = first_name.Text;
                u.last_name = last_name.Text;
                u.email = email.Text;
                u.username = username.Text;
                u.password = password.Text;
                u.contact = contact.Text;
                u.address = address.Text;
                u.gender = gender.Text;
                u.user_type = userType.Text;
                u.added_date = DateTime.Now;
                u.added_by = 1;

                bool success1 = userdal.Insert(u);
                //bool success1 = true;
                if (success1 = true)
                {
                    MessageBox.Show("User succesfully created");
                }
                else
                {
                    MessageBox.Show("User not succesfully created");
                }

                DataTable dt = userdal.Select();
                dgv.DataSource = dt;
                clear();
            }
            else
            {
                clear();
                MessageBox.Show("Please fill the form correctly");

            }

        }

        public void clear()
        {
            text_id.Text = "";
            first_name.Text = "";
            last_name.Text = "";
            email.Text = "";
            username.Text = "";
            password.Text = "";
            contact.Text = "";
            address.Text = "";
            gender.Text = "";
            userType.Text = "";
        }

        public bool validation()
        {
            string nameText = first_name.Text;
            string lastnameText = last_name.Text;
            string usernameText = username.Text;

            if (String.IsNullOrEmpty(nameText) || String.IsNullOrEmpty(lastnameText) || String.IsNullOrEmpty(usernameText))
            {
                MessageBox.Show("Fields cannot be empty");
                return false;
            }
            if (nameText.Contains(" ") || lastnameText.Contains(" ") || usernameText.Contains(" "))
            {
                MessageBox.Show("Fields cannot have empty spaces");
                return false;
            }
            if (usernameText.Length < NAME_MAX_CHARACTERS)
            {
                MessageBox.Show("username should be lesser than "+NAME_MAX_CHARACTERS+"characters");
                return false;
            }

            return true;
        }

        private void first_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(text_id.Text);
            u.first_name = first_name.Text;
            u.last_name = last_name.Text;
            u.email = email.Text;
            u.username = username.Text;
            u.password = password.Text;
            u.contact = contact.Text;
            u.address = address.Text;
            u.gender = gender.Text;
            u.user_type = userType.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;

            bool success = userdal.update(u);

            if (success == true)
            {

                MessageBox.Show("Successfully Updated");
                clear();
                DataTable dt = userdal.Select();
                dgv.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error! while updating!");
                DataTable dt = userdal.Select();
                dgv.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(text_id.Text);
            bool success = userdal.Delete(u);

            if(success == true)
            {
                MessageBox.Show("Successfully deleted the item");
                DataTable dt = userdal.Select();
                dgv.DataSource = dt;
                clear();
            }
            else
            {
                MessageBox.Show("Cannot be deleted succesfully");
                DataTable dt = userdal.Select();
                dgv.DataSource = dt;
            }


        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //Get index of particular row

            int rowIndex = e.RowIndex;

            text_id.Text = dgv.Rows[rowIndex].Cells[0].Value.ToString();
            first_name.Text = dgv.Rows[rowIndex].Cells[1].Value.ToString();
            last_name.Text = dgv.Rows[rowIndex].Cells[2].Value.ToString();
            email.Text = dgv.Rows[rowIndex].Cells[3].Value.ToString();
            username.Text = dgv.Rows[rowIndex].Cells[4].Value.ToString();
            password.Text = dgv.Rows[rowIndex].Cells[5].Value.ToString();
            contact.Text = dgv.Rows[rowIndex].Cells[6].Value.ToString();
            address.Text = dgv.Rows[rowIndex].Cells[7].Value.ToString();
            gender.Text = dgv.Rows[rowIndex].Cells[8].Value.ToString();
            userType.Text = dgv.Rows[rowIndex].Cells[9].Value.ToString();


        }

        private void keywords_TextChanged(object sender, EventArgs e)
        {
            string keywords12 = keywords.Text;

            if(keywords12 != null)
            {

                DataTable dt = userdal.Search(keywords12);
                dgv.DataSource = dt;


            }
            else
            {
                DataTable dt = userdal.Select();
                dgv.DataSource = dt;

            }
        }
    }
}
