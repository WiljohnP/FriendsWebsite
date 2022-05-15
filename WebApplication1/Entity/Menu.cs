using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Entity
{
    public class Menu
    {
        public int id;
        public String category;
        public String menu;
        public Double price;
        public String status;
        public String path;

        public DataTable getMenuList()
        {
            DataTable data = new DataTable();

            String sql = "Select id, menu, category, CAST(price AS DECIMAL(10, 2)) as price, status, path from [dbo].[Food] ";

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

        public DataTable getAvailableMenu()
        {
            DataTable data = new DataTable();

            String sql = "Select id, menu, category, CAST(price AS DECIMAL(10, 2)) as price, path from [dbo].[Food] where status = 'Available' ";

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

        public bool setMenu()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "INSERT INTO [dbo].[Food] (menu, category, price, status, path) ";
            query += " VALUES ('" + menu + "', '" + category + "','" + price + "','" + status + "','" + path + "'); ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception Ex)
            {
                con.Close();
                return false;
            }
        }

        public bool deleteMenu()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "Delete From [dbo].[Food] Where id = " + id + " ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception Ex)
            {
                con.Close();
                return false;
            }
        }

        public bool updateMenu()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query = "UPDATE [dbo].[Food]  SET menu = '" + menu + "', category = '" + category + "', price = '" + price + "', status = '" + status + "' ";
            if (path != "")
            {
                query += " , path = '" + path + "'";
            }
            query += " Where id = " + id + " ";
            
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception Ex)
            {
                con.Close();
                return false;
            }
        }

        public DataTable getMenuDetail()
        {
            DataTable data = new DataTable();

            String sql = "Select id, menu, category, CAST(price AS DECIMAL(10, 2)) as price, status, path from [dbo].[Food] where id = '" + id + "'";

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

        public DataTable getMenuName()
        {
            DataTable data = new DataTable();

            String sql = "Select menu from [dbo].[Food] where menu = '" + menu + "'";

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