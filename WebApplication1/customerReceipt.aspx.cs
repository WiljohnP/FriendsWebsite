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
    public partial class customerReceipt : System.Web.UI.Page
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

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Session["tableNo"] = Session["tableNo"];
            Response.Redirect("customerOrder.aspx");
        }

        protected void dataBind()
        {
            lblTableNo.Text = Session["tableNo"].ToString();

            Double grandTotal = 0;
            DataTable table = new DataTable();

            Controller.OrderControl oc = new Controller.OrderControl();

            table = oc.retrieveReceiptList(Convert.ToInt32(Session["tableNo"].ToString()));
            gvReceipt.DataSource = table;
            gvReceipt.DataBind();

            foreach (DataRow row in table.Rows)
            {
                grandTotal += Convert.ToDouble(row["totPrice"]);
            }
            String total = String.Format("{0:F2}", grandTotal);
            lblTotalPrice.Text = total;
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            Session["tableNo"] = lblTableNo.Text;

            Int32 data = 0;
            Controller.OrderControl oc = new Controller.OrderControl();
            data = oc.retrieveCheckAllOrderCompleted(Convert.ToInt32(Session["tableNo"].ToString()));

            if (data <= 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append("Order not yet completed");
                sb.Append("');};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                Session["tableNo"] = Session["tableNo"];
                Response.Redirect("customerPayment.aspx");
            }
        }
    }
}