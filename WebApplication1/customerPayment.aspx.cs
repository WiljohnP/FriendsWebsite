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
            dataBind();
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
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
                    //Response.Write("<script language='javascript'>window.alert('Payment success, Thank you.);window.location='Main.aspx';</script>");
                    
                    //StringBuilder sb = new StringBuilder();
                    //sb.Append("<script type = 'text / javascript'>");
                    //sb.Append("window.onload=function(){");
                    //sb.Append("alert('");
                    //sb.Append("Reservation Created, Please Wait for Confirmation");
                    //sb.Append("')}; ");
                    //sb.Append("window.location = '");
                    //sb.Append("Main.aspx");
                    //sb.Append("';}");
                    //sb.Append("</script>");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }
                else
                {
                    errorText.Attributes["style"] = "display: block; text-align: center; color:red;";
                }
            }
            else if (ddlCardType.SelectedValue == "Master")
            {
                Regex reMaster = new Regex(masterCardRegex);

                if (reMaster.IsMatch(txtCardNo.Text))
                {
                    //Response.Write("<script language='javascript'>window.alert('Payment made with '" + ddlPayment.SelectedValue + "', Thank you.);window.location='Main.aspx';</script>");
                }
                else
                {
                    errorText.Attributes["style"] = "display: block; text-align: center; color:red;";
                }
            }
        }

        protected void gvPayment_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dataBind()
        {
            lblTableNo.Text = "1";

            DataTable table = new DataTable();
            table.Columns.Add("menu", typeof(string));
            table.Columns.Add("price", typeof(string));
            table.Columns.Add("type", typeof(string));
            table.Columns.Add("totPrice", typeof(string));
            table.Columns.Add("quantity", typeof(string));

            table.Rows.Add("Cheese Burger", "5.00", "Main Dish", "5.00", "1");
            table.Rows.Add("Fried Chicken", "8.00", "Main Dish", "16.00", "2");

            gvPayment.DataSource = table;
            gvPayment.DataBind();

            lblTotalPrice.Text = "21.00";
        }

    }
}