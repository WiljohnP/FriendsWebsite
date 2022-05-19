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
    public partial class customerOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uen"] != null)
                {
                    dataBind();
                }
            }
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Session["tableNo"] = lblTableNo.Text;

            DataTable data = new DataTable();
            Controller.OrderControl oc = new Controller.OrderControl();
            data = oc.retrieveCartLstExist(Convert.ToInt32(Session["tableNo"].ToString()));

            if (data.Rows.Count <= 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append("Cart is Empty");
                sb.Append("');};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                Response.Redirect("customerCart.aspx");
            }
        }

        protected void dataBind()
        {
            DataTable data = new DataTable();

            Controller.TableControl tb = new Controller.TableControl();

            data = tb.retrieveTableNo(Session["uen"].ToString());

            lblTableNo.Text = data.Rows[0][0].ToString();

            DataTable table = new DataTable();

            Controller.MenuControl mc = new Controller.MenuControl();

            table = mc.retrieveAvaiableMenu();
            gvOrder.DataSource = table;
            gvOrder.DataBind();
        }

        protected void gvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 id = 0;
            DataTable data = new DataTable();
            Object obj = 0;
            Int32 index = 0;
            StringBuilder sb = new StringBuilder();

            if (e.CommandName == "doAdd")
            {
                Controller.MenuControl mc = new Controller.MenuControl();

                id = Convert.ToInt32(e.CommandArgument.ToString());

                data = mc.retrieveMenuDetail(id);

                GridViewRow selectedRow = ((GridViewRow)((Button)e.CommandSource).NamingContainer);
                index = selectedRow.RowIndex;

                TextBox txtQty = (TextBox)gvOrder.Rows[index].FindControl("txtQty");

                Double price = Convert.ToDouble(gvOrder.Rows[index].Cells[2].Text);

                if (data.Rows[0][4].ToString() != "Available")
                {
                    sb = new StringBuilder();
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append("Sorry, menu is out of stock already, please choose other menu");
                    sb.Append("');};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

                    dataBind();

                    return;
                }

                data = new DataTable();

                Controller.OrderControl od = new Controller.OrderControl();

                bool insertSuccess = od.insertOrder(Convert.ToInt32(lblTableNo.Text.Trim()), id, Convert.ToInt32(txtQty.Text.Trim()), price);

                if (insertSuccess == false)
                {
                    lblError.Text = "Error Insert Data";

                    return;
                }

                lblError.Text = "";

                sb = new StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append("Added to Cart");
                sb.Append("');};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

                dataBind();
            }
        }

        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            Session["tableNo"] = lblTableNo.Text;

            DataTable data = new DataTable();
            Controller.OrderControl oc = new Controller.OrderControl();
            data = oc.retrieveReceiptList(Convert.ToInt32(Session["tableNo"].ToString()));

            if (data.Rows.Count <= 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append("Receipt is Empty");
                sb.Append("');};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                Session["tableNo"] = lblTableNo.Text;
                Response.Redirect("customerReceipt.aspx");
            }
        }
    }
}