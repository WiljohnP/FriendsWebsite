using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Entity
{
    public class Table
    {
        public int id;
        public String uen;

        public DataTable getTableNo()
        {
            DataTable data = new DataTable();

            String sql = "Select id from [dbo].[Table] where uen = '" + uen + "'";

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

        public bool CheckUENExists()
        {
            bool isValid = false;

            String sql = "SELECT count(*) FROM [dbo].[Table] WHERE uen= '"+uen+"'";
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                Int32.TryParse(cmd.ExecuteScalar().ToString(), out int executedInt);
                if (executedInt == 1)
                {
                    isValid = true;
                }
                return isValid;
            }
            catch (Exception Ex)
            {
                return isValid;
            }
            finally
            {
                con.Close();
            }
        }
    }
}