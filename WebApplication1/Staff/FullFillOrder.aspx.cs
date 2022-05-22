using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Staff
{
    public partial class FullFillOrder : System.Web.UI.Page
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
                    string orderId = Request.QueryString["OrderId"];
                    if (orderId != null)
                    {
                        orderStateId = Controller.OrderControl.getSelectedOrderStateId(Int32.Parse(orderId));
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

        protected void btnFullFillOrder_Click(object sender, EventArgs e)
        {
            string orderId = Request.QueryString["OrderId"];
            if (orderId != null)
            {
                string orderStateId= ddlOrderState.SelectedValue;
                bool confirm = Controller.OrderControl.fullFillCustomerOrder(Int32.Parse(orderId),Int32.Parse(orderStateId));
                if (confirm)
                {
                    lblFullfillOrderMessage.Text = "Order has been fullfilled successfully.";
                }
                else
                {
                    lblFullfillOrderMessage.Text = "Something went wrong please try again later.";
                }

            }
        }
    }
}