using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null) // && Session["type"].ToString() != "customer") 
            {
                lblUsername.Text = Session["New"].ToString();
                lblRole.Text = Session["Role"].ToString();
            }
            else 
            {
                Response.Redirect("Login.aspx");
            }
            
        }
    }
}