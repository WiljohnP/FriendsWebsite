using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Staff
{
    public partial class ViewCustomerOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"]!= null)
            {
                int OrderId = Int32.Parse(Request.QueryString["OrderId"]);
                Staff.Repository.ViewCustomerOrderDetails.GetCustomerOrderDetails details = Staff.Repository.ViewCustomerOrderDetails.getCustomerOrderDetails(OrderId);
                if (details != null)
                {
                    lblOrderId.Text = details.OrderId;
                    lblMenuOrderId.Text = details.OrderMenuId;
                    lblUEN.Text = details.UEN;
                    lblCategory.Text = details.Category;
                    lblMenu.Text = details.Menu;
                    ImageUrl.ImageUrl = "~/" + details.ImagePath;
                    lblPrice.Text = details.Price;
                    lblQuantity.Text = details.Quantity;
                    lblCreatedDate.Text = details.CreatedDate;
                    lblModifiedDate.Text = details.ModifiedDate;
                    lblOrderState.Text = details.OrderState;
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }

         
        }
    }
}