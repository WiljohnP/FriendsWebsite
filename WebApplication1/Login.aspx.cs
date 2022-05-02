using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query_user = "SELECT count(*) FROM [dbo].[User] WHERE Username='" + TextBox1.Text + "'";
            SqlCommand user_com = new SqlCommand(query_user, con);
            int temp = Convert.ToInt32(user_com.ExecuteScalar().ToString());
            con.Close();
            //System.Diagnostics.Debug.WriteLine(temp);
            if (temp == 1)
            {
                con.Open();
                string query_pass = "SELECT u.username, r.roleType  from [dbo].[User] u inner join [dbo].[Role] r ON u.type = r.Id where username = '" + TextBox1.Text + "'";
                SqlCommand reader_com = new SqlCommand(query_pass, con);
                SqlDataReader dr = reader_com.ExecuteReader();
                string temp_password = "";
                string role = "";
                while (dr.Read())
                {
                    temp_password = dr[0].ToString();
                    role = dr[1].ToString();
                }
                con.Close();
                if (temp_password.Trim() == TextBox2.Text.Trim())
                {
                    Response.Write("<script>alert('Login Successful!!')</script>");
                    Session["New"] = TextBox1.Text;
                    Session["Role"] = role;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Login Failed! Incorrect username/password')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Login Failed! Incorrect username/password')</script>");
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}