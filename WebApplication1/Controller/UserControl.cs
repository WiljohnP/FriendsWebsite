using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Controller
{
    public class UserControl
    {
        public DataTable retrieveUserList()
        {
            DataTable data = new DataTable();

            WebApplication1.Entity.User us = new WebApplication1.Entity.User();

            data = us.getUserList();
            return data;
        }

        public string validateLogin(string tb1, string tbpassword)
        {
            if (isUserExists(tb1))
            {
                string ret = validatePassword(tb1, tbpassword);
                if (ret != "wrong password")
                {
                    if (ret == "manager" || ret == "staff" || ret == "owner") { return ret; } // login successful
                    else { return "error"; } // error
                }
                else { return "fail"; } // wrong password
            } else { return "fail"; } // user doesnt exists

        }

        public bool isUserExists(string tb1)
        {
            WebApplication1.Entity.User us = new WebApplication1.Entity.User();
            int cu = us.checkUser(tb1);
            if (cu == 1)
                return true;
            else
                return false;
        }

        public string validatePassword(string tb1, string tbpassword)
        {
            WebApplication1.Entity.User us = new WebApplication1.Entity.User();
            string[] dr = us.getPass(tb1);

            string temp_password = dr[0];
            string role = dr[1];
            
            if (temp_password == tbpassword)
            {
                return role;
            }
            else 
            {
                return "wrong password";
            }
        }
    }
}