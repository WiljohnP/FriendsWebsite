using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class managerMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBind();
            }
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerUser.aspx");
        }

        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerMenuDetail.aspx");
        }

        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dataBind()
        {
            DataTable table = new DataTable();
            table.Columns.Add("menu", typeof(string));
            table.Columns.Add("price", typeof(string));
            table.Columns.Add("type", typeof(string));
            table.Columns.Add("status", typeof(string));

            table.Rows.Add("Fish Burger", "4.50", "Main Dish", "Available");
            table.Rows.Add("Cheese Burger", "5.00", "Main Dish", "Available");
            table.Rows.Add("Fried Chicken", "8.00", "Main Dish", "Out of Stock");

            gvMenu.DataSource = table;
            gvMenu.DataBind();
        }
    }
}