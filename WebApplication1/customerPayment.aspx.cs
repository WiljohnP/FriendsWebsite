using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;

namespace WebApplication1
{
    public partial class customerPayment : System.Web.UI.Page
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

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string masterCardRegex = @"^(?:5[1-5][0-9]{14})$";
            var visaCardRegex = @"^(?:4[0-9]{12})(?:[0-9]{3})$";


            if (ddlCardType.SelectedValue=="Visa")
            {
                Regex reVisa = new Regex(visaCardRegex);

                if (reVisa.IsMatch(txtCardNo.Text))
                {
                    Controller.OrderControl oc = new Controller.OrderControl();

                    bool updateSuccess = oc.modifyOrderCheckedOut(Convert.ToInt32(Session["tableNo"].ToString()));
                    if (updateSuccess == true)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type='text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append("Payment Successful, Thank You!!!");
                        sb.Append("');window.location='Main.aspx';};");
                        sb.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    }
                    else
                    {
                        lblError.Text = "Payment failed";
                    }
                }
                else
                {
                    lblError.Text = "Invalid card";
                }
            }
            else if (ddlCardType.SelectedValue == "Master")
            {
                Regex reMaster = new Regex(masterCardRegex);

                if (reMaster.IsMatch(txtCardNo.Text))
                {
                    Controller.OrderControl oc = new Controller.OrderControl();

                    bool updateSuccess = oc.modifyOrderCheckedOut(Convert.ToInt32(Session["tableNo"].ToString()));
                    if (updateSuccess == true)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type='text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append("Payment Successful, Thank You!!!");
                        sb.Append("');window.location='Main.aspx';};");
                        sb.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    }
                    else
                    {
                        lblError.Text = "Payment failed";
                    }

                }
                else
                {
                    lblError.Text = "Invalid card";
                }
            }
        }

        protected void dataBind()
        {
            lblTableNo.Text = Session["tableNo"].ToString();

            Double grandTotal = 0;
            DataTable table = new DataTable();

            Controller.OrderControl oc = new Controller.OrderControl();

            table = oc.retrievePaymentList(Convert.ToInt32(Session["tableNo"].ToString()));
            gvPayment.DataSource = table;
            gvPayment.DataBind();

            foreach (DataRow row in table.Rows)
            {
                grandTotal += Convert.ToDouble(row["totPrice"]);
            }
            String total = String.Format("{0:F2}", grandTotal);
            lblTotalPrice.Text = total;
        }

    }
}