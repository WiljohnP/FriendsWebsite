using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Entity
{
    public class User
    {
        public int id;
        public String username;
        public String staffNumber;
        public Int32 phoneNumber;
        public int status;
        public String password;
        public int type;

        public DataTable getUserList()
        {
            DataTable data = new DataTable();

            String sql = "Select u.username, u.staffnumber, u.phonenumber, case when u.status = 1 then 'Active' else 'Inactive' end as status, r.roleType from [dbo].[User] as u inner join [dbo].[Role] as r on u.type = r.id";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }

        public int checkUser(string tb1)
        {
            //checks for user in database by counting number of user with inputted username. the valid answer can only be 1.
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query_user = "SELECT count(*) FROM [dbo].[User] WHERE Username='" + tb1 + "'";
            SqlCommand user_com = new SqlCommand(query_user, con);
            int userExists = Convert.ToInt32(user_com.ExecuteScalar().ToString());
            con.Close();

            return userExists;
        }

        public string[] getPass(string tb1)
        {
            //gets password of inputted username
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query_pass = "SELECT u.password, r.roleType  from [dbo].[User] u inner join [dbo].[Role] r ON u.type = r.Id where username = '" + tb1 + "'";
            SqlCommand reader_com = new SqlCommand(query_pass, con);
            SqlDataReader dr = reader_com.ExecuteReader();
            string[] strDr = new string[2];
            while (dr.Read())
            {
                strDr[0] = dr[0].ToString().Trim();
                strDr[1] = dr[1].ToString();
            }
            con.Close();
            return strDr;
        }

        public bool setUser()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "INSERT INTO [dbo].[User] (username, staffNumber, phoneNumber, status, password, type) ";
            query += " VALUES ('" + username + "', '" + staffNumber + "'," + phoneNumber + "," + status + ",'" + password + "'," + type + "); ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            { 
                return false; 
            }
        }

        public bool deleteUser()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "Delete From [dbo].[User] Where username = '" + username + "' ";
            
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public bool updateUser()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "UPDATE [dbo].[User]  SET staffNumber = '" + staffNumber + "', phoneNumber = '" + phoneNumber + "', status = '" + status + "', type = '" + type + "' ";
            if (password != "")
            {
                query += " , password = '" + password + "'";
            }
            query += " WHERE username = '" + username + "' ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public DataTable getUserDetail()
        {
            DataTable data = new DataTable();

            String sql = "Select username, staffnumber, phonenumber, status, type from [dbo].[User] where username = '" + username +"'";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(data);
            con.Close();
            da.Dispose();

            return data;
        }
    }
}