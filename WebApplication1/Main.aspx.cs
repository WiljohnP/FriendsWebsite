using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["type"] = "";
        }

        protected void lbtnCustomer_Click(object sender, EventArgs e)
        {
            Session["type"] = "customer";
            Response.Redirect("customerUEN.aspx");
        }
    }
}