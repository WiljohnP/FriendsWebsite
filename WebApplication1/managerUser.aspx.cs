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
    public partial class managerUser : System.Web.UI.Page
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

        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            String sUsername = "";
            if (e.CommandName == "doUpdate")
            {
                sUsername = Convert.ToString(e.CommandArgument.ToString());
                Session["userName"] = sUsername;
                Response.Redirect("managerUserDetail.aspx");
            }
            else if (e.CommandName == "doDelete")
            {
                sUsername = Convert.ToString(e.CommandArgument.ToString());

                Controller.UserControl uc = new Controller.UserControl();

                bool deleteSuccess = uc.removeUser(sUsername);
                if (deleteSuccess == true)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type='text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append("User deleted");
                    sb.Append("');};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    dataBind();
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = "Insert Error!!!";
                }
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Session["userName"] = null;
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerUserDetail.aspx");
        }

        protected void dataBind()
        {
            DataTable table = new DataTable();

            Controller.UserControl uc = new Controller.UserControl();

            table = uc.retrieveUserList();
            gvUser.DataSource = table;
            gvUser.DataBind();
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("managerMenu.aspx");
        }

        protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDelete = e.Row.FindControl("btnDelete") as Button;
                btnDelete.Attributes["onclick"] = "return confirm('Do you want to delete this user?');";
            }
        }
    }
}