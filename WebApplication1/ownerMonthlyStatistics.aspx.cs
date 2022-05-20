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
    public partial class ownerMonthlyStatistics : System.Web.UI.Page
    {
        SeriesChartType type = SeriesChartType.Pie;
        string yyyy;
        string mm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null && Session["Role"].ToString() == "owner")
            {
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                DataTable data;
                DataTable mData;

                Controller.OrderControl oc = new Controller.OrderControl();
                data = oc.getDistinctYear();
                YearDDL.DataSource = data;
                YearDDL.DataValueField = "Year";
                YearDDL.DataTextField = "Year";
                YearDDL.DataBind();

                Controller.OrderControl moc = new Controller.OrderControl();
                mData = moc.getDistinctMonthFromYear(YearDDL.SelectedValue);
                MonthDDL.DataSource = mData;
                MonthDDL.DataValueField = "Month";
                MonthDDL.DataTextField = "Month";
                MonthDDL.DataBind();

                Chart1.Visible = true;
                DisplayChart(type);
            }
        }

        protected void YearDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart1.Visible = true;
            DataTable data;
            Controller.OrderControl oc = new Controller.OrderControl();
            data = oc.getDistinctMonthFromYear(YearDDL.SelectedValue);
            MonthDDL.DataSource = data;
            MonthDDL.DataValueField = "Month";
            MonthDDL.DataTextField = "Month";
            MonthDDL.DataBind();
            DisplayChart(type);
        }

        protected void MonthDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart1.Visible = true;
            DisplayChart(type);
        }

        private void DisplayChart(SeriesChartType cType)
        {
            Chart1.Visible = true;
            DataTable data;
            Controller.OrderControl oc = new Controller.OrderControl();
            yyyy = YearDDL.SelectedValue;
            mm = MonthDDL.SelectedValue;
            data = oc.getMonthlySales(yyyy,mm);
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

            string res = string.Join(Environment.NewLine, oc.getMonthlyTotalSales(yyyy, mm).Rows.OfType<DataRow>().Select(x => string.Join("", x.ItemArray)));
            if(res == "") { res = "0.00"; }
            lblTotalPrice.Text = res;
        }

        protected void btnDaily_Click(object sender, EventArgs e)
        {
            Response.Redirect("ownerDailyStatistics.aspx");
        }
        protected void btnYearly_Click(object sender, EventArgs e)
        {
            Response.Redirect("ownerYearlyStatistics.aspx");
        }

    }
}