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
    class loginDAL
    {


        static string connstring1 = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public bool loginCheck(loginBill lb)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(connstring1);

            try
            {
                string sql = "SELECT * from users where username = @username and password = @password and user_type = @usertype";

                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue("@username", lb.username);
                cmd.Parameters.AddWithValue("@password", lb.password);
                cmd.Parameters.AddWithValue("@usertype", lb.usertype);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {

                conn.Close();
            }

            return isSuccess;
        }


    }
}
