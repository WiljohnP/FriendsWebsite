using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class managerUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
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
    }
}