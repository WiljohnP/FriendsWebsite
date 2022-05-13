using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class customerOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Session["tableNo"] = lblTableNo.Text;
            Response.Redirect("customerCart.aspx");
        }

        protected void dataBind()
        {
            lblTableNo.Text = "1";

            DataTable table = new DataTable();

            Controller.MenuControl mc = new Controller.MenuControl();

            table = mc.retrieveAvaiableMenu();
            gvOrder.DataSource = table;
            gvOrder.DataBind();
        }

        protected void gvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 id = 0;
            TextBox txtQuantity = null;
            Label lblMenu = null;

            if (e.CommandName == "doAdd")
            {
                id = Convert.ToInt32(e.CommandArgument.ToString());

            }
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            Session["tableNo"] = lblTableNo.Text;
            Response.Redirect("customerPayment.aspx");
        }
    }
}