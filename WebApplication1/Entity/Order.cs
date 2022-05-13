using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Entity
{
    public class Order
    {
        public int orderId;
        public int tableId;
        public int orderStateId;
        public DateTime createdDt;
        public DateTime modifiedDt;

        public DataTable getOrder()
        {
            DataTable data = new DataTable();

            String sql = "Select orderStateId from [dbo].[Order] where orderStatedId = '" + menu + "' and tableId = '" + menu + "'";

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