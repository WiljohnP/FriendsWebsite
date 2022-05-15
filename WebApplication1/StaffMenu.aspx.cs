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
    public partial class StaffMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["New"] != null && Session["Role"].ToString() == "staff")
                {
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                dataBind();
            }
        }
        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 id = 0;
            if (e.CommandName == "doUpdate")
            {
                id = Convert.ToInt32(e.CommandArgument.ToString());
                Session["menuId"] = id;
                Response.Redirect("managerMenuDetail.aspx");
            }
            else if (e.CommandName == "doDelete")
            {
                id = Convert.ToInt32(e.CommandArgument.ToString());

                Controller.MenuControl mc = new Controller.MenuControl();

           
            }
        }
        protected void dataBind()
        {
            DataTable table = new DataTable();

            Controller.MenuControl mc = new Controller.MenuControl();

            table = mc.retrieveMenuList();
            gvMenu.DataSource = table;
            gvMenu.DataBind();
        }
        protected void gvMenu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDelete = e.Row.FindControl("btnDelete") as Button;
                btnDelete.Attributes["onclick"] = "return confirm('Do you want to delete this menu?');";
            }
        }
    }
}