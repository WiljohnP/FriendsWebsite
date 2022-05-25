using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Staff
{
    public partial class FulfilOrder : System.Web.UI.Page
    {
        public int OrderId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                var orderStateId = "";
                if (!this.IsPostBack)
                {
                    var result = Controller.OrderControl.getOrderStates();
                    ddlOrderState.DataSource = result;
                    ddlOrderState.DataValueField = "Id";
                    ddlOrderState.DataTextField = "orderState";
                    ddlOrderState.DataBind();
                    string OrderMenuId = Request.QueryString["OrderMenuId"];
                    if (OrderMenuId != null)
                    {
                        orderStateId = Controller.OrderControl.getSelectedOrderStateId(Int32.Parse(OrderMenuId));
                    }
                    if (orderStateId != null)
                    {
                        ddlOrderState.SelectedValue = orderStateId;
                    }

                }

            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btnFulfilOrder_Click(object sender, EventArgs e)
        {
            string OrderMenuId = Request.QueryString["OrderMenuId"];
            if (OrderMenuId != null)
            {
                string orderStateId= ddlOrderState.SelectedValue;
                bool confirm = Controller.OrderControl.FulfilCustomerOrder(Int32.Parse(OrderMenuId),Int32.Parse(orderStateId));
                if (confirm)
                {
                    lblFulfilOrderMessage.Text = "Order has been Fulfiled successfully.";
                }
                else
                {
                    lblFulfilOrderMessage.Text = "Something went wrong please try again later.";
                }

            }
        }
    }
}