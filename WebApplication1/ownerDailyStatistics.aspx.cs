using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ownerDailyStatistics : System.Web.UI.Page
    {
        SeriesChartType type = SeriesChartType.Pie;
        string yyyy;
        string mm;
        string dd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null && Session["Role"].ToString() == "owner")
            {
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] textSplit = TextBox1.Text.Split('-');
            yyyy = textSplit[0];
            mm = textSplit[1];
            dd = textSplit[2];
            DisplayChart(type);
            Chart1.Visible = true;
        }

        private void DisplayChart(SeriesChartType cType)
        {
            DataTable data;
            Controller.OrderControl oc = new Controller.OrderControl();
            data = oc.getDailySales(yyyy,mm,dd);
            string[] xaxis = new string[data.Rows.Count];
            int[] yaxis = new int[data.Rows.Count];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                xaxis[i] = data.Rows[i]["Item Name"].ToString() + " ($ " + data.Rows[i]["Sales Price"] + ")";
                yaxis[i] = Convert.ToInt32(data.Rows[i]["Sales Price"]);
            }
            Chart1.Series[0].Points.DataBindXY(xaxis, yaxis);
            Chart1.Series[0].ChartType = cType;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Legends[0].Enabled = true;

            string res = string.Join(Environment.NewLine, oc.getDailyTotalSales(yyyy, mm, dd).Rows.OfType<DataRow>().Select(x => string.Join("", x.ItemArray)));
            if(res == "") { res = "0.00"; }
            lblTotalPrice.Text = res;
        }

        protected void btnYearly_Click(object sender, EventArgs e)
        {
            Response.Redirect("ownerYearlyStatistics.aspx");
        }
    }
}