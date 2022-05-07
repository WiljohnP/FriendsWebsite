using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using static WebApplication1.Controller.UserControl;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebApplication1.Controller.UserControl usercon = new WebApplication1.Controller.UserControl();
            string ret = usercon.validateLogin(TextBox1.Text, TextBox2.Text.Trim());

            if ( ret == "fail" )
                Response.Write("<script>alert('Login Failed! Incorrect username/password')</script>");
            else
            {
                Session["New"] = TextBox1.Text;
                Session["Role"] = ret;

                if ( ret == "manager" ) { Response.Redirect("Manager.aspx"); }
                else if ( ret == "staff" ) { Response.Redirect("Staff.aspx"); }
                else if ( ret == "owner" ) { Response.Redirect("Owner.aspx"); }
                else if ( ret == "error" ) { Response.Write("<script>alert('ERROR!!!!!')</script>"); }
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}