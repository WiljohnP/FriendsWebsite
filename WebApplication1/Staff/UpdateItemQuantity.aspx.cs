using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Staff
{
    public partial class UpdateItemQuantity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                if (!this.IsPostBack)
                {
                    string orderMenuId = Request.QueryString["OrderMenuId"];
                    string selectedQuantity = Controller.OrderControl.getSelectedQuantity(Int32.Parse(orderMenuId));
                    txtItemQuantity.Text = selectedQuantity;

                }
               
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
            
           

        }

        protected void btnUpdateOrderQuantity_Click(object sender, EventArgs e)
        {
            string orderMenuId = Request.QueryString["OrderMenuId"];
            if (orderMenuId != null)
            {
                bool confirm = Controller.OrderControl.updateItemQuantity(Int32.Parse(orderMenuId),Int32.Parse(txtItemQuantity.Text));
                if (confirm)
                {
                    lblFullfillOrderMessage.Text = "Quantity has been updated successfully";
                }
                else
                {
                    lblFullfillOrderMessage.Text = "Something went wrong please try again later.";
                }

            }
        }
    }
}