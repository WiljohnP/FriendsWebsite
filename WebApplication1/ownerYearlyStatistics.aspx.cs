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
    public partial class ownerYearlyStatistics : System.Web.UI.Page
    {
        SeriesChartType type = SeriesChartType.Pie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable data;
                Controller.OrderControl oc = new Controller.OrderControl();
                data = oc.getDistinctYear();
                YearDDL.DataSource = data;
                YearDDL.DataValueField = "Year";
                YearDDL.DataTextField = "Year";
                YearDDL.DataBind();
                DisplayChart(type);
            }
        }

        protected void YearDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayChart(type);
        }

        private void DisplayChart(SeriesChartType cType)
        {
            DataTable data;
            Controller.OrderControl oc = new Controller.OrderControl();
            data = oc.getYearlySales(YearDDL.SelectedValue);
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

            string res = string.Join(Environment.NewLine, oc.getYearlyTotalSales(YearDDL.SelectedValue).Rows.OfType<DataRow>().Select(x => string.Join("", x.ItemArray)));
            lblTotalPrice.Text = res;
        }

        protected void btnDaily_Click(object sender, EventArgs e)
        {
            Response.Redirect("ownerDailyStatistics.aspx");
        }

        protected void btnWeekly_Click(object sender, EventArgs e)
        {
            Response.Redirect("ownerWeeklyStatistics.aspx");
        }
    }
}