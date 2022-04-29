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
            Response.Redirect("customerCart.aspx");
        }

        protected void dataBind()
        {
            lblTableNo.Text = "1";

            DataTable table = new DataTable();
            table.Columns.Add("menu", typeof(string));
            table.Columns.Add("price", typeof(string));
            table.Columns.Add("type", typeof(string));

            table.Rows.Add("Fish Burger", "$4.50", "Main Dish");
            table.Rows.Add("Cheese Burger", "$5.00", "Main Dish");
            table.Rows.Add("Fried Chicken", "$8.00", "Main Dish");

            gvOrder.DataSource = table;
            gvOrder.DataBind();
        }

        protected void gvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 Index = -1;
            TextBox txtQuantity = null;

            if (e.CommandName == "doAdd")
            {
                
            }
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {

        }
    }
}