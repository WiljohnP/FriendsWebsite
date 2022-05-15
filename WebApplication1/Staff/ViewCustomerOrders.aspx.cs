using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Staff
{
    public partial class ViewCustomerOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                if (!this.IsPostBack)
                {
                    var result = Staff.Repository.ViewCustomerOrders.getCustomerOrders();
                    gvCustomerOrders.DataSource = result;
                    gvCustomerOrders.DataBind();
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }


            
        }



        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDelete = e.Row.FindControl("btnDelete") as Button;
                btnDelete.Attributes["onclick"] = "return confirm('Do you want to delete this customer order?');";
            }
        }

        protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteOrder")
            {
                int OrderMenuId = Convert.ToInt32(e.CommandArgument.ToString());
                bool confirm= Staff.Repository.ViewCustomerOrders.DeleteCustomerMenuOrderItem(OrderMenuId);
                if (confirm)
                {
                    gvCustomerOrders.DataSource = Staff.Repository.ViewCustomerOrders.getCustomerOrders();
                    gvCustomerOrders.DataBind();
                }
            }
        }
    }
}