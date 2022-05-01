using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class customerUEN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string inputVal = txtUEN.Text.Trim();
            bool intValid = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
            con.Open();
            string query_table = "SELECT count(*) FROM [dbo].[Table] WHERE uen= @uen";
            SqlCommand cmd = new SqlCommand(query_table, con);
            cmd.Parameters.AddWithValue("@uen", inputVal);
            if (Int32.TryParse(cmd.ExecuteScalar().ToString(), out int executedInt))
            {
                if (executedInt == 1)
                {
                    intValid = true;
                }
            }
            if (intValid == false)
            {
                Response.Write("<script>alert('Invalid UEN! Please reenter the UEN.')</script>");
            }
            else
            {
                Response.Redirect("customerOrder.aspx");
            }
        }
    }
}