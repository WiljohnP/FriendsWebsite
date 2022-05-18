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
            Session["uen"] = null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string inputVal = txtUEN.Text.Trim();
            bool isValid = false;

            Controller.TableControl tb = new Controller.TableControl();

            isValid = tb.checkUENValid(inputVal);

            if (isValid == false)
            {
                Response.Write("<script>alert('Invalid UEN! Please reenter the UEN.')</script>");
            }
            else
            {
                Session["uen"] = inputVal;
                Response.Redirect("customerOrder.aspx");
            }
        }
    }
}