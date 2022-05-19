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
    public partial class ownerStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable data;
            Controller.OrderControl oc = new Controller.OrderControl();
            data = oc.getDistinctYear();
            YearDDL.DataSource = data;
            YearDDL.DataValueField = "Year";
            YearDDL.DataTextField = "Year";
            YearDDL.DataBind();
            SeriesChartType type = SeriesChartType.Pie;
            DisplayChart(type);
        }

        protected void YearDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeriesChartType type = SeriesChartType.Pie;
            DisplayChart(type);
        }

        private void DisplayChart(SeriesChartType cType)
        {
            DataTable data;
            Controller.OrderControl oc = new Controller.OrderControl();
            data = oc.getYearlySales(YearDDL.SelectedValue);
            string[] x = new string[data.Rows.Count];
            int[] y = new int[data.Rows.Count];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                x[i] = data.Rows[i]["Item Name"].ToString() + "($" + data.Rows[i]["Sales Price"] + ")";
                y[i] = Convert.ToInt32(data.Rows[i]["Sales Price"]);
            }
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = cType;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Legends[0].Enabled = true;
        }
    }
}