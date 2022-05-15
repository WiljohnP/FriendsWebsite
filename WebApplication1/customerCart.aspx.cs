using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace WebApplication1
{
    public partial class customerCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tableNo"] != null)
                {
                    dataBind();
                }
            }
        }

        protected void dataBind()
        {
            Double grandTotal = 0;
            DataTable table = new DataTable();

            Controller.OrderControl od = new Controller.OrderControl();
            table = od.retrieveCartList(Convert.ToInt32(Session["tableNo"].ToString()));
            gvCart.DataSource = table;
            gvCart.DataBind();

            foreach (DataRow row in table.Rows)
            {
                grandTotal += Convert.ToDouble(row["totPrice"]);
            }
            String total = String.Format("{0:F2}", grandTotal);
            lblTotalPrice.Text = total;
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 id = 0;
            Int32 index = -1;
            DataTable table = new DataTable();

            if (e.CommandName == "doUpdate")
            {
                id = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow selectedRow = ((GridViewRow)((Button)e.CommandSource).NamingContainer);
                index = selectedRow.RowIndex;

                TextBox txtQty = (TextBox)gvCart.Rows[index].FindControl("txtQty");

                Controller.OrderControl od = new Controller.OrderControl();
                bool updateSuccess = od.modifyQuantity(Convert.ToInt32(Session["tableNo"].ToString()), id, Convert.ToInt32(txtQty.Text.Trim()));
                if (updateSuccess == false)
                {
                    lblError.Text = "Error Update Data";

                    return;
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append("Cart Updated");
                    sb.Append("');};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }
            }
            else if (e.CommandName == "doCancel")
            {
                id = Convert.ToInt32(e.CommandArgument.ToString());

                Controller.OrderControl od = new Controller.OrderControl();
                bool deleteSuccess = od.removeOrderMenu(Convert.ToInt32(Session["tableNo"].ToString()), id);
                if (deleteSuccess == false)
                {
                    lblError.Text = "Error Delete Data";

                    return;
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append("Menu removed");
                    sb.Append("');};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }
            }

            lblError.Text = "";

            dataBind();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Session["tableNo"] = Session["tableNo"].ToString();

                Controller.OrderControl od = new Controller.OrderControl();
                dt = od.retrieveCartLstExist(Convert.ToInt32(Session["tableNo"].ToString()));

                if (dt.Rows.Count != 0)
                {
                    bool updateSuccess = od.modifyOrderState(Convert.ToInt32(dt.Rows[0][0].ToString()),3);
                    if (updateSuccess == false)
                    {
                        lblError.Text = "Update State Error";
                    }
                    else
                    {
                        lblError.Text = "";
                        Response.Redirect("customerReceipt.aspx");
                    }    
                    
                }
            }
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Session["tableNo"] = Session["tableNo"].ToString();
            Response.Redirect("customerOrder.aspx");
        }
    }
}