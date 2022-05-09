using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                lblLogOut.Visible = false;
            }
            else
            {
                lblLogOut.Visible = true;
            }
        }

        protected void lblLogOut_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Session["Role"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}