using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebApplication1
{
	public partial class managerUserDetail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
            {
                if (Session["userId"] == null)
                {
                    btnSubmit.Text = "Create";
                }
                else
                {
                    btnSubmit.Text = "Update";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Create")
            {
                Controller.UserControl uc = new Controller.UserControl();

                if (uc.isUserExists(txtUserName.Text.Trim()) == true)
                {
                    lblError.Text = "Username already exist!";
                }
                else
                {
                    bool insertSuccess = uc.insertUser(txtUserName.Text.Trim(), txtStaffNo.Text.Trim(), Convert.ToInt32(txtPhone.Text.Trim()), Convert.ToInt16(ddStatus.SelectedValue), txtPassword.Text.Trim(), Convert.ToInt16(ddlType.SelectedValue));
                    if (insertSuccess == true)
                    {
                        Response.Write("<script language='javascript'>window.alert('Username creation successful');window.location='managerUser.aspx';</script>");
                    }
                    else
                    {
                        lblError.Text = "Insert Error!!!";
                    }
                }
            }
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Session["userId"] = null;
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerMenu.aspx");
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Session["userId"] = null;
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerUser.aspx");
        }
    }
}