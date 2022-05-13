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
    public partial class managerMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["New"] != null && Session["Role"].ToString() == "manager")
                {
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
                dataBind();
            }
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerUser.aspx");
        }

        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            Session["menuId"] = null;
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerMenuDetail.aspx");
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

                bool deleteSuccess = mc.removeMenu(id);
                if (deleteSuccess == true)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append("Menu deleted");
                    sb.Append("');};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    dataBind();
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = "Delete Error!!!";
                }
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