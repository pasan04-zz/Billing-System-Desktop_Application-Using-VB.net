using BillingSystem.Bill;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.DAL
{
    class userDAL
    {

        static string connstring1 = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region select Data from Database
        public DataTable Select()
        {
            //static method to connect to the database
            SqlConnection conn = new SqlConnection(connstring1);
            //to hold the data from the database
            DataTable dt = new DataTable();
            try
            {
                //sql query to get the data from the table
                String sql = "SELECT * from users";
                //for executing command
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //database connection open
                conn.Open();

                //fill data
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                conn.Close();

            }
            return dt;
        }


        #endregion

        #region Insert data in to database
        public bool Insert(UserBill u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connstring1);

            try
            {
                String sql = "insert into users(first_name,last_name,email,username,password,contact,address,gender,user_type,address_date,added_by) values(@first_name,@last_name,@email,@username,@password,@contact,@address,@gender,@user_type,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@first_name", u.first_name);

                cmd.Parameters.AddWithValue("@last_name", u.last_name);

                cmd.Parameters.AddWithValue("@email", u.email);

                cmd.Parameters.AddWithValue("@username", u.username);

                cmd.Parameters.AddWithValue("@password", u.password);

                cmd.Parameters.AddWithValue("@contact", u.contact);

                cmd.Parameters.AddWithValue("@address", u.address);

                cmd.Parameters.AddWithValue("@gender", u.gender);

                cmd.Parameters.AddWithValue("@user_type", u.user_type);

                cmd.Parameters.AddWithValue("@added_date", u.added_date);

                cmd.Parameters.AddWithValue("@added_by", u.added_by);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the query is excecuted succesfully then the value to rows will greater than 0 else it will less than 0

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;

                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();

            }
            return isSuccess;


        }
        #endregion


        #region update the table
        public bool update(UserBill u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(connstring1);
            try
            {

                string sql = "UPDATE users set first_name =@first_name,last_name=@last_name,email=@email,username=@username,password=@password,contact=@contact,address=@address,gender=@gender,user_type=@user_type,address_date=@added_date,added_by =@added_by where id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@first_name", u.first_name);

                cmd.Parameters.AddWithValue("@last_name", u.first_name);

                cmd.Parameters.AddWithValue("@email", u.first_name);

                cmd.Parameters.AddWithValue("@username", u.first_name);

                cmd.Parameters.AddWithValue("@password", u.first_name);

                cmd.Parameters.AddWithValue("@contact", u.contact);

                cmd.Parameters.AddWithValue("@address", u.address);

                cmd.Parameters.AddWithValue("@gender", u.gender);

                cmd.Parameters.AddWithValue("@user_type", u.user_type);

                cmd.Parameters.AddWithValue("@added_date", u.added_date);

                cmd.Parameters.AddWithValue("@added_by", u.added_by);

                cmd.Parameters.AddWithValue("@id", u.id);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the query success it will give sucess message
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {

                conn.Close();
            }
            return isSuccess;

        }
        #endregion


        #region delete data from table
        public bool Delete(UserBill u)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connstring1);

            try
            {
                string sql = "DELETE FROM users where id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", u.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                conn.Close();

            }


            return isSuccess;



        }
        #endregion


        #region search user on database using keywords
        public DataTable Search(string keywords)
        {
            SqlConnection conn = new SqlConnection(connstring1);

            DataTable dt = new DataTable();
            try
            {

                String sql = "SELECT * from users where id LIKE '%" + keywords + "%' OR username LIKE '%" + keywords + "%' OR first_name LIKE '%" + keywords + "%'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                conn.Close();

            }
            return dt;

        }

        #endregion

    }
}
