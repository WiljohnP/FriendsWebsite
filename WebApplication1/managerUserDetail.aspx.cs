using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace WebApplication1
{
	public partial class managerUserDetail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
            {
                if (Session["userName"] == null)
                {
                    btnSubmit.Text = "Create";
                }
                else
                {
                    btnSubmit.Text = "Update";
                    dataBind();
                }
            }
        }

        protected void dataBind()
        {
            DataTable table = new DataTable();

            Controller.UserControl uc = new Controller.UserControl();

            table = uc.retrieveUserDetail(Session["userName"].ToString());

            txtUserName.Text = table.Rows[0][0].ToString();
            txtUserName.Enabled = false;

            txtStaffNo.Text = table.Rows[0][1].ToString();
            txtPhone.Text = table.Rows[0][2].ToString();

            bool status = Convert.ToBoolean(table.Rows[0][3]);
            if ((status) == false)
            {
                ddlStatus.SelectedValue = "0";
            }
            else
            {
                ddlStatus.SelectedValue = "1";
            }
            
            ddlType.SelectedValue = table.Rows[0][4].ToString();
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
                    if ((txtUserName.Text.Trim() != "") && (txtStaffNo.Text.Trim() != "") && (txtPhone.Text.Trim() != "") && (txtPassword.Text.Trim() != ""))
                    {
                        bool insertSuccess = uc.insertUser(txtUserName.Text.Trim(), txtStaffNo.Text.Trim(), Convert.ToInt32(txtPhone.Text.Trim()), Convert.ToInt16(ddlStatus.SelectedValue), txtPassword.Text.Trim(), Convert.ToInt16(ddlType.SelectedValue));
                        if (insertSuccess == true)
                        {
                            Response.Write("<script language='javascript'>window.alert('Username creation successful');window.location='managerUser.aspx';</script>");
                        }
                        else
                        {
                            lblError.Text = "Insert Error!!!";
                        }
                    }
                    else
                    {
                        lblError.Text = "Please input all fields!";
                    }
                    
                }
            }
            else
            {
                Controller.UserControl uc = new Controller.UserControl();

                bool updateSuccess = uc.modifyUser(txtUserName.Text.Trim(), txtStaffNo.Text.Trim(), Convert.ToInt32(txtPhone.Text.Trim()), Convert.ToInt16(ddlStatus.SelectedValue), txtPassword.Text.Trim(), Convert.ToInt16(ddlType.SelectedValue));
                if (updateSuccess == true)
                {
                    Response.Write("<script language='javascript'>window.alert('User detail updated');window.location='managerUser.aspx';</script>");
                }
                else
                {
                    lblError.Text = "Update Error!!!";
                }
            }
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Session["userName"] = null;
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerMenu.aspx");
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Session["userName"] = null;
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerUser.aspx");
        }
    }
}