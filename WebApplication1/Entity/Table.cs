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
    }
}