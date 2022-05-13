using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.IO;

namespace WebApplication1
{
	public partial class managerMenuDetail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Session["menuId"] == null)
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

            Controller.MenuControl mc = new Controller.MenuControl();

            table = mc.retrieveMenuDetail(Convert.ToInt32(Session["menuId"]));

            hfId.Value = table.Rows[0][0].ToString();
            txtMenuName.Text = table.Rows[0][1].ToString();
            ddlCategory.SelectedValue = table.Rows[0][2].ToString();
            txtPrice.Text = table.Rows[0][3].ToString();
            ddlStatus.SelectedValue = table.Rows[0][4].ToString();
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Session["menuId"] = null;
            Session["userName"] = null;
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerMenu.aspx");
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Session["menuId"] = null;
            Session["userName"] = null;
            Session["New"] = Session["New"].ToString();
            Session["Role"] = Session["Role"].ToString();
            Response.Redirect("managerUser.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Create")
            {
                Controller.MenuControl mc = new Controller.MenuControl();

                DataTable data = mc.retrieveMenuName(txtMenuName.Text.Trim());

                if ((data.Rows.Count) > 0)
                {
                    lblError.Text = "Menu already exist!";
                }
                else
                {
                    if ((txtMenuName.Text.Trim() != "") && (FileUpload.HasFile == true) && (txtPrice.Text.Trim() != ""))
                    {
                        String imageUrl = "";
                        String id = "";
                        DataTable dataMenu = mc.retrieveMenuList();
                        bool bContinueLoop = true;

                        //check image exist before save to prevent error
                        while (true == true)
                        {
                            id = Guid.NewGuid().ToString("N").Substring(0, 10);
                            imageUrl = "Images/Menu/" + id +Path.GetExtension(FileUpload.FileName);

                            if (dataMenu.Rows.Count > 0)
                            {
                                foreach (DataRow row in dataMenu.Rows)
                                {
                                    if (row["path"].ToString() != imageUrl.ToString())
                                    {
                                        bContinueLoop = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                            
                            if (bContinueLoop == false)
                            {
                                break;
                            }
                        }

                        bool insertSuccess = mc.insertMenu(txtMenuName.Text.Trim(),ddlCategory.SelectedValue, Convert.ToDouble(txtPrice.Text.Trim()), ddlStatus.SelectedValue, imageUrl);
                        if (insertSuccess == true)
                        {
                            FileUpload.SaveAs(Server.MapPath("Images//Menu//" + id +Path.GetExtension(FileUpload.FileName)));

                            Response.Write("<script language='javascript'>window.alert('Menu creation successful');window.location='managerMenu.aspx';</script>");
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
            else if(btnSubmit.Text == "Update")
            {
                Controller.MenuControl mc = new Controller.MenuControl();

                if ((txtMenuName.Text.Trim() != "") && (txtPrice.Text.Trim() != ""))
                {
                    String imageUrl = "";
                    String id = "";
                    DataTable dataMenu = mc.retrieveMenuList();
                    bool bContinueLoop = true;

                    //check image exist before save to prevent error
                    if (FileUpload.HasFile == true)
                    {
                        while (true == true)
                        {
                            id = Guid.NewGuid().ToString("N").Substring(0, 10);
                            imageUrl = "Images/Menu/" + id + Path.GetExtension(FileUpload.FileName);

                            if (dataMenu.Rows.Count > 0)
                            {
                                foreach (DataRow row in dataMenu.Rows)
                                {
                                    if (row["path"].ToString() != imageUrl.ToString())
                                    {
                                        bContinueLoop = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            if (bContinueLoop == false)
                            {
                                break;
                            }
                        }
                    }
                    
                    bool updateSuccess = mc.modifyMenu(Convert.ToInt16(Session["menuId"]), txtMenuName.Text.Trim(), ddlCategory.SelectedValue, Convert.ToDouble(txtPrice.Text.Trim()), ddlStatus.SelectedValue, imageUrl);
                    if (updateSuccess == true)
                    {
                        if (FileUpload.HasFile == true)
                        {
                            FileUpload.SaveAs(Server.MapPath("Images//Menu//" + id + Path.GetExtension(FileUpload.FileName)));
                        }

                        Response.Write("<script language='javascript'>window.alert('Update successful');window.location='managerMenu.aspx';</script>");
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
    }
}