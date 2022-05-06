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
        private int id;
        private String username;
        private String staffNumber;
        private int phoneNumber;
        private int status;
        private String password;
        private String type;

        public DataTable getUserList()
        {
            DataTable data = new DataTable();

            String sql = "Select u.username, case when u.status = 1 then 'Active' else 'Inactive' end as status, r.roleType from [dbo].[User] as u inner join [dbo].[Role] as r on u.type = r.id";

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